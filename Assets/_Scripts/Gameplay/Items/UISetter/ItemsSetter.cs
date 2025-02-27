using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Data.Configs.Items.Items.Item;
using _Scripts.Gameplay.Items.PlayerBackpack;
using _Scripts.Gameplay.Slots;
using _Scripts.Gameplay.Slots.SlotsFactory;
using UnityEngine;

namespace _Scripts.Gameplay.Items.UISetter
{
  public class ItemsSetter : IItemsSetter
  {
    private readonly IBackpack _backpack;
    private readonly ISlotsFactory _slotsFactory;

    public ItemsSetter(IBackpack backpack, ISlotsFactory slotsFactory)
    {
      _backpack = backpack;
      _slotsFactory = slotsFactory;
    }

    public bool TrySetItem(ItemType itemType, Enum subType, ItemDataBase itemData, int count)
    {
      if (!_backpack.TryAddItem(itemType, subType, count, itemData, out List<ItemStack> stacks))
        return false;

      var availableSlots = _slotsFactory.Slots
        .Where(x => !x.IsFullSlot && Equals(x.SubType, subType) && Equals(x.ItemType, itemType))
        .ToList();

      if (!availableSlots.Any())
      {
        availableSlots = _slotsFactory.Slots.Where(x => x.IsClearSlot).ToList();
        if (!availableSlots.Any())
          return false;
      }

      int currentItemCount = _slotsFactory.Slots
        .Where(x => Equals(x.SubType, subType) && Equals(x.ItemType, itemType))
        .Sum(x => x.SlotSettings.Count);

      int currentItemCountInStacks = stacks.Sum(x => x.Count);
      int maxAddable = currentItemCountInStacks - currentItemCount;

      foreach (var slot in availableSlots)
      {
        if (maxAddable <= 0)
          return true;

        int slotMaxAddable = itemData.Stack - slot.SlotSettings.Count;

        slot.TrySetItem(itemData, itemType, subType, Math.Min(maxAddable, slotMaxAddable));
        maxAddable -= slotMaxAddable;
      }

      if (maxAddable > 0)
      {
        availableSlots = _slotsFactory.Slots.Where(x => x.IsClearSlot).ToList();
        if (!availableSlots.Any())
          return false;

        foreach (var slot in availableSlots)
        {
          slot.TrySetItem(itemData, itemType, subType, Math.Min(maxAddable, itemData.Stack));
          maxAddable -= itemData.Stack;
          
          if (maxAddable < 0)
            return true;
        }
      }

      return true;
    }


    public bool TryRemoveItem(ItemType itemType, Enum subType, int count)
    {
      if (!_backpack.TryRemoveItemCount(itemType, subType, count, out List<ItemStack> stacks))
        return false;

      InventorySlot slot = _slotsFactory.Slots.FirstOrDefault(x =>
        !x.IsClearSlot && Equals(x.SubType, subType) && Equals(x.ItemType, itemType));

      if (slot == null)
        return true;

      if (stacks == null)
        slot.ClearItem();
      else
        foreach (var stack in stacks)
          slot.TrySetItem(stack.ItemData, itemType, subType, count);

      return false;
    }

    public bool TryRemoveStackItem(ItemType itemType, Enum subType)
    {
      if (!_backpack.TryRemoveStack(itemType, subType, 0))
        return false;

      InventorySlot slot = _slotsFactory.Slots.FirstOrDefault(x =>
        !x.IsClearSlot && Equals(x.SubType, subType) && Equals(x.ItemType, itemType));

      if (slot)
        slot.ClearItem();

      return true;
    }
  }
}