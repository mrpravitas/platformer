using System;
using UnityEngine;

public class StompTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        var killable = GetComponentInParent<Killable>();

        if (killable != null)
        {
            killable.Die();
        }
    }
}
