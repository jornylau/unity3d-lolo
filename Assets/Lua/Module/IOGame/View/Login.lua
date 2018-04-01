--
-- 登录界面
-- 2018/3/5
-- Author LOLO
--


local floor = math.floor
local max = math.max

local IOGameData = require("Module.IOGame.Model.IOGameData") ---@type IOGame.IOGameData
local commands = require("Module.IOGame.Controller.commands")

---@class IOGame.Login : View
---@field New fun():IOGame.Login
---
---@field protected _serverText UnityEngine.UI.InputField
---@field protected _portText UnityEngine.UI.InputField
---@field protected _nameText UnityEngine.UI.InputField
---
local Login = class("IOGame.Login", View)

---@param go UnityEngine.GameObject
function Login:Ctor(go)
    Login.super.Ctor(self)

    local tra = go.transform
    self._serverText = GetComponent.InputField(tra:Find("serverText").gameObject)
    self._portText = GetComponent.InputField(tra:Find("portText").gameObject)
    self._nameText = GetComponent.InputField(tra:Find("nameText").gameObject)

    local name = PlayerPrefs.GetString("login.name")
    if name == "" then
        name = "player" .. math.floor(math.random(90) + 10)
    end
    self._nameText.text = name

    local server = PlayerPrefs.GetString("login.server")
    if server == "" then
        server = "10.8.5.128"
    end
    self._serverText.text = server

    local port = PlayerPrefs.GetString("login.port")
    if port == "" then
        port = "9000"
    end
    self._portText.text = port

    local enterBtn = tra:Find("enterBtn").gameObject
    AddEventListener(enterBtn, PointerEvent.CLICK, self.OnClick_enterBtn, self)

    self.gameObject = go
    self:OnInitialize()


    -- 预加载资源
    for i = 1, 12 do
        Res.LoadAssetAsync("Prefabs/IOGame/dwarfs/dwarf_" .. i .. ".prefab", self.moduleName) -- 角色
        if i < 4 then
            Res.LoadAssetAsync("Prefabs/IOGame/fire/fire" .. i .. ".prefab", self.moduleName) -- 特效
        end
    end
end


--


local socket = IOGameData.socket

function Login:OnClick_enterBtn(event)
    local name = self._nameText.text
    local server = self._serverText.text
    local port = tonumber(self._portText.text)
    if Validator.notExactlySpace(name) and Validator.notExactlySpace(server) and port > 0 then
        PlayerPrefs.SetString("login.name", name)
        PlayerPrefs.SetString("login.server", server)
        PlayerPrefs.SetString("login.port", port)

        IOGameData.playerName = name
        socket:AddEventListener(SocketEvent.CONNECTED, self.SocketConnectHandler, self)
        socket:AddEventListener(SocketEvent.CONNECT_FAIL, self.SocketConnectHandler, self)
        socket:Content(server, port)
    end
end

--


local lastFrameTime, frameNum

function Login:SocketConnectHandler(event)
    socket:RemoveEventListener(SocketEvent.CONNECTED, self.SocketConnectHandler, self)
    socket:RemoveEventListener(SocketEvent.CONNECT_FAIL, self.SocketConnectHandler, self)
    print(event.type)

    if event.type == SocketEvent.CONNECTED then
        socket:AddEventListener(SocketEvent.DISCONNECT, self.SocketDisonnectHandler, self)
        socket:AddEventListener(SocketEvent.MESSAGE, self.SocketMessageHandler, self)

        socket:Send(JSON.stringify({
            cmd = "enter",
            name = IOGameData.playerName,
            pic = math.floor(math.random(12))
        }))
        lastFrameTime = TimeUtil.time
        frameNum = 0

        Stats.Show()
        self:Hide()
    end
end

function Login:SocketDisonnectHandler(event)
    socket:RemoveEventListener(SocketEvent.DISCONNECT, self.SocketDisonnectHandler, self)
    socket:RemoveEventListener(SocketEvent.MESSAGE, self.SocketMessageHandler, self)
    print(event.type, event.data)
end

function Login:SocketMessageHandler(event)
    --print(event.type, event.data)
    local data = JSON.parse(event.data)
    local cmd = data.cmd
    if cmd == nil then
        IOGameData.frame:AppendFrameData(data)

        -- 统计网络延时
        frameNum = frameNum + 1
        if frameNum == 20 then
            local time = TimeUtil.time
            Stats.netDelay = max(0, floor((time - lastFrameTime - 0.9) / 20 * 1000 + 0.5)) -- [ 0.9m = 45ms * 20frame ]
            lastFrameTime = time
            frameNum = 0
        end
    else
        commands[cmd](data)
    end
end



--

return Login