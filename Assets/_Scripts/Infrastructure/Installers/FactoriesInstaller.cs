using _Scripts.Gameplay.Items.UISetter;
using _Scripts.Gameplay.Slots.SlotsFactory;
using _Scripts.Infrastructure.Services.Warmup;
using UnityEngine;
using VContainer;

namespace _Scripts.Infrastructure.Installers
{
  public class FactoriesInstaller : MonoInstaller
  {
    [SerializeField] private RectTransform _slotsContainer;
    
    public override void Register(IContainerBuilder builder)
    {
      builder.Register<ISlotsFactory, SlotsFactory>(Lifetime.Singleton).WithParameter(_slotsContainer).As<IWarmupable>();
    }
  }
}