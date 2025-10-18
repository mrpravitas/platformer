using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private PlayerAmmo _playerAmmo;

    public void AddScore(int amount)
    {
        _playerScore.AddScore(amount);
    }

    public void AddAmmo(int amount)
    {
        _playerAmmo.AddAmmo(amount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IPickup>(out var pickup))
        {
            pickup.Collect(this);
        }
    }
}
