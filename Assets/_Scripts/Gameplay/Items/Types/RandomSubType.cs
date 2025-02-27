using System;
using _Scripts.Data.Configs.Items;
using _Scripts.Data.Configs.Items.Items.Gear;
using _Scripts.Data.Configs.Items.Items.Item;
using _Scripts.Data.Configs.Items.Items.Weapons;
using _Scripts.Data.Configs.Items.Items.Weapons.Bullets;
using Random = UnityEngine.Random;

namespace _Scripts.Gameplay.Items.Types
{
  public static class RandomSubType
  {
    public static Enum GetRandomSubType(ItemType type)
    {
      switch (type)
      {
        case ItemType.Weapon:
          return (WeaponType)Random.Range(1, Enum.GetValues(typeof(WeaponType)).Length);
        
        case ItemType.Bullets:
          return (BulletsType)Random.Range(1, Enum.GetValues(typeof(BulletsType)).Length);
        
        case ItemType.Gear:
          return (GearType)Random.Range(1, Enum.GetValues(typeof(GearType)).Length);
      }

      return null;
    }
  }
}