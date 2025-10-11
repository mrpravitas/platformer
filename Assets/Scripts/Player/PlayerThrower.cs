using UnityEngine;

public class PlayerThrower : MonoBehaviour
{
    [SerializeField] private GameObject _rockPrefab;
    [SerializeField] private Transform _throwPoint;
    [SerializeField] private PlayerAmmo _ammo;

    [Header("ProjectileParameters")]
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _ammo.HasAmmo())
        {
            Throw();
        }
    }

    private void Throw()
    {
        GameObject stone = Instantiate(_rockPrefab, _throwPoint.position, Quaternion.identity);
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        stone.GetComponent<RockProjectile>().Launch(direction, _speed);

        _ammo.UseAmmo();
    }
}
