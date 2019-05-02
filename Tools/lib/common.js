/**
 * 公用常量，变量和方法
 * Created by LOLO on 2019/3/29.
 */


const path = require('path');
const fs = require('fs');
const crypto = require('crypto');
const child_process = require('child_process');
const args = require('commander');
const config = require('./config');

const common = module.exports = {};


// 解析命令行参数
args
    .version('0.1.0')
    .option('-i, --id <value>', '本次打包唯一标识符')
    .option('-p, --projectName <value>', '项目名称')
    .option('-v, --version3 <value>', '3位版本号')
    .option('-t, --targetPlatform <value>', '目标平台，可接受值: ios, android, macos, windows')
    .option('-n, --notEncode', '是否不需要编码 lua 文件')
    .option('-g, --generatePlatformProject', '是否生成目标平台项目，只支持: ios, android')
    .option('-u, --unityVersion <value>', '使用的 unity 版本号，默认值为: config.unityVersion')
    .option('-f, --projectPath <value>', '项目路径。如果传入了该参数，将会忽略版本检出和更新')
    .option('-c, --platformProject <value>', '目标平台项目路径。如果传入了该参数，-g 参数将为 true')
    .option('-d, --destDir <value>', '将生成的资源拷贝至该目录')
    .option('-z, --packZip', '是否需要生成 zip 包')
    .parse(process.argv);

common.id = args.id;                                            // -i
common.projectName = args.projectName;                          // -p
common.version3 = args.version3;                                // -v
common.targetPlatform = args.targetPlatform;                    // -t
common.notEncode = args.notEncode;                              // -n
common.generatePlatformProject = args.generatePlatformProject;  // -g
common.unityVersion = args.unityVersion;                        // -u
common.projectPath = args.projectPath;                          // -f
common.platformProject = args.platformProject;                  // -c
common.destDir = args.destDir;                                  // -d
common.packZip = args.packZip;                                  // -z

if (common.unityVersion === undefined)
    common.unityVersion = config.unityVersion;

if (common.platformProject !== undefined) {
    common.platformProject = path.normalize(common.platformProject + '/');
    common.generatePlatformProject = true;
}
if (common.generatePlatformProject === true)
    common.generatePlatformProject = common.targetPlatform === 'ios' || common.targetPlatform === 'android';

if (common.projectPath !== undefined) common.projectPath = path.normalize(common.projectPath + '/');
if (common.destDir !== undefined) common.destDir = path.normalize(common.destDir + '/');


// 程序是否运行在 windows 平台
common.isWindows = process.platform === 'win32';


// 工具箱根目录
common.rootDir = path.normalize(`${__dirname}/../`);
// 编译打包目录
common.buildDir = `${common.rootDir}build/`;
// 其他工具目录
common.toolsDir = `${common.rootDir}tools/`;
// 项目编译打包目录
common.projectBuildDir = `${common.buildDir}${common.projectName}/`;
// 日志目录
common.logDir = `${common.buildDir}log/${common.id}/`;
// 资源产出目录
common.resDir = `${common.projectBuildDir}res/${common.targetPlatform}/`;
// zip产出目录
common.zipDir = `${common.projectBuildDir}zip/${common.targetPlatform}/`;
// 版本资源清单目录
common.resManifestDir = `${common.resDir}manifest/`;
// 缓存目录
common.cacheDir = `${common.projectBuildDir}cache/`;
// lua 缓存目录
common.luaCacheDir = `${common.cacheDir}lua/`;
// 场景缓存目录
common.sceneCacheDir = `${common.cacheDir}scene/${common.targetPlatform}/`;
// AssetBundle 缓存目录
common.abCacheDir = `${common.cacheDir}assetbundle/${common.targetPlatform}/`;
// 平台项目根目录
common.platformDir = `${common.projectBuildDir}platform/`;
// 目标平台项目目录
if (common.platformProject !== undefined)
    common.targetPlatformDir = common.platformProject;
else
    common.targetPlatformDir = `${common.platformDir}${common.targetPlatform}/`;
// 临时产出的平台项目目录
common.tmpPlatformDir = `${common.platformDir}tmp/`;
// Android 平台的 Java 代码目录
common.androidJavaDir = `${common.rootDir}templates/java/`;


// lua 编码工具路径
switch (common.targetPlatform) {
    case 'ios':
    case 'windows':
        common.luajit = true;// jit
        common.luaEndcoder = common.isWindows
            ? `${common.toolsDir}luaEncoder/luajit/luajit.exe`
            : `${common.toolsDir}luaEncoder/luajit_mac/luajit`;
        break;
    case 'android':
        common.notEncode = true;// 目标 android lua jit 支持有问题
        break;
    case 'macos':
        common.luajit = false;// lua vm
        common.luaEndcoder = `${common.toolsDir}luaEncoder/luavm/luac`;
        break;
    default:
        throw Error('未知的目标平台: ' + common.targetPlatform);
}
// lua 编码工具所在目录路径
if (!common.notEncode)
    common.luaEndcoderDir = path.dirname(common.luaEndcoder);


// 版本号文件路径
common.versionFile = `${common.cacheDir}version.json`;
// 场景 MD5 信息文件路径
common.sceneMD5File = `${common.cacheDir}sceneMD5.json`;
// AssetBundle 依赖信息临时文件路径
common.abDependenciesFile = `${common.cacheDir}dependencies.json`;
// 日志文件路径
common.logFile = `${common.logDir}build.log`;
// 打包清单文件路径
common.manifestFile = `${common.logDir}manifest.log`;
// 打包进度文件路径
common.progressLogFile = `${common.logDir}progress.log`;
// unity 运行日志文件路径
common.unityLogFile = `${common.logDir}unity.log`;
// unity 输出文件路径（stdout 在 windows 下无法使用）
common.unityOutFile = `${common.logDir}unity.out`;
// 资源映射日志文件路径
common.resLogFile = `${common.logDir}res.log`;


// Unity 程序路径
common.unityPath = (common.isWindows ? config.winUnityPath : config.macUnityPath)
    .replace('[UnityVersion]', common.unityVersion);


// 生成4位版本号
let versionCache;
if (fs.existsSync(common.versionFile))
    versionCache = JSON.parse(fs.readFileSync(common.versionFile));
else
    versionCache = {};
if (versionCache[common.version3] === undefined)
    versionCache[common.version3] = 0;
common.version4 = `${common.version3}.${++versionCache[common.version3]}`;

// 版本资源清单文件
common.resManifestFile = `${common.resManifestDir}${common.version4}.manifest`;


// unity 项目路径
if (common.projectPath !== undefined)
    common.projectDir = common.projectPath;
// else
//     common.projectDir = '/Users/limylee/LOLO/unity/projects/ShibaInu/';


// 调用 Unity 程序命令行模版
common.unityCmd = `${common.unityPath} -batchmode -nographics -quit -projectPath ${common.projectDir} -logFile ${common.unityLogFile}`;


// Unity Library 目录，和 Library 缓存目录
common.libraryDir = `${common.projectDir}Library/`;
common.libraryCaheRootDir = `${common.cacheDir}library/`;
common.libraryCacheDir = `${common.libraryCaheRootDir}${common.targetPlatform}/`;
common.libraryNativeDir = `${common.libraryCaheRootDir}${common.isWindows ? 'windows' : 'macos'}/`;


//


//


/**
 * 结束进程
 * @param code
 */
common.exit = function (code) {
    let buildUnity = require('./buildUnity');
    buildUnity.cacheLibrary();

    let logger = require('./logger');
    let progress = require('./progress');
    logger.append('\n[PROGRESS]:', progress.getData());
    logger.append('\n[EXIT CODE]:', code);
    logger.updateNow();
    progress.status(code);

    process.exit(code);
    throw Error("Exit");// 需要抛错才能结束代码运行？
};


//


//


/**
 * 创建文件路径对应的所有层级的父目录
 * @param filePath
 */
common.createDir = function (filePath) {
    let sep = '/';
	filePath = filePath.replace(/\\/g, sep);
    let dirs = path.dirname(filePath).split(sep);
    let p = '';
    while (dirs.length) {
        p += dirs.shift() + sep;
        if (!fs.existsSync(p))
            fs.mkdirSync(p);
    }
};


/**
 * 删除目录，以及目录中所有的文件和子目录
 * @param dirPath
 */
common.removeDir = function (dirPath) {
    if (!fs.existsSync(dirPath)) return;

    let files = fs.readdirSync(dirPath);
    for (let i = 0; i < files.length; i++) {
        let filePath = path.join(dirPath, files[i]);
        if (fs.statSync(filePath).isDirectory()) {
            common.removeDir(filePath);
        } else {
            fs.unlinkSync(filePath);
        }
    }
    fs.rmdirSync(dirPath);
};


/**
 * 拷贝目录，包括文件和子目录
 * @param oldDir
 * @param newDir
 */
common.copyDir = function (oldDir, newDir) {
    let files = fs.readdirSync(oldDir);
    if (files.length === 0) return;
    if (!fs.existsSync(newDir)) fs.mkdirSync(newDir);
    for (let i = 0; i < files.length; i++) {
        let oldFile = path.join(oldDir, files[i]);
        let newFile = path.join(newDir, files[i]);
        if (fs.statSync(oldFile).isDirectory())
            common.copyDir(oldFile, newFile);
        else {
            if (!oldFile.endsWith('.DS_Store')
                && !oldFile.endsWith('.meta')
            ) fs.copyFileSync(oldFile, newFile);
        }
    }
};


/**
 * 合并两个目录
 * 更新有变化的文件，添加新增文件，源目录删除不存在的文件
 * @param srcDir 源目录
 * @param destDir 目标目录
 * @param callback 合并完成时的回调
 */
common.mergeDir = function (srcDir, destDir, callback) {
    // 目标目录不存在，直接改名移动
    if (!fs.existsSync(destDir)) {
        fs.renameSync(srcDir, destDir);
        callback();
        return;
    }

    // 删除目标目录内多余的文件以及子目录
    let destFiles = fs.readdirSync(destDir);
    for (let i = 0; i < destFiles.length; i++) {
        let fileName = destFiles[i];
        let srcFile = path.join(srcDir, fileName);
        // 源目录中已没有该文件，删除
        if (!fs.existsSync(srcFile)) {
            let destFile = path.join(destDir, fileName);
            if (fs.statSync(destFile).isDirectory())
                common.removeDir(destFile);
            else
                fs.unlinkSync(destFile);
        }
    }

    let srcFiles = fs.readdirSync(srcDir);
    let count = srcFiles.length;
    let index = -1;
    let next = () => {
        if (++index === count) {
            callback();
            return;
        }

        let fileName = srcFiles[index];
        let srcFile = path.join(srcDir, fileName);
        let destFile = path.join(destDir, fileName);
        // 目标目录中没有该文件，直接改名移动
        if (!fs.existsSync(destFile)) {
            fs.renameSync(srcFile, destFile);
            next();
        }
        else {
            if (fs.statSync(srcFile).isDirectory()) {
                common.mergeDir(srcFile, destFile, next);// 目录递归
            } else {
                // 更新内容有变化的文件
                common.getFileMD5(srcFile, (srcMD5) => {
                    common.getFileMD5(destFile, (destMD5) => {
                        if (srcMD5 !== destMD5)
                            fs.renameSync(srcFile, destFile);// 直接改名移动
                        next();
                    });
                });
            }
        }
    };
    next();
};


/**
 * 同步写入文件（并创建文件所在目录）
 * @param path 文件路径
 * @param data 文件数据
 */
common.writeFileSync = function (path, data) {
    common.createDir(path);
    fs.writeFileSync(path, data);
};


/**
 * 获取 字符串 或 buffer 的 md5
 * @param data
 */
common.getMD5 = function (data) {
    return crypto.createHash('md5').update(data).digest('hex');
};


/**
 * 异步获取文件 md5 和 文件数据
 * @param filePath
 * @param callback
 */
common.getFileMD5AndData = function (filePath, callback) {
    fs.readFile(filePath, (err, data) => {
        if (err) throw err;
        callback(common.getMD5(data), data);
    });
};


/**
 * 异步获取文件 md5
 * @param filePath
 * @param callback
 */
common.getFileMD5 = function (filePath, callback) {
    let hash = crypto.createHash('md5');
    let rs = fs.createReadStream(filePath);
    rs.on('data', (chunk) => {
        hash.update(chunk);
    });
    rs.on('end', () => {
        callback(hash.digest('hex'));
    });
};


/**
 * 同步获取文件 md5
 * @param filePath
 */
common.getFileMD5Sync = function (filePath) {
    return crypto.createHash('md5').update(fs.readFileSync(filePath)).digest('hex');
};


//


// 更新保存版本号缓存文件
common.writeFileSync(common.versionFile, JSON.stringify(versionCache, null, 2));