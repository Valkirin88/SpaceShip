using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchZone : MonoBehaviour
{
    public event Action<Vector3, ParticleSystem> OnLaunch;

    [SerializeField]
    private Transform _surfaceTransform;
    [SerializeField]
    private ParticleSystem _launchParticles;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<RocketView>(out RocketView _rocketView))
        {
            Vector3 position = new Vector3(_rocketView.gameObject.transform.position.x, _surfaceTransform.position.y, _rocketView.gameObject.transform.position.z);
            OnLaunch?.Invoke(position, _launchParticles);
        }
    }
}
