using UnityEngine;
using UnityEngine.Events;

public class PlayerAmmo : MonoBehaviour
{
    private int _ammo;

    public UnityEvent<int> OnAmmoChanged;

    public void AddAmmo(int amount)
    {
        _ammo += amount;

        OnAmmoChanged.Invoke(_ammo);
    }

    public void UseAmmo()
    {
        _ammo = Mathf.Max(0, _ammo - 1);

        OnAmmoChanged.Invoke(_ammo);
    }

    public bool HasAmmo()
    {
        return _ammo > 0;
    }
}
