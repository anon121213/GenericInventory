using System.Collections.Generic;
using _Scripts.Gameplay.Slots.SlotsFactory;
using _Scripts.Infrastructure.Services.Data.DataProvider;
using Cysharp.Threading.Tasks;

namespace _Scripts.Infrastructure.Services.Warmup
{
  public class WarmupService : IWarmupService
  {
    private readonly List<IWarmupable> _warmupables = new();

    public WarmupService(IStaticDataProvider staticDataProvider,
      ISlotsFactory slotsFactory)
    {
      _warmupables.Add(staticDataProvider);
      _warmupables.Add(slotsFactory);
    }

    public async UniTask Warmup()
    {
      foreach (var warmupable in _warmupables) 
        await warmupable.Warmup();
    }
  }

  public interface IWarmupable
  {
    UniTask Warmup();
  }
}