using System;
using _Scripts.Data.Configs.Items.Items.Item;

namespace _Scripts.Gameplay.Items.UISetter
{
  public interface IItemsSetter
  {
    bool TrySetItem(ItemType itemType, Enum subType, ItemDataBase itemData, int count);
    bool TryRemoveItem(ItemType itemType, Enum subType, int count);
    bool TryRemoveStackItem(ItemType itemType, Enum subType);
  }
}