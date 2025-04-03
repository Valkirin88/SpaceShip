using System;
using UnityEngine;

public class SpecialEffectsHandler : IDisposable
{

    private ParticleSystem _explosionParticles;
    private ParticleSystem _launchParticles;

    private RocketController _rocketController;

    public SpecialEffectsHandler(RocketController rocketController)
    {
        _rocketController = rocketController;
        _rocketController.OnCrashed += ShowCrash;
        _rocketController.OnLaunch += ShowLaunchEffect;
    }

    private void ShowCrash(Transform crashPosition, ParticleSystem explosionParticles)
    {
        _explosionParticles = explosionParticles;
        _explosionParticles.transform.position = crashPosition.position;
        _explosionParticles.gameObject.SetActive(true);
    }

    private void ShowLaunchEffect(Transform launchTransform, ParticleSystem launchParticles, bool IsInLaunch)
    {
        _launchParticles = launchParticles;
        if (IsInLaunch) 
        {

            _launchParticles.gameObject.transform.SetParent(null);
            _launchParticles.gameObject.SetActive(true);
        }
        else
        {

            var position = launchTransform.position;
            _launchParticles.gameObject.transform.position = position;
        }    
    }

    public void Dispose()
    {
        _rocketController.OnCrashed -= ShowCrash;
    }

}
