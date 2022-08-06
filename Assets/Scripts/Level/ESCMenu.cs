using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuCanvas;
    private bool _gameIsPaused = false;

    private void Start()
    {
        Resume();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _gameIsPaused = !_gameIsPaused;

            if (_gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        _pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        _pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ToMainMenu(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
}