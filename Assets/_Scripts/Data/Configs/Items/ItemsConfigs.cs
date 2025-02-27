using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Data.Configs.Items.Items.Gear;
using _Scripts.Data.Configs.Items.Items.Item;
using _Scripts.Data.Configs.Items.Items.Weapons;
using _Scripts.Data.Configs.Items.Items.Weapons.Bullets;
using UnityEngine;

namespace _Scripts.Data.Configs.Items
{
  [CreateAssetMenu(menuName = "Data/Configs/Items/ItemsConfigs", fileName = "ItemsConfigs")]
  public class ItemsConfigs : ScriptableObject
  {
    [field: SerializeField] public List<GearConfig> Gears { get; private set; } = new();
    [field: SerializeField] public List<WeaponConfig> Weapons { get; private set; } = new();
    [field: SerializeField] public List<BulletConfig> Bullets { get; private set; } = new();

    public IConfigWithSubType GetItemConfig(ItemType itemType, Enum itemSubType)
    {
      var config = Weapons.FirstOrDefault(x => x.ItemData.ItemType == itemType && Equals(x.SubType, itemSubType)) as IConfigWithSubType ??
                   Bullets.FirstOrDefault(x => x.ItemData.ItemType == itemType && Equals(x.SubType, itemSubType)) as IConfigWithSubType ??
                   Gears.FirstOrDefault(x => x.ItemData.ItemType == itemType && Equals(x.SubType, itemSubType)) as IConfigWithSubType;

      return config;
    }
  }
  
  public interface IConfigWithSubType
  {
    Enum SubType { get; }
    ItemDataBase ItemDataBase { get; }
  }
}