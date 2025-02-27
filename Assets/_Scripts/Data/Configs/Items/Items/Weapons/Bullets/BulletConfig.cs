using System;
using _Scripts.Data.Configs.Items.Items.Item;
using UnityEngine;

namespace _Scripts.Data.Configs.Items.Items.Weapons.Bullets
{
  [CreateAssetMenu(menuName = "Data/Configs/Items/BulletConfig", fileName = "BulletConfig")]
  public class BulletConfig : ItemConfig, IConfigWithSubType
  {
    [field: SerializeField] public ItemData<BulletsType> ItemData { get; private set; }
    public override Enum SubType => ItemData.SubType;
    public override ItemDataBase ItemDataBase => ItemData;
  }
}