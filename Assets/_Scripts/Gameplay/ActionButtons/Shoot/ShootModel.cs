using System;
using _Scripts.Data.Configs.Items.Items.Item;
using _Scripts.Data.Configs.Items.Items.Weapons.Bullets;
using _Scripts.Gameplay.Items.UISetter;
using Random = UnityEngine.Random;

namespace _Scripts.Gameplay.ActionButtons.Shoot
{
  public class ShootModel : IShooter
  {
    private readonly IItemsSetter _itemsSetter;

    public ShootModel(IItemsSetter itemsSetter) =>
      _itemsSetter = itemsSetter;

    public void Shoot()
    {
      BulletsType type = (BulletsType)Random.Range(1, Enum.GetValues(typeof(BulletsType)).Length);
      
      switch (type)
      {
        case BulletsType.Pistol:
          _itemsSetter.TryRemoveItem(ItemType.Bullets, type, 1);
          break;
        
        case BulletsType.Rifle:
          _itemsSetter.TryRemoveItem(ItemType.Bullets, type, 1);
          break;
      }
    }
  }

  public interface IShooter
  {
    void Shoot();
  }
}