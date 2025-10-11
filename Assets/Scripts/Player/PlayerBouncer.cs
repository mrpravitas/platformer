using UnityEngine;

public class PlayerBouncer : MonoBehaviour
{
    [SerializeField] private float _bounceForce;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("StompTrigger"))
        {
            return;
        }

        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _bounceForce);
    }
}
