using System;
using UnityEngine;

public class RocketController : IDisposable
{
    public event Action<Transform, ParticleSystem> OnCrashed;

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
        _rocketView.OnCrashed += Crash;

        _rocketFlame = new RocketFlame(_rocketView);
    }
    private void Accelerate()
    {

        _rocketView.RocketRigidbody.AddForce(_rocketView.transform.TransformDirection(Vector3.up) * _rocketView.Speed);
        _rocketFlame.ShowFlame();
    }

    private void StopAccelerate()
    {
        _rocketFlame.HideFlame();
    }

    private void Crash()
    {
        OnCrashed?.Invoke(_rocketView.transform, _rocketView.ExplosionParticle);
        _rocketView.RocketRigidbody.bodyType = RigidbodyType2D.Static;
        _rocketView.RocketObject.SetActive(false);
    }


    public void Dispose()
    {
        _inputHandler.OnAccelerate -= Accelerate;
        _inputHandler.OnAccelerateFinished -= StopAccelerate;
        _rocketView.OnCrashed -= Crash;
    }
}
