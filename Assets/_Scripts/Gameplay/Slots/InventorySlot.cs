using System;
using _Scripts.Data.Configs.Items.Items.Item;
using UnityEngine;

namespace _Scripts.Gameplay.Slots
{
  public class InventorySlot : MonoBehaviour
  {
    public event Action<SlotSettings> OnItemChanged;
    public event Action OnItemDeleted;

    // серелизуются ток для дебага
    [field: SerializeField] public SlotSettings SlotSettings { get; private set; }
    [field: SerializeField] public ItemType ItemType { get; private set; }
    [field: SerializeField] public Enum SubType { get; private set; }
    [field: SerializeField] public bool IsClearSlot { get; private set; } = true;
    [field: SerializeField] public bool IsFullSlot { get; private set; } = false;

    public bool TrySetItem(ItemDataBase itemData, ItemType itemType, Enum itemSubType, int count)
    {
      IsClearSlot = false;
      ItemType = itemType;
      SubType = itemSubType;
      SlotSettings.Item = itemData;
      SlotSettings.Count += count;
      SlotSettings.Weight += itemData.Weight * count;

      if (SlotSettings.Count >= itemData.Stack) 
        IsFullSlot = true;
      
      OnItemChanged?.Invoke(SlotSettings);
      return true;
    }

    public void ClearItem()
    {
      IsClearSlot = true;
      IsFullSlot = false;
      SlotSettings.Count = 0;
      SlotSettings.Weight = 0;
      SlotSettings.Item = null;
      ItemType = ItemType.Unknown;
      OnItemDeleted?.Invoke();
    }
  }

  [Serializable]
  public class SlotSettings
  {
    public ItemDataBase Item;
    public int Count;
    public float Weight;
  }
}