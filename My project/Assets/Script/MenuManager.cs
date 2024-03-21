using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsMenu;

    public static MenuManager Instance;

    [SerializeField] private GameObject _buttonStart;
    [SerializeField] private GameObject _buttonOption;
    [SerializeField] private GameObject _buttonQuit;

    private void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SceneLucas");
        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("level", 1);
    }

    public void Option()
    {
        AudioManager.Instance.PlaySong("Button");
        _settingsMenu.SetActive(true);
        _buttonOption.SetActive(false);
        _buttonQuit.SetActive(false);
        _buttonStart.SetActive(false);
    }

    public void CloseOption()
    {
        AudioManager.Instance.PlaySong("Button");
        _settingsMenu.SetActive(false);
        _buttonOption.SetActive(true);
        _buttonQuit.SetActive(true);
        _buttonStart.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
