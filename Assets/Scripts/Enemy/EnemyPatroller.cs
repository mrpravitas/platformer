using UnityEngine;

public class EnemyPatroller : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _movementSpeed;

    private Transform _targetPoint;

    private void Start()
    {
        _targetPoint = _pointA;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPoint.position, _movementSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _targetPoint.position) < 0.1f)
        {
            _targetPoint = _targetPoint == _pointA ? _pointB : _pointA;
        }
    }
}
