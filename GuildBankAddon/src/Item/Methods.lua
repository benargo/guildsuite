-- -----------------------------------------------------------------------------
-- Useful item methods
-- -----------------------------------------------------------------------------
-- AUTHOR: Ben Argo
--         Alexander Tallund Klungerbo
-- -----------------------------------------------------------------------------

-- Search the provided item link for the item's name.
--
-- Param:  string  ItemLink
-- Return: string
--
function GetItemName(ItemLink)
    local _, _, ItemName = string.find(ItemLink, "%[(.+)%]")
    return ItemName
end

-- Search the provided item link for the items' ID number.
--
-- Param:  string   ItemLink
-- Return: integer
--
function GetItemId(ItemLink)
    local _,_,ItemId = string.find(ItemLink, "(item:%d+)")
    local _,_,ItemId = string.find(ItemLink, "item:(%d+)")
    return tonumber(ItemId)
end
