using UnityEngine;

public class RocketFlame : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _flameParticle;

    private RocketController _rocketController;
    private float _particlesSpeed;


    public void Initialize(RocketController rocketController)
    {
        _rocketController = rocketController;

        _rocketController.OnAccelerate += ShowFlame;
        _rocketController.OnAccelerateFinished += HideFlame;

        _particlesSpeed = _flameParticle.startSpeed;
    }



    private void ShowFlame()
    {
        if (_flameParticle.startSpeed < _particlesSpeed)
            _flameParticle.startSpeed = _flameParticle.startSpeed + 2f;
        _flameParticle.Play();
    }

    private void HideFlame()
    {
        if (_flameParticle.startSpeed > 0)
            _flameParticle.startSpeed = _flameParticle.startSpeed - 0.2f;
        else
            _flameParticle.Stop();
    }

    private void OnDestroy()
    {
        _rocketController.OnAccelerate -= ShowFlame;
        _rocketController.OnAccelerateFinished -= HideFlame;
    }
}
