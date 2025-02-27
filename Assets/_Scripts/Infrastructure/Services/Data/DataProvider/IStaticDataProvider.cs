using _Scripts.Data.Configs.Items;
using _Scripts.Data.Configs.Slots;
using _Scripts.Infrastructure.Services.Warmup;

namespace _Scripts.Infrastructure.Services.Data.DataProvider
{
  public interface IStaticDataProvider : IWarmupable
  {
    ItemsConfigs GetItemsConfigs();
    SlotConfig GetSlotConfig();
    InventoryConfig GetInventoryConfig();
  }
}