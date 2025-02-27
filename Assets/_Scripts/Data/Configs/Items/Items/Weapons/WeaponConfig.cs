using System;
using _Scripts.Data.Configs.Items.Items.Item;
using _Scripts.Data.Configs.Items.Items.Weapons.Bullets;
using UnityEngine;

namespace _Scripts.Data.Configs.Items.Items.Weapons
{
  [CreateAssetMenu(menuName = "Data/Configs/Items/WeaponConfig", fileName = "WeaponConfig")]
  public class WeaponConfig : ItemConfig
  {
    [field: SerializeField] public ItemData<WeaponType> ItemData { get; private set; }
    [field: SerializeField] public BulletConfig BulletConfig { get; private set; }
    public override Enum SubType => ItemData.SubType;
    public override ItemDataBase ItemDataBase => ItemData;
  }
}