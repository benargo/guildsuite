-- -----------------------------------------------------------------------------
-- Item class
-- -----------------------------------------------------------------------------
-- PROPERTY: integer  id
-- PROPERTY: string   name
-- PROPERTY: integer  count  (1)   Default stack size is (1) and cannot be less than (1)
-- PROPERTY: string   link         Standard format of the item link is ""|cFFFFFFFF|Hitem:12345:0:0:0|h[Item Name]|h|r"
--                                 The item name can actually be extracted and is the first return value of GetItemInfo(itemLink)
--                                 Apparently, parsing itemLink to GetItemInfo works pretty poorly from what I've tested, but that might just be me who is retarded
-- PROPERTY: integer  bag    }     An item either has a bag or mail attribute, but never both.
-- PROPERTY: integer  mail   }
-- PROPERTY: integer  slot

-- -----------------------------------------------------------------------------
-- AUTHOR: Ben Argo
--         Alexander Tallund Klungerbo
-- -----------------------------------------------------------------------------

Item = {
    texture = nil -- has no effect, but required
}
Item.__index = Item

-- Master constructor
--
-- Return: Item
--
function Item:__construct()
    local self = {}
    setmetatable({}, Item)
    return self
end

-- Create new Item model by bag slot
--
-- Param:  Int  BagNumber
-- Param:  Int  SlotNumber
-- Return: Item
--
function Item:NewByBagSlot(BagNumber, SlotNumber)
    Debug:printLine("Creating a new Item model using the bag info...")

    -- Instantiate a new Item model...
    local self = Item:__construct()

    self.bag = BagNumber
    self.slot = SlotNumber
    self.banker_name = UnitName("player")

    -- Count the number of items in the stack...
    _, self.count = GetContainerItemInfo(BagNumber, SlotNumber)

    -- Populate the item information...
    if not ( self.count == nil ) then
        self.link = GetContainerItemLink(BagNumber, SlotNumber)
        self.id   = GetItemId(self.link)
        self.name = GetItemName(self.link)

        Debug:printLine("Returning Item object: " .. self.link)
    else
        Debug:printLine("Slot is empty, but as there was previously an item here this field should still be recorded.")
    end

    -- Return the new item...

    return self
end

-- Create new Item model by ID number
--
-- Param:  Int  ItemId
-- Return: Item
--
function Item:NewById(ItemId)
    Debug:printLine("Creating a new Item model using the ID number...")

    -- Instantiate a new Item model...
    local self = Item:__construct()

    -- Item information variables...
    local _,ItemLink = GetItemInfo(tonumber(ItemId))

    if ItemLink then
        self.id   = ItemId
        self.name = GetItemName(ItemLink)
        self.link = ItemLink

        -- Return the new item...
        Debug:printLine("Returning Item object: " .. ItemLink)
        return self
    end
end
