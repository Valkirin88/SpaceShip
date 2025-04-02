using UnityEngine;

public class SkyObstacle : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private float _speed;

    private Vector3 _direction;

    public Vector3 Direction => _direction; 

    private void Start()
    {
        _direction = Vector3.right;
        var randomDirection = Random.Range(0,2);
        if (randomDirection == 0 )
        {
            if(_spriteRenderer.flipX) 
            {
                _spriteRenderer.flipX = false;
            }
            else
                _spriteRenderer.flipX = true;
            _direction = Vector3.left;
        }
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        _speed = Random.Range(0.1f,2);
        transform.Translate(Direction * Time.deltaTime * _speed);
    }
}
