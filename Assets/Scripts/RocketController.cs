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
    [SerializeField]
    private GameObject _starsParticlesObject;
    [SerializeField]
    private GameObject _launchDustParticlesObject;

    private float _particlesSpeed;

    private bool _isPushed;

    private float _starsTime;

    private void Start()
    {
        _particlesSpeed = _flameParticle.startSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Plane>())
        {
            OnCrashed?.Invoke(transform);
            _starsParticlesObject.SetActive(true);
            _starsTime = 0;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isPushed = true;
        }
        Debug.Log(_rockerRigidbody.velocity);
        _starsTime += Time.deltaTime;
        if(_starsTime >5)
        {
            _starsParticlesObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if (_isPushed)
        {
            OnAccelerate?.Invoke();
            _rockerRigidbody.AddForce(Vector2.up * _speed);
            _launchDustParticlesObject.SetActive(true);

            _isPushed = false;
        }
        else
            OnAccelerateFinished?.Invoke();
    }
}
