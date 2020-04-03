-- -----------------------------------------------------------------------------
-- Debug Mode class
-- -----------------------------------------------------------------------------
-- AUTHOR: Ben Argo
-- -----------------------------------------------------------------------------

DebugMode = {}
DebugMode.__index = DebugMode

function DebugMode:__construct()
    local obj = {}
    setmetatable(obj, DebugMode)
    return obj
end

function DebugMode:toggle()
    if self.enabled == false then
        self.enabled = true
        DEFAULT_CHAT_FRAME:AddMessage("|cfff8b700Stock Addon:|r Debug mode is now |cff00ff00enabled|r until you next log out.")
    else
        self.enabled = false
        DEFAULT_CHAT_FRAME:AddMessage("|cfff8b700Stock Addon:|r Debug mode is now |cffff0000disabled|r until you next log out.")
    end
end

-- Print a message if Debug mode is enabled...
function DebugMode:printLine(message)
    if self.enabled then
        self:message(message)
    end
end

-- Print a message, regardless of Debug mode...
function DebugMode:message(message)
    DEFAULT_CHAT_FRAME:AddMessage("|cfff8b700Stock Addon:|r " .. message)
end

Debug = DebugMode:__construct()
