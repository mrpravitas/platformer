using UnityEngine;

public class CamerFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector2 _windowSize;
    
    private Vector3 _offset = new Vector3 (0, 0, -10);

    private void LateUpdate()
    {
        if (_target == null)
        {
            return;
        }

        Vector3 camerPosition = transform.position;
        Vector3 targetPosition = _target.position;
        Vector3 newPosition = camerPosition;

        Vector2 delta = targetPosition - camerPosition;

        if (Mathf.Abs(delta.x) > _windowSize.x)
        {
            newPosition.x = targetPosition.x - Mathf.Sign(delta.x) * _windowSize.x;
        }

        if (Mathf.Abs(delta.y) > _windowSize.y)
        {
            newPosition.y = targetPosition.y - Mathf.Sign(delta.y) * _windowSize.y;
        }

        transform.position = new Vector3(newPosition.x, newPosition.y, _offset.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = transform.position;
        Vector3 size = new Vector3(_windowSize.x * 2, _windowSize.y * 2);
        Gizmos.DrawWireCube(center, size);
    }
}
