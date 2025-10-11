using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    public float MoveInput => _moveInput;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _coyoteTime;

    [SerializeField] private GroundChecker _groundChecker;

    [SerializeField] protected AudioClip _jumpSound;

    private Rigidbody2D _rigidbody;
    private float _moveInput;
    private float _coyoteTimer;
    private bool _isJumpQueued;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");

        Flip(_moveInput);
        UpdateCoyoteTimer();

        if (Input.GetButtonDown("Jump") && _coyoteTimer > 0)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_moveInput * _movementSpeed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        _coyoteTimer = 0;
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        AudioSource.PlayClipAtPoint(_jumpSound, transform.position);
    }

    private void Flip(float input)
    {
        if (input > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (input < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void UpdateCoyoteTimer()
    {
        if (_groundChecker.IsGrounded())
        {
            _coyoteTimer = _coyoteTime;
        }
        else
        {
            _coyoteTimer -= Time.deltaTime;
        }
    }
}
