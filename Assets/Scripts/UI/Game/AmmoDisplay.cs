using TMPro;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoText;

    public void UpdateAmmoUI(int ammo)
    {
        _ammoText.text = $"Ammo: {ammo}";
    }
}
