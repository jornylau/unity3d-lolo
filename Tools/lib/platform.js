/**
 * 生成或更新目标平台项目 iOS / Android
 * Created by LOLO on 2019/4/15.
 */


const fs = require('fs');
const child_process = require('child_process');
const common = require('./common');
const logger = require('./logger');
const progress = require('./progress');
const destAndZip = require('./destAndZip');

const platform = module.exports = {};


let callback;// 完成时的回调
let ppName = common.targetPlatform === 'ios' ? 'XCode' : 'AndroidStudio';

// 需要合并的文件夹
const combineDirs = {
    android: {
        copy: ['libs/', 'src/main/jniLibs/'],
        merge: ['src/main/assets/', 'src/main/java/shibaInu/'],
        res: 'src/main/assets/',// 打包生成的所有资源存放目录
    },
    ios: {
        copy: [],
        merge: ['Data/', 'Classes/', 'Libraries/'],
        res: 'Data/Raw/',
    },
};


/**
 * 开始生成目标平台项目
 * @param cb
 */
platform.start = function (cb) {
    callback = cb;
    if (!common.generatePlatformProject) {
        callback();
        return;
    }

    progress.setTiming(progress.TT_GPP, true);
    logger.append(`- 开始生成 ${ppName} 项目`);

    // 清空 StreamingAssets 文件夹
    let saDir = common.projectDir + 'Assets/StreamingAssets/';
    if (fs.existsSync(saDir)) common.removeDir(saDir);
    fs.mkdirSync(saDir);

    // 启动 unity 进程
    let cmd = common.unityCmd;
    cmd += ' -executeMethod ShibaInu.Builder.GeneratePlatformProject';
    cmd += ` -targetPlatform ${common.targetPlatform}`;
    cmd += ` -outputDir ${common.tmpPlatformDir}`;
    child_process.exec(cmd, (err, stdout, stderr) => {
        if (err) throw err;
        logger.append(`- 生成 ${ppName} 项目完成`);
        progress.gpp(1);
        generateComplete();
    });
};


/**
 * 创建目标平台项目完成，项目路径为 tmpPlatformDir
 */
let generateComplete = function () {
    let isAndroid = common.targetPlatform === 'android';
    if (isAndroid) {
        // AndroidStudio 项目会生成在子目录中
        common.tmpPlatformDir += `${fs.readdirSync(common.tmpPlatformDir)[0]}/`;
        // 拷贝框架 java 代码
        common.copyDir(common.androidJavaDir, `${common.tmpPlatformDir}src/main/java/`);
    }

    let resDir = combineDirs[common.targetPlatform].res;
    let androidResBinDir = `${common.tmpPlatformDir}${resDir}bin/`;
    let androidResBinBakDir = `${common.tmpPlatformDir}${resDir}../bin_bak/`;
    if (isAndroid)
        fs.renameSync(androidResBinDir, androidResBinBakDir);// 备份 bin 目录到上级目录

    // 拷贝打包生成的所有资源到 tmpPlatformDir
    destAndZip.destRes(common.tmpPlatformDir + resDir, () => {
        if (isAndroid)
            fs.renameSync(androidResBinBakDir, androidResBinDir);// 还原 bin 目录
        updatePlatformProject();
    });
};


/**
 * 更新目标平台项目
 */
let updatePlatformProject = function () {
    logger.append(`- 开始更新 ${ppName} 项目`);

    // 没生成过，直接改名
    if (!fs.existsSync(common.targetPlatformDir)) {
        fs.renameSync(common.tmpPlatformDir, common.targetPlatformDir);
        updateComplete();
    }

    // 同步文件夹内容
    else {
        let dirs = combineDirs[common.targetPlatform];

        // 删除资源目录
        common.removeDir(dirs.res);

        // 拷贝目录
        for (let i = 0; i < dirs.copy.length; i++) {
            let dirName = dirs.copy[i];
            common.copyDir(common.tmpPlatformDir + dirName, common.targetPlatformDir + dirName);
        }

        // 合并目录
        let count = dirs.merge.length;
        let index = -1;
        let next = () => {
            if (++index === count) {
                updateComplete();
                return;
            }
            let dirName = dirs.merge[index];
            common.mergeDir(common.tmpPlatformDir + dirName, common.targetPlatformDir + dirName, next);
        };
        next();
    }
};


/**
 * 更新目标平台项目完成
 */
let updateComplete = function () {
    logger.append(`- 更新 ${ppName} 项目完成`);
    progress.gpp(2);
    progress.setTiming(progress.TT_GPP, false);
    callback();
};
