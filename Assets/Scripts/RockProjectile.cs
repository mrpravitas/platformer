using UnityEngine;

public class RockProjectile : MonoBehaviour
{
    [SerializeField] private float _maxFallDistance;

    private Rigidbody2D _rigidbody;
    private Vector2 _startPosition;
    private float _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float speed)
    {
        _startPosition = transform.position;
        _speed = speed;
        _rigidbody.velocity = direction.normalized * _speed;
    }

    private void Update()
    {
        if (transform.position.y < _startPosition.y - _maxFallDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            return;
        }

        Destroy(gameObject);
    }
}
