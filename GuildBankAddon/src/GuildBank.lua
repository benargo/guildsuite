-- -----------------------------------------------------------------------------
-- Frame used for the Guild Bank addon
-- -----------------------------------------------------------------------------
-- AUTHOR: Ben Argo
-- AUTHOR: Alexander Tallund Klungerbo
-- -----------------------------------------------------------------------------

GuildBank = CreateFrame("Frame")

-- Class parameters...
GuildBank.BankIsOpen = false
GuildBank.MailIsOpen = false
GuildBank.InventoryIsEmpty = true
if not Stock then Stock = {} end

-- Register the events...
GuildBank:RegisterEvent("ADDON_LOADED")
GuildBank:RegisterEvent("BANKFRAME_CLOSED")
GuildBank:RegisterEvent("BANKFRAME_OPENED")
GuildBank:RegisterEvent("MAIL_CLOSED")
GuildBank:RegisterEvent("MAIL_INBOX_UPDATE")
GuildBank:RegisterEvent("MAIL_SEND_SUCCESS")
GuildBank:RegisterEvent("PLAYER_LOGIN")
GuildBank:RegisterEvent("PLAYER_LOGOUT")

-- Handle events...
GuildBank:SetScript("OnEvent", function(self, event, arg1)
    -- Event: ADDON_LOADED
    if event == "ADDON_LOADED" and arg1 == "OrderStock" then
        Debug:printLine("|cffe83e8c<event>|r ADDON_LOADED")
    -- Event: BANKFRAME_CLOSED
    elseif event == "BANKFRAME_CLOSED" then
        Debug:printLine("|cffe83e8c<event>|r BANKFRAME_CLOSED")

        -- Only run the function if the bank frame is still open...
        if GuildBank.BankIsOpen == true then
            GuildBank:UpdateStock(true)
        end

        GuildBank.BankIsOpen = false
    -- Event: BANKFRAME_OPENED
    elseif event == "BANKFRAME_OPENED" then
        Debug:printLine("|cffe83e8c<event>|r BANKFRAME_OPENED")
        GuildBank.BankIsOpen = true
    -- Event: MAIL_CLOSED
    elseif event == "MAIL_CLOSED" then
        Debug:printLine("|cffe83e8c<event>|r MAIL_CLOSED")
        GuildBank:UpdateStock(false)
    -- Event: MAIL_INBOX_UPDATE
    elseif event == "MAIL_INBOX_UPDATE" then
        Debug:printLine("|cffe83e8c<event>|r MAIL_INBOX_UPDATE")
        GuildBank:CheckMail()
    -- Event: MAIL_SEND_SUCCESS
    elseif event == "MAIL_SEND_SUCCESS" then
        Debug:printLine("|cffe83e8c<event>|r MAIL_SEND_SUCCESS")
        GuildBank:UpdateStock(false)
    -- Event: PLAYER_LOGIN
    elseif event == "PLAYER_LOGIN" then
        Debug:printLine("|cffe83e8c<event>|r PLAYER_LOGIN")
        GuildBank:UpdateStock(false)
    -- Event: PLAYER_LOGOUT
    elseif event == "PLAYER_LOGOUT" then
        Debug:printLine("|cffe83e8c<event>|r PLAYER_LOGOUT")
        GuildBank:UpdateStock(false)
    end
end)

function GuildBank:CheckMail()
    local NumMails, TotalMails = GetInboxNumItems()
    local MailboxSlot = 1

    if ( TotalMails > NumMails ) then
        -- Send this message regardless...
        local NumToRemove = TotalMails - NumMails
        Debug:message("Total number of mailbox items exceeds those currently displayed. Please remove ".. tostring(NumToRemove) .. " items before continuing")

        -- Cancel any further execution...
        return
    end

    -- Reset the Mailbox index...
    MyStock:ReindexMailbox()

    -- loop through the current mailbox items...
    for MailboxIndex = 1, NumMails do
        local _,_,_,_,_,_,_,hasItem = GetInboxHeaderInfo(MailboxIndex)

        if hasItem then
            for ItemIndex = 1, hasItem do
                Debug:printLine("Parsing mailbox index |cffe83e8c".. tostring(MailboxIndex) .."|r, item index |cffe83e8c".. tostring(ItemIndex) .."|r.")
                local _,ItemId,_,ItemCount = GetInboxItem(MailboxIndex, ItemIndex)

                if ItemCount then
                    local CurrentItem = Item:NewById(ItemId)

                    -- Set the stack size of the current item...
                    CurrentItem.count = ItemCount
                    CurrentItem.mail  = MailboxIndex
                    CurrentItem.slot  = ItemIndex

                    -- Insert Item model into table of items...
                    MyStock:AddMailItem(MailboxIndex, ItemIndex, CurrentItem)
                    Debug:printLine("|cff00ff00Item inserted!|r")

                    -- Increment the MailboxSlot variable...
                    MailboxSlot = MailboxSlot + 1
                end
            end
        end
    end
end

-- Update the current stock array...
function GuildBank:UpdateStock()
    if InterfaceOptions.enableProfiling then
        Debug:printLine("Updating current stock...")
        Debug:printLine("BankIsOpen = " .. tostring(self.BankIsOpen))

        MinBagNumber = 0
        MaxBagNumber = 4

        -- If the bank is open then increase the range of the bag numbers...
        if self.BankIsOpen then
            MinBagNumber = -1
            MaxBagNumber = 11
        end

        Debug:printLine("MinBagNumber = " .. tostring(MinBagNumber))
        Debug:printLine("MaxBagNumber = " .. tostring(MaxBagNumber))

        -- Iterate through each bag...
        for BagNumber = MinBagNumber, MaxBagNumber do
            Debug:printLine("Searching bag number |cffe83e8c" .. tostring(BagNumber) .. "|r")

            -- Iterate through the bag slots...
            for BagSlot = 1, GetContainerNumSlots(BagNumber) do
                Debug:printLine("Checking item in bag number |cffe83e8c" .. tostring(BagNumber) .. "|r and slot number |cffe83e8c" .. tostring(BagSlot) .. "|r")

                -- If the slot is occupied, get information about the item...
                if (GetContainerItemLink(BagNumber, BagSlot)) then

                    -- The inventory is definitely not empty...
                    if self.InventoryIsEmpty == true then
                        Debug:printLine('Marking the inventory as not empty')
                        self.InventoryIsEmpty = false
                    end

                    -- Fetch the current item...
                    local CurrentItem = Item:NewByBagSlot(BagNumber, BagSlot)

                    -- Insert Item model into table of items...
                    MyStock:AddBagItem(BagNumber, BagSlot, CurrentItem)
                    Debug:printLine("|cff00ff00Item inserted!|r")
                -- Remove the current saved value from the bag...
                else
                    Debug:printLine("Stot is empty, removed item from the local database")
                    MyStock:RemoveBagItem(BagNumber, BagSlot)
                end
            end
        end

        Debug:printLine("Updating current bank stock... |cff00ff00complete!|r")
    end
end
