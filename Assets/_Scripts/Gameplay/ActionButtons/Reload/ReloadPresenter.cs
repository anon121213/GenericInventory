using UnityEngine;
using VContainer;

namespace _Scripts.Gameplay.ActionButtons.Reload
{
  public class ReloadPresenter : MonoBehaviour
  {
    [SerializeField] private ReloadView _reloadView;
    
    private IReloadModel _reloadModel;

    [Inject]
    private void Construct(IReloadModel reloadModel) =>
      _reloadModel = reloadModel;

    private void OnEnable() => 
      _reloadView.Button.onClick.AddListener(Reload);

    private void Reload() => 
      _reloadModel.Reload();

    private void OnDisable() => 
      _reloadView.Button.onClick.RemoveListener(Reload);
  }
}