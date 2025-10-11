using System.Collections;
using UnityEngine;

public class SpriteBlinker : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private InvincibilityTimer _invincibilityTimer;
    [SerializeField] private float _blinkInterval;

    public void Blink()
    {
        if (_invincibilityTimer ==  null)
        {
            return;
        }

        StartCoroutine(Blink(_invincibilityTimer.Duration));
    }

    private IEnumerator Blink(float duration)
    {
        float elapsed = 0;

        while (elapsed < duration)
        {
            _sprite.enabled = !_sprite.enabled;
            yield return new WaitForSeconds(_blinkInterval);
            elapsed += _blinkInterval;
        }

        _sprite.enabled = true;
    }
}
