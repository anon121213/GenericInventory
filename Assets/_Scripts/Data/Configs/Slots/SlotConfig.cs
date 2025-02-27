using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Scripts.Data.Configs.Slots
{
  [CreateAssetMenu(menuName = "Data/Configs/Slots/SlotConfig", fileName = "SlotConfig")]
  public class SlotConfig : ScriptableObject
  {
    [field: SerializeField] public AssetReferenceGameObject Prefab { get; private set; } 
  }
}