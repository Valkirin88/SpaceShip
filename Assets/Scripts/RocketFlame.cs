using UnityEngine;

public class RocketFlame 
{
    private readonly RocketView _rocketView;


    private RocketView _rocketController;
    private float _particlesSpeed;


    public RocketFlame(RocketView rocketView)
    {
        _rocketView = rocketView;
        _particlesSpeed = _rocketView.FlameParticle.startSpeed;
    }

    public void ShowFlame()
    {
        if (_rocketView.FlameParticle.startSpeed < _particlesSpeed)
            _rocketView.FlameParticle.startSpeed = _rocketView.FlameParticle.startSpeed + 2f;
        _rocketView.FlameParticle.Play();
    }

    public void HideFlame()
    {
        if (_rocketView.FlameParticle.startSpeed > 0)
            _rocketView.FlameParticle.startSpeed = _rocketView.FlameParticle.startSpeed - 0.2f;
        else
            _rocketView.FlameParticle.Stop();
    }
}
