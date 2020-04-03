-- -----------------------------------------------------------------------------
-- Interface Options
-- -----------------------------------------------------------------------------
-- AUTHOR: Ben Argo
-- -----------------------------------------------------------------------------

InterfaceOptions = {}
InterfaceOptions.__index = InterfaceOptions

-- Constructor
function InterfaceOptions:__construct()
    local obj = {}
    setmetatable(obj, InterfaceOptions)
    return obj
end

-- Build the Interface Frame
function InterfaceOptions:CreateOptionsPanel()
    local InterfaceFrame = CreateFrame("Frame")

    -- Set the interface panel name, as appears in the menu...
    InterfaceFrame.name = "Guild Bank"

    -- Title...
    InterfaceFrame.titleText = self:TextFactory(InterfaceFrame, "Guild Bank", 16)
    InterfaceFrame.titleText:SetPoint("TOPLEFT", 15, -15)
    InterfaceFrame.titleText:SetTextColor(1, 0.9, 0, 1)

    -- Introduction...
    InterfaceFrame.introductionText = self:TextFactory(InterfaceFrame, "These settings control the addon needed to profile the guild bank for The Order.", 10)
    InterfaceFrame.introductionText:SetPoint("TOPLEFT", 15, -40)

    -- Enable Profiling Checkbox...
    InterfaceFrame.enableProfilingCheckbox = self:CheckboxFactory(InterfaceFrame, " Enable Profiling", "Toggle profiling of this character's bags and bank.", function (self)
        InterfaceOptions.enableProfiling = self:GetChecked()
    end)
    InterfaceFrame.enableProfilingCheckbox:SetPoint("TOPLEFT", 15, -55)

    -- Enable Debug Mode...
    InterfaceFrame.enableDebugModeCheckbox = self:CheckboxFactory(InterfaceFrame, " Enable Debug Mode", "Toggle the debug mode. This prints a lot of extra information to the main chat window.", function (self)
        InterfaceOptions.enableDebugMode = self:GetChecked()
    end)
    InterfaceFrame.enableDebugModeCheckbox:SetPoint("TOPLEFT", 15, -80)

    return InterfaceFrame
end

-- Create text with the specified size and value
function InterfaceOptions:TextFactory(parent, value, size)
    local text = parent:CreateFontString(nil, "ARTWORK")
    text:SetFont("Fonts/FRIZQT__.ttf", size)
    text:SetJustifyV("CENTER")
    text:SetJustifyH("CENTER")
    text:SetText(value)
    return text
end

-- Create a checkbox with the specified size and value
function InterfaceOptions:CheckboxFactory(parent, name, description, onClick)
    local checkbox = CreateFrame("CheckButton", name, parent, "ChatConfigCheckButtonTemplate")
    getglobal(checkbox:GetName() .. "Text"):SetText(name)
    checkbox.tooltip = description
    checkbox:SetScript("OnClick", function(self)
        onClick(self)
    end)
    checkbox:SetScale(1.0)
    return checkbox
end

-- Create the master Options object...
if not Options then Options = InterfaceOptions:__construct() end

InterfaceFrame = InterfaceOptions:CreateOptionsPanel()
InterfaceFrame:RegisterEvent("ADDON_LOADED")

InterfaceFrame:SetScript("OnEvent", function(self, event, arg1)
    if event == "ADDON_LOADED" and arg1 == "OrderStock" then
        local DefaultInterfaceOptions = {
            enableProfiling = false,
            enableDebugMode = false,
        }

        -- load in the default options if required...
        for key, val in pairs(DefaultInterfaceOptions) do
            if InterfaceOptions[key] == nil then
                InterfaceOptions[key] = val
            end
        end

        Debug:printLine("Enable Profiling: " .. tostring(InterfaceOptions.enableProfiling))
        InterfaceFrame.enableProfilingCheckbox:SetChecked(InterfaceOptions.enableProfiling)

        Debug:printLine("Enable Debug Mode: " .. tostring(InterfaceOptions.enableDebugMode))
        InterfaceFrame.enableDebugModeCheckbox:SetChecked(InterfaceOptions.enableDebugMode)
        DebugMode.enabled = InterfaceOptions.enableDebugMode
    end
end)

InterfaceOptions_AddCategory(InterfaceFrame)
