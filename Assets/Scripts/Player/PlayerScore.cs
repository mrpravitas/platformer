using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour
{
    private int _score;

    public UnityEvent<int> OnScoreChanged;

    public void AddScore(int amount)
    {
        _score += amount;

        OnScoreChanged.Invoke(_score);
    }
}
