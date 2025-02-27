using System.Collections.Generic;
using _Scripts.Infrastructure.Services.Warmup;
using Cysharp.Threading.Tasks;

namespace _Scripts.Gameplay.Slots.SlotsFactory
{
  public interface ISlotsFactory : IWarmupable
  {
    List<InventorySlot> Slots { get; }
    UniTask CreateSlots(int count);
  }
}