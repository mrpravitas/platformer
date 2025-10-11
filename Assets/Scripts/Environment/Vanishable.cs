using UnityEngine;

public class Vanishable : MonoBehaviour
{
    public void Vanish()
    {
        gameObject.SetActive(false);
    }
}
