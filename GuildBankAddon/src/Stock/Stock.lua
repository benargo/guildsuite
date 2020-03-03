-- -----------------------------------------------------------------------------
-- Stock Model
-- -----------------------------------------------------------------------------
-- AUTHOR: Ben Argo
-- -----------------------------------------------------------------------------

-- Create a Stock variable if it doesn't already exist...
Stock = {}
Stock.__index = Stock

-- Constructor
function Stock:__construct()
    local obj = {
        Bags = {},
        Mail = {},
    }
    setmetatable(obj, Stock)
    return obj
end

-- Create the bag object if it doesn't exist...
function Stock:CreateBagIfNotExist(BagNumber)
    if not Stock.Bags then
        Stock.Bags = {}
    end

    if not Stock.Bags[BagNumber] then
        Debug:printLine("Bag |cffe83e8c" .. BagNumber .. "|r object doesn't exist, creating it...")
        Stock.Bags[BagNumber] = {}
    end
end

function Stock:AddBagItem(BagNumber, SlotNumber, Item)
    BagNumber = tostring(BagNumber)
    SlotNumber = tostring(SlotNumber)

    -- Create the bag object if it doesn't exist...
    self:CreateBagIfNotExist(BagNumber)

    Stock.Bags[BagNumber][SlotNumber] = Item
end

function Stock:AddMailItem(MailNumber, SlotNumber, Item)
    MailNumber = tostring(MailNumber)
    SlotNumber = tostring(SlotNumber)

    -- Create the bag object if it doesn't exist...
    if not Stock.Mail[MailNumber] then Stock.Mail[MailNumber] = {} end

    Stock.Mail[MailNumber][SlotNumber] = Item
end

function Stock:RemoveBagItem(BagNumber, SlotNumber)
    BagNumber = tostring(BagNumber)
    SlotNumber = tostring(SlotNumber)

    -- Create the bag object if it doesn't exist...
    self:CreateBagIfNotExist(BagNumber)

    if Stock.Bags[BagNumber][SlotNumber] then
        Stock.Bags[BagNumber][SlotNumber] = {}
    end
end

function Stock:ReindexMailbox()
    Stock.Mail = {}
end

MyStock = Stock:__construct()
