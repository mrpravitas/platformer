using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    [SerializeField] private Sprite _sprite1;
    [SerializeField] private Sprite _sprite2;
    [SerializeField] private float _switchInterval;

    private SpriteRenderer _spriteRenderer;
    private float _timer;
    private bool _useSprite1 = true;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _sprite1;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _switchInterval)
        {
            _useSprite1 = !_useSprite1;
            _spriteRenderer.sprite = _useSprite1 ? _sprite1 : _sprite2;
            _timer = 0f;
        }
    }
}
