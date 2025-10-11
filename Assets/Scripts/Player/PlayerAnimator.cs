using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite _idleSprite;
    [SerializeField] private Sprite _jumpSprite;
    [SerializeField] private Sprite _walkSprite1;
    [SerializeField] private Sprite _walkSprite2;

    [Header("References")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private GroundChecker _groundChecker;

    [Header("Walk Animation")]
    [SerializeField] private float _walkFrameRate;

    private float _walkTimer;
    private bool _useFirstWalkFrame;

    private void Update()
    {
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (!_groundChecker.IsGrounded())
        {
            _spriteRenderer.sprite = _jumpSprite;
            return;
        }

        if (Mathf.Abs(_playerMover.MoveInput) > 0f)
        {
            _walkTimer += Time.deltaTime;

            if (_walkTimer >= _walkFrameRate)
            {
                _walkTimer = 0f;
                _useFirstWalkFrame = !_useFirstWalkFrame;
            }

            _spriteRenderer.sprite = _useFirstWalkFrame ? _walkSprite1 : _walkSprite2;
        }
        else
        {
            _spriteRenderer.sprite = _idleSprite;
        }
    }
}
