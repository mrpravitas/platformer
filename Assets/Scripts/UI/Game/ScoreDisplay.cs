using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void UpdateScoreUI(int score)
    {
        _scoreText.text = $"Score: {score}";
    }
}
