using System;
using UnityEngine;

public class SpecialEffectsHandler : MonoBehaviour
{

    private ParticleSystem _explosionParticles;

    private RocketController _rocketController;

    public void Initialize(RocketController rocketController)
    {
        _rocketController = rocketController;
        _rocketController.OnCrashed += ShowCrash;
    }

    private void ShowCrash(Transform crashPosition)
    {
        _explosionParticles.transform.position = crashPosition.position;
        _explosionParticles.Play();
    }

    public void OnDestroy()
    {
        _rocketController.OnCrashed -= ShowCrash;
    }

}
