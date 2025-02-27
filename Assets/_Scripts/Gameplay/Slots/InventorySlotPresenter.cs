using UnityEngine;

namespace _Scripts.Gameplay.Slots
{
  public class InventorySlotPresenter : MonoBehaviour
  {
    [SerializeField] private InventorySlotView _inventorySlotView;
    [SerializeField] private InventorySlot inventorySlot;

    private void OnEnable()
    {
      inventorySlot.OnItemChanged += SetItem;
      inventorySlot.OnItemDeleted += ClearSlot;
    }

    private void SetItem(SlotSettings itemData)
    {
      _inventorySlotView.SetIcon(itemData.Item.Icon);
      _inventorySlotView.SetWeight(itemData.Weight);
      _inventorySlotView.SetCount(itemData.Count, itemData.Item.Stack);
    }

    private void ClearSlot()
    {
      _inventorySlotView.SetIcon(null);
      _inventorySlotView.SetWeight(0);
      _inventorySlotView.SetCount(0, 0);
    }

    private void OnDisable()
    {
      inventorySlot.OnItemChanged -= SetItem;
      inventorySlot.OnItemDeleted -= ClearSlot;
    }
  }
}