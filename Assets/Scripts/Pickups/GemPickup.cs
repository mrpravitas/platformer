using UnityEngine;

public class GemPickup : MonoBehaviour, IPickup
{
    [SerializeField] private int _scoreValue;
    [SerializeField] private AudioClip _sound;

    public void Collect(PlayerCollector collector)
    {
        collector.AddScore(_scoreValue);
        AudioSource.PlayClipAtPoint(_sound, transform.position);
        Destroy(gameObject);
    }
}
