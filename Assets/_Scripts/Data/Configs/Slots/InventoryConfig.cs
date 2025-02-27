using UnityEngine;

namespace _Scripts.Data.Configs.Slots
{
  [CreateAssetMenu(menuName = "Data/Configs/Slots/InventoryConfig", fileName = "InventoryConfig")]
  public class InventoryConfig : ScriptableObject
  {
    [field: SerializeField] public int InventorySlots { get; private set; } 
  }
}