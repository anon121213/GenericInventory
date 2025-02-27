using System.Collections.Generic;
using System.Linq;
using _Scripts.Data.Configs.Items;
using _Scripts.Data.Configs.Slots;
using _Scripts.Infrastructure.Services.Data.AssetLoader;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Infrastructure.Services.Data.DataProvider
{
  public class StaticDataProvider : IStaticDataProvider
  {
    private const string Config = "Config";
    
    private readonly IAssetProvider _assetProvider;
    private List<ScriptableObject> _staticData;

    public StaticDataProvider(IAssetProvider assetProvider) => 
      _assetProvider = assetProvider;

    public async UniTask Warmup() => 
      _staticData = await _assetProvider.LoadAssetsByLabelAsync<ScriptableObject>(Config);

    public ItemsConfigs GetItemsConfigs() => 
      GetListDataOfType<ItemsConfigs>(_staticData).FirstOrDefault();

    public SlotConfig GetSlotConfig() =>
      GetListDataOfType<SlotConfig>(_staticData).FirstOrDefault();
    
    public InventoryConfig GetInventoryConfig() =>
      GetListDataOfType<InventoryConfig>(_staticData).FirstOrDefault();

    private TData GetFirstDataOfType<TData>(List<ScriptableObject> allData)
    {
      TData firstData = default(TData);

      foreach (ScriptableObject data in allData)
      {
        if (data is TData dataOfType)
        {
          firstData = dataOfType;
          break;
        }
      }

      return firstData;
    }

    private List<TData> GetListDataOfType<TData>(List<ScriptableObject> allData)
    {
      List<TData> listData = new List<TData>();

      foreach (ScriptableObject data in allData)
      {
        if (data is TData dataOfType)
          listData.Add(dataOfType);
      }

      return listData;
    }
  }
}