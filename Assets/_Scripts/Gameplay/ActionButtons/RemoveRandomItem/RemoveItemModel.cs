using System;
using _Scripts.Data.Configs.Items;
using _Scripts.Data.Configs.Items.Items.Item;
using _Scripts.Gameplay.Items.Types;
using _Scripts.Gameplay.Items.UISetter;
using _Scripts.Infrastructure.Services.Data.DataProvider;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Gameplay.ActionButtons.RemoveRandomItem
{
  public class RemoveItemModel : IRandomItemRemover
  {
    private readonly IItemsSetter _itemsSetter;
    private readonly IStaticDataProvider _staticDataProvider;

    public RemoveItemModel(IItemsSetter itemsSetter, 
      IStaticDataProvider staticDataProvider)
    {
      _itemsSetter = itemsSetter;
      _staticDataProvider = staticDataProvider;
    }
    
    public void RemoveItem()
    {
      ItemType type = (ItemType)Random.Range(1, Enum.GetValues(typeof(ItemType)).Length);
      IConfigWithSubType config = _staticDataProvider.GetItemsConfigs()
        .GetItemConfig(type, RandomSubType.GetRandomSubType(type));

      if (config != null)
        _itemsSetter.TryRemoveStackItem(type, config.SubType);
      else
        Debug.LogError("Unknown item config type.");
    }
  }

  public interface IRandomItemRemover
  {
    void RemoveItem();
  }
}