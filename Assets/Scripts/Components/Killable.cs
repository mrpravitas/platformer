using UnityEngine;
using UnityEngine.Events;

public class Killable : MonoBehaviour
{
    [SerializeField] private int _scoreValue;
    [SerializeField] private AudioClip _deathSound;

    public UnityEvent<int> OnEnemyDie;

    public void Die()
    {
        AudioSource.PlayClipAtPoint(_deathSound, transform.position);
        OnEnemyDie.Invoke(_scoreValue);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerProjectile"))
        {
            Die();
        }
    }
}
