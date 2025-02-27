using System;
using _Scripts.Data.Configs.Items;
using _Scripts.Data.Configs.Items.Items.Item;
using _Scripts.Data.Configs.Items.Items.Weapons;
using _Scripts.Data.Configs.Items.Items.Weapons.Bullets;
using _Scripts.Gameplay.Items.UISetter;
using _Scripts.Infrastructure.Services.Data.DataProvider;
using Random = UnityEngine.Random;

namespace _Scripts.Gameplay.ActionButtons.Reload
{
  public class ReloadModel : IReloadModel
  {
    private readonly IItemsSetter _itemsSetter;
    private readonly IStaticDataProvider _staticDataProvider;

    public ReloadModel(IItemsSetter itemsSetter,
      IStaticDataProvider staticDataProvider)
    {
      _itemsSetter = itemsSetter;
      _staticDataProvider = staticDataProvider;
    }
    
    public void Reload()
    {
      BulletsType type = (BulletsType)Random.Range(1, Enum.GetValues(typeof(BulletsType)).Length);

      IConfigWithSubType config;
        
      switch (type)
      {
        case BulletsType.Pistol:
          config = _staticDataProvider.GetItemsConfigs().GetItemConfig(ItemType.Bullets, BulletsType.Pistol);
          _itemsSetter.TrySetItem(ItemType.Bullets, config.SubType, config.ItemDataBase, config.ItemDataBase.Stack);
          break;
        
        case BulletsType.Rifle:
          config = _staticDataProvider.GetItemsConfigs().GetItemConfig(ItemType.Bullets, BulletsType.Rifle);
          _itemsSetter.TrySetItem(ItemType.Bullets, config.SubType, config.ItemDataBase, config.ItemDataBase.Stack);
          break;
      }
    }
  }

  public interface IReloadModel
  {
    void Reload();
  }
}