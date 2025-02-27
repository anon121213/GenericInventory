using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Infrastructure.Services.Input
{
  public class MobileInputService : IInputService, IDisposable
  {
    public event Action OnTouch;
    public event Action OnEndTouch;

    private readonly InputActions _input;

    public MobileInputService()
    {
      _input = new InputActions();
      _input.Enable();
      Subscribe();
    }

    private void Subscribe()
    {
      _input.UI.OnTouch.performed += OnTouchHandler;
      _input.UI.OnTouch.canceled += OnEndTouchHandler;
    }

    public Vector2 TouchPosition =>
      _input.UI.TouchPosition.ReadValue<Vector2>();

    private void OnTouchHandler(InputAction.CallbackContext obj) => 
      OnTouch?.Invoke();

    private void OnEndTouchHandler(InputAction.CallbackContext obj) => 
      OnEndTouch?.Invoke();

    public void Dispose()
    {
      _input.UI.OnTouch.performed -= OnTouchHandler;
      _input.UI.OnTouch.canceled -= OnEndTouchHandler;
      _input?.Dispose();
    }
  }

  public interface IInputService
  {
    event Action OnTouch;
    event Action OnEndTouch;
    Vector2 TouchPosition { get; }
  }
}