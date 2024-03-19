using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePaused : MonoBehaviour
{
    [SerializeField] private GameObject _settingMenu;
    [SerializeField] private GameObject _gamePaused;
    private float _res;

    public static bool _gameIsPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }
    public void Resume()
    {
        if (Time.timeScale > 0.1f)
        {
            _gamePaused.SetActive(true);
            _res = Time.timeScale;
            Time.timeScale = 0.0f;
            _gameIsPaused = true;
        }
        else if (Time.timeScale <= 0.0f)
        {
            _gamePaused.SetActive(false);
            Time.timeScale = _res;
            _gameIsPaused = false;
            _settingMenu.SetActive(false);
        }
    }

    public void Option()
    {
        _settingMenu.SetActive(true);
    }

    public void CloseOption()
    {
        _settingMenu.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
        _gameIsPaused = false;
    }
}
