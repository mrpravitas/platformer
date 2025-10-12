using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float _switchInterval;

    private SpriteRenderer _spriteRenderer;
    private float _timer;
    private int _currentIndex;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_spriteRenderer != null && _sprites.Length > 0)
        {
            _spriteRenderer.sprite = _sprites[0];
        }
    }

    private void Update()
    {
        if (_sprites == null || _sprites.Length == 0)
        {
            return;
        }

        _timer += Time.deltaTime;

        if (_timer >= _switchInterval)
        {
            _currentIndex = (_currentIndex + 1) % _sprites.Length;
            _spriteRenderer.sprite = _sprites[_currentIndex];
            _timer = 0f;
        }
    }
}
