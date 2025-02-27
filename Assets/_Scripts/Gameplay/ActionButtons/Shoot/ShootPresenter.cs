using UnityEngine;
using VContainer;

namespace _Scripts.Gameplay.ActionButtons.Shoot
{
  public class ShootPresenter : MonoBehaviour
  {
    [SerializeField] private ShootView _shootView;

    private IShooter _shooter;

    [Inject]
    private void Construct(IShooter shooter) => 
      _shooter = shooter;

    private void OnEnable() => 
      _shootView._ShootButton.onClick.AddListener(Shoot);

    private void Shoot() => 
      _shooter.Shoot();

    private void OnDisable() => 
      _shootView._ShootButton.onClick.RemoveListener(Shoot);
  }
}