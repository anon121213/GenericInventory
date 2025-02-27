using System.Collections.Generic;
using _Scripts.Infrastructure.Services.Data.AssetLoader;
using _Scripts.Infrastructure.Services.Data.DataProvider;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Gameplay.Slots.SlotsFactory
{
  public class SlotsFactory : ISlotsFactory
  {
    public List<InventorySlot> Slots { get; } = new();

    private readonly IStaticDataProvider _staticDataProvider;
    private readonly IAssetProvider _assetProvider;
    private readonly RectTransform _rectTransform;
    private readonly IObjectResolver _objectResolver;

    public SlotsFactory(IStaticDataProvider staticDataProvider,
      IAssetProvider assetProvider,
      RectTransform rectTransform,
      IObjectResolver objectResolver)
    {
      _staticDataProvider = staticDataProvider;
      _assetProvider = assetProvider;
      _rectTransform = rectTransform;
      _objectResolver = objectResolver;
    }

    public async UniTask Warmup() => 
      await _assetProvider.LoadAssetAsync(_staticDataProvider.GetSlotConfig().Prefab);

    public async UniTask CreateSlots(int count)
    {
      InventorySlot prefab =  await _assetProvider.LoadAssetAsync<InventorySlot>(_staticDataProvider.GetSlotConfig().Prefab);

      for (int i = 0; i < count; i++)
      {
        InventorySlot gameObject = _objectResolver.Instantiate(prefab, _rectTransform);
        Slots.Add(gameObject);
      }
    }
  }
}