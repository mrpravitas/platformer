using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private AudioClip _uiClick;
    
    public void OnStartGame()
    {
        PlaySound();
        _mainMenuPanel.SetActive(false);
        _levelsPanel.SetActive(true);
    }

    public void OnBackToMenu()
    {
        PlaySound();
        _mainMenuPanel.SetActive(true);
        _levelsPanel.SetActive(false);
    }

    public void OnStartLevel(string level)
    {
        PlaySound();
        SceneManager.LoadScene(level);
    }

    public void OnExit()
    {
        PlaySound();
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void PlaySound()
    {
        AudioSource.PlayClipAtPoint(_uiClick, transform.position);
    }
}
