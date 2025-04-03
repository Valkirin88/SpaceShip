using System;
using Unity.VisualScripting;
using UnityEngine;

public class RocketView : MonoBehaviour
{
    public event Action OnCrashed;

    public GameObject RocketObject;
    public Rigidbody2D RocketRigidbody;
    public ParticleSystem FlameParticle;
    public ParticleSystem ExplosionParticle;
    public ParticleSystem LaunchParticles;
    public int Speed;
    
    [SerializeField]
    private Transform _engineTransform;

    private bool _isInLaunchZone;

    private float _particlesSpeed;

    public bool IsInLaunchZone  => _isInLaunchZone;

    public Transform EngineTransform  => _engineTransform; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SkyObstacle>())
        {
            OnCrashed?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LaunchZone>())
        {
            _isInLaunchZone = true;
            Debug.Log("Launch");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LaunchZone>())
        {
            _isInLaunchZone = false;
        }
    }
}
