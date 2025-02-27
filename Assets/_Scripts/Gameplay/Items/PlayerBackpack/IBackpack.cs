using System;
using System.Collections.Generic;
using _Scripts.Data.Configs.Items.Items.Item;

namespace _Scripts.Gameplay.Items.PlayerBackpack
{
  public interface IBackpack 
  {
    bool TryAddItem<T>(ItemType type, T subType, int count, ItemDataBase itemData, out List<ItemStack> stacks)
      where T : Enum;
    bool TryRemoveItemCount<T>(ItemType type, T subType, int count, out List<ItemStack> stacks) where T : Enum;
    bool TryGetItemCount<T>(ItemType type, T subType, out int totalCount) where T : Enum;
    bool TryRemoveStack<T>(ItemType type, T subType, int stackIndex) where T : Enum;
  }
}