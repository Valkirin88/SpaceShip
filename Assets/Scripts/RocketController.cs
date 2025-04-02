using System;
using UnityEngine;

public class RocketController : IDisposable
{
    private InputHandler _inputHandler;

    private RocketView _rocketView;

    private RocketFlame _rocketFlame;

    private float _particlesSpeed;

    private bool _isPushed;

    public RocketController(InputHandler inputHandler, RocketView rocketView)
    {
        _inputHandler = inputHandler;
        _rocketView = rocketView;

        _inputHandler.OnAccelerate += Accelerate;
        _inputHandler.OnAccelerateFinished += StopAccelerate;

        _rocketFlame = new RocketFlame(_rocketView);
    }
    private void Accelerate()
    {
        _rocketView.RocketRigidbody.AddForce(Vector2.up * _rocketView.Speed);
        _rocketFlame.ShowFlame();
    }

    private void StopAccelerate()
    {
        _rocketFlame.HideFlame();
    }

    public void Dispose()
    {
        _inputHandler.OnAccelerate -= Accelerate;
    }
}
