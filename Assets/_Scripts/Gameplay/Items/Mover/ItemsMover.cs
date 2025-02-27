using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Slots;
using _Scripts.Infrastructure.Services.Input;
using UnityEngine.EventSystems;

namespace _Scripts.Gameplay.Items.Mover
{
  public class ItemsMover : IItemsMover, IDisposable
  {
    private readonly IInputService _inputService;

    private SlotSettings _currentItem;
    private InventorySlot _currentSlot;

    public ItemsMover(IInputService inputService) => 
      _inputService = inputService;

    public void Enable()
    {
      _inputService.OnTouch += Drag;
      _inputService.OnEndTouch += Drop;
    }

    private void Drag()
    {
      if (!TryGetSlotUnderPointer(out InventorySlot slot)) 
        return;
      
      _currentItem = slot.SlotSettings;
      _currentSlot = slot;
    }

    private void Drop()
    {
      if (_currentSlot == null || _currentItem == null)
        return;

      if (!TryGetSlotUnderPointer(out InventorySlot newSlot)
          || !newSlot.TrySetItem(_currentItem.Item, _currentSlot.ItemType, _currentSlot.SubType, _currentItem.Count))
        return;
      
      _currentSlot.ClearItem();
      _currentSlot = null;
      _currentItem = null;
    }

    private bool TryGetSlotUnderPointer(out InventorySlot slot)
    {
      slot = null;

      PointerEventData eventData = new PointerEventData(EventSystem.current) 
        { position = _inputService.TouchPosition };
      List<RaycastResult> results = new List<RaycastResult>();
      EventSystem.current.RaycastAll(eventData, results);

      foreach (var result in results)
        if (result.gameObject.TryGetComponent(out slot))
          return true;

      return false;
    }

    public void Dispose()
    {
      _inputService.OnTouch -= Drag;
      _inputService.OnEndTouch -= Drop;
    }
  }
}