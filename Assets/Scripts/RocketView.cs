using System;
using UnityEngine;

public class RocketView : MonoBehaviour
{
    public event Action<Transform> OnCrashed;

    public Rigidbody2D RocketRigidbody;
    public ParticleSystem FlameParticle;
    public int Speed;

    private float _particlesSpeed;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Obstacle>())
        {
            OnCrashed?.Invoke(transform);
        }
    }

}
