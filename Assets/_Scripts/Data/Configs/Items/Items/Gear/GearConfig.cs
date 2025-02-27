using System;
using _Scripts.Data.Configs.Items.Items.Item;
using UnityEngine;

namespace _Scripts.Data.Configs.Items.Items.Gear
{
  [CreateAssetMenu(menuName = "Data/Configs/Items/GearConfig", fileName = "GearConfig")]
  public class GearConfig : ItemConfig
  {
    [field: SerializeField] public ItemData<GearType> ItemData { get; private set; }
    public override Enum SubType => ItemData.SubType;
    public override ItemDataBase ItemDataBase => ItemData;
  }
}