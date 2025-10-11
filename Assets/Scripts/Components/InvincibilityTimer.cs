using System.Collections;
using UnityEngine;

public class InvincibilityTimer : MonoBehaviour
{
    [SerializeField] private float _duration;

    public bool IsActive { get; private set; } = false;
    public float Duration => _duration;

    public void Activate()
    {
        if (!IsActive)
        {
            StartCoroutine(Invincibility());
        }
    }

    private IEnumerator Invincibility()
    {
        IsActive = true;
        yield return new WaitForSeconds(_duration);
        IsActive = false;
    }
}
