using UnityEngine;

public class RockPickup : MonoBehaviour, IPickup
{
    [SerializeField] private int _ammoValue;
    [SerializeField] private AudioClip _sound;

    public void Collect(PlayerCollector collector)
    {
        collector.AddAmmo(_ammoValue);
        AudioSource.PlayClipAtPoint(_sound, transform.position);
        Destroy(gameObject);
    }
}
