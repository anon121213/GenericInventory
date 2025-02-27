using UnityEngine;
using VContainer;

namespace _Scripts.Gameplay.ActionButtons.RemoveRandomItem
{
  public class RemoveItemPresenter : MonoBehaviour
  {
    [SerializeField] private RemoveItemView _removeItemView;
    
    private IRandomItemRemover _randomItemRemover;

    [Inject]
    private void Construct(IRandomItemRemover randomItemRemover) => 
      _randomItemRemover = randomItemRemover;

    private void OnEnable() => 
      _removeItemView.Button.onClick.AddListener(AddItem);

    private void AddItem() => 
      _randomItemRemover.RemoveItem();

    private void OnDisable() => 
      _removeItemView.Button.onClick.RemoveListener(AddItem);
  }
}