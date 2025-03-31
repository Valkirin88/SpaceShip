using System;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public event Action OnAccelerate;
    public event Action OnAccelerateFinished;
    public event Action<Transform> OnCrashed;

    [SerializeField]
    private Rigidbody2D _rockerRigidbody;
    [SerializeField]
    private int _speed;
    [SerializeField]
    private ParticleSystem _flameParticle;

    private float _particlesSpeed;

    private bool _isPushed;

    private void Start()
    {
        _particlesSpeed = _flameParticle.startSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Obstacle>())
        {
            OnCrashed?.Invoke(transform);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isPushed = true;
        }
        Debug.Log(_rockerRigidbody.velocity);
    }
    private void FixedUpdate()
    {
        if (_isPushed)
        {
            OnAccelerate?.Invoke();
            _rockerRigidbody.AddForce(Vector2.up * _speed);

            _isPushed = false;
        }
        else
            OnAccelerateFinished?.Invoke();
    }
}
