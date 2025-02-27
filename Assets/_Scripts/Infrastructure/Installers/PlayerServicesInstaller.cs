using _Scripts.Gameplay.ActionButtons.AddRandomItem;
using _Scripts.Gameplay.ActionButtons.Reload;
using _Scripts.Gameplay.ActionButtons.RemoveRandomItem;
using _Scripts.Gameplay.ActionButtons.Shoot;
using _Scripts.Gameplay.Items.PlayerBackpack;
using _Scripts.Gameplay.Items.UISetter;
using VContainer;

namespace _Scripts.Infrastructure.Installers
{
  public class PlayerServicesInstaller : MonoInstaller
  {
    public override void Register(IContainerBuilder builder)
    {
      builder.Register<IBackpack, Backpack>(Lifetime.Singleton);
      builder.Register<IItemsSetter, ItemsSetter>(Lifetime.Singleton);
      builder.Register<IShooter, ShootModel>(Lifetime.Singleton);
      builder.Register<IRandomItemRemover, RemoveItemModel>(Lifetime.Singleton);
      builder.Register<IAddItemModel, AddItemModel>(Lifetime.Singleton);
      builder.Register<IReloadModel, ReloadModel>(Lifetime.Singleton);
    }
  }
}