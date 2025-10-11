using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameButtons;
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private AudioClip _uiClick;

    public void OnPause()
    {
        PlaySound();
        Time.timeScale = 0;
        _gameButtons.SetActive(false);
        _pauseScreen.SetActive(true);
    }

    public void OnContinue()
    {
        PlaySound();
        Time.timeScale = 1;
        _gameButtons.SetActive(true);
        _pauseScreen.SetActive(false);
    }

    public void OnRestart()
    {
        PlaySound();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenu()
    {
        PlaySound();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void OnVictory()
    {
        Time.timeScale = 0;
        _gameButtons.SetActive(false);
        _pauseScreen.SetActive(false);
        _victoryScreen.SetActive(true);
    }

    public void OnLose()
    {
        Time.timeScale = 0;
        _gameButtons.SetActive(false);
        _pauseScreen.SetActive(false);
        _loseScreen.SetActive(true);
    }

    private void PlaySound()
    {
        AudioSource.PlayClipAtPoint(_uiClick, transform.position);
    }
}
