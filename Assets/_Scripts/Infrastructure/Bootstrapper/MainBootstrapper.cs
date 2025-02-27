using _Scripts.Gameplay.Items.Mover;
using _Scripts.Gameplay.Items.UISetter;
using _Scripts.Gameplay.Slots.SlotsFactory;
using _Scripts.Infrastructure.Services.Data.AssetLoader;
using _Scripts.Infrastructure.Services.Data.DataProvider;
using _Scripts.Infrastructure.Services.Scenes;
using _Scripts.Infrastructure.Services.Warmup;
using UnityEngine;
using VContainer.Unity;

namespace _Scripts.Infrastructure.Bootstrapper
{
  public class MainBootstrapper : IInitializable
  {
    private const int FRAMERATE = 240;

    private readonly ISceneLoader _sceneLoader;
    private readonly IWarmupService _warmupService;
    private readonly IItemsMover _itemsMover;
    private readonly ISlotsFactory _slotsFactory;
    private readonly IItemsSetter _itemsSetter;
    private readonly IStaticDataProvider _staticDataProvider;
    private readonly IAssetProvider _assetProvider;

    public MainBootstrapper(ISceneLoader sceneLoader,
      IWarmupService warmupService,
      IItemsMover itemsMover,
      ISlotsFactory slotsFactory,
      IItemsSetter itemsSetter,
      IStaticDataProvider staticDataProvider,
      IAssetProvider assetProvider)
    {
      _sceneLoader = sceneLoader;
      _warmupService = warmupService;
      _itemsMover = itemsMover;
      _slotsFactory = slotsFactory;
      _itemsSetter = itemsSetter;
      _staticDataProvider = staticDataProvider;
      _assetProvider = assetProvider;
    }

    public async void Initialize()
    {
      Application.targetFrameRate = FRAMERATE;
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
      
      await _warmupService.Warmup();
      await _sceneLoader.Load(SceneNamesConstants.GameScene);
      await _slotsFactory.CreateSlots(_staticDataProvider.GetInventoryConfig().InventorySlots);
      
      // вместо этой фигни тут должно быть чо то типо SaveService.Load();
      CreateItems();      
      
      _itemsMover.Enable();  
      _assetProvider.Cleanup();
    }

    private void CreateItems()
    {
      var configs = _staticDataProvider.GetItemsConfigs();

      foreach (var config in configs.Bullets)
        _itemsSetter.TrySetItem(config.ItemData.ItemType, config.ItemData.SubType, config.ItemData, 1); 
      
      foreach (var config in configs.Weapons) 
        _itemsSetter.TrySetItem(config.ItemData.ItemType, config.ItemData.SubType, config.ItemData, 1);
      
      foreach (var config in configs.Gears) 
        _itemsSetter.TrySetItem(config.ItemData.ItemType, config.ItemData.SubType, config.ItemData, 1);
    }
  }
}