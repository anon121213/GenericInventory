using UnityEngine;
using VContainer;

namespace _Scripts.Gameplay.ActionButtons.AddRandomItem
{
  public class AddItemPresenter : MonoBehaviour
  {
    [SerializeField] private AddItemView _addItemView;
    
    private IAddItemModel _addItemModel;

    [Inject]
    private void Construct(IAddItemModel addItemModel) => 
      _addItemModel = addItemModel;

    private void OnEnable() => 
      _addItemView._button.onClick.AddListener(AddItem);

    private void AddItem() => 
      _addItemModel.AddItem();

    private void OnDisable() => 
      _addItemView._button.onClick.RemoveListener(AddItem);
  }
}