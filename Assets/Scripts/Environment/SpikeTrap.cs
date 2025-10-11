using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private int _damageAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(_damageAmount);
        }
    }
}
