using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Gameplay.Slots
{
  public class InventorySlotView : MonoBehaviour
  {
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _weight;
    [SerializeField] private TextMeshProUGUI _count;

    public void SetIcon(Sprite image) => 
      _icon.sprite = image;

    public void SetWeight(float weight) => 
      _weight.text = $"{weight}kg";

    public void SetCount(int count, int stack) => 
      _count.text = $"{count}/{stack}";
  }
}