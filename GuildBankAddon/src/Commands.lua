-- -----------------------------------------------------------------------------
-- Slash commands for use in-game
-- -----------------------------------------------------------------------------
-- AUTHOR: Ben Argo
-- AUTHOR: Alexander Tallund Klungerbo
-- -----------------------------------------------------------------------------

-- -----------------------------------------------------------------------------
-- Stock commands
--
-- The master command that has lots of different options available to use.
-- -----------------------------------------------------------------------------
SLASH_STOCKDEBUGMODE1 = "/stock";
SlashCmdList["STOCKDEBUGMODE"] = function(arg)
    local _,_,opt = string.find(arg,"(%l+)");

    if opt == "debug" then
        Debug:toggle()
    elseif opt == "eventadd" then
        local _,_,_,mode = string.find(arg,"(%l+)%s(.+)");
        DEFAULT_CHAT_FRAME:AddMessage("Dropped in...");
        local testFrame = CreateFrame("Frame");
        testFrame:RegisterEvent("BAG_UPDATE");
        testFrame:SetScript("OnEvent", function (callbackFrame, event, ...)
            DEFAULT_CHAT_FRAME:AddMessage("StockEvent called " .. event);
        end);
        DEFAULT_CHAT_FRAME:AddMessage("Leaving...");
    elseif opt == "itemlinktest" then
        Debug:printLine("Testing constructor for itemLinks!");
        local testLink = "|cffffffff|Hitem:6948::::::::39:::::::|h[Hearthstone]|h|r";
        Debug:printLine("Local item link made ...");
        local testItem = Item:newByLink(testLink);
        Debug:printLine("Test item name : " .. testItem:name());
    end -- if
end -- command

-- -----------------------------------------------------------------------------
-- ReloadUI shortcut
--
-- This function provides an easy shortcut to reloading the UI.
-- -----------------------------------------------------------------------------
SLASH_RELOADUICIRCLE1 = "/rui";
SlashCmdList["RELOADUICIRCLE"] = function()
    ReloadUI();
end -- command
