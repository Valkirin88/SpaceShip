using System;
using UnityEngine;

public class SpecialEffectsHandler : IDisposable
{

    private ParticleSystem _explosionParticles;

    private RocketView _rocketView;

    public SpecialEffectsHandler(RocketView rocketView)
    {
        _rocketView = rocketView;
        _rocketView.OnCrashed += ShowCrash;
    }

    private void ShowCrash(Transform crashPosition)
    {
        _explosionParticles.transform.position = crashPosition.position;
        _explosionParticles.Play();
    }

    public void Dispose()
    {
        _rocketView.OnCrashed -= ShowCrash;
    }

}
