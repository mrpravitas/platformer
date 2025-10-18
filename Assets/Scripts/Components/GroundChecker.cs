using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _groundPoint;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _groundLayer;

    private bool _isGrounded;

    public bool IsGrounded()
    {
        // return Physics2D.OverlapCircle(_groundPoint.position, _checkRadius, _groundLayer);
        return _isGrounded;
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundPoint.position, _checkRadius, _groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = transform.position;
        Gizmos.DrawSphere(center, _checkRadius);
    }
}
