using System;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class RocketController : MonoBehaviour
{
    public event Action OnAccelerate;
    public event Action OnAccelerateFinished;
    public event Action<Transform> OnCrashed;

    [SerializeField]
    private AudioSource _source;
    [SerializeField] private AudioClip _clip;

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
    private bool _isSoundPlaying;

    private float _starsTime;
    private float _volume;

    private Vector2 _direction;

    private void Start()
    {
        _particlesSpeed = _flameParticle.startSpeed;
        _volume = _source.volume;
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
        _starsTime += Time.deltaTime;
        if(_starsTime >5)
        {
            _starsParticlesObject.SetActive(false);
        }
           
    }
    private void FixedUpdate()
    {
         _direction.x = Input.acceleration.x;
         _direction.y = Input.acceleration.y;
        _direction.Normalize();
        if (_isPushed)
        {
            OnAccelerate?.Invoke();
            _rockerRigidbody.AddForce(Vector2.up * _speed);
            _launchDustParticlesObject.SetActive(true);
            if (!_isSoundPlaying)
            {
                _source.Play();
                _isSoundPlaying = true;
            }
            _source.volume = _volume;
            _isPushed = false;
        }
        else
        {
            _source.volume = _source.volume - 0.01f;
            if (_source.volume < 0 )
            {
                _source.volume = 0;
                _isSoundPlaying = false;
            }
            OnAccelerateFinished?.Invoke();
 
        }

        
    }

}
