using System.Collections.Generic;
using _Scripts.Infrastructure.Bootstrapper;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Infrastructure.Installers
{
  public class MainInstaller : LifetimeScope
  {
    [SerializeField] private List<MonoInstaller> _monoInstallers = new();
    
    protected override void Configure(IContainerBuilder builder)
    {
      foreach (var installer in _monoInstallers) 
        installer.Register(builder);

      builder.RegisterEntryPoint<MainBootstrapper>().AsSelf();
    }
  }

  public abstract class MonoInstaller : MonoBehaviour
  {
    public abstract void Register(IContainerBuilder builder);
  }
}