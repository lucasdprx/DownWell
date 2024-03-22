using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsMenu;

    public static MenuManager Instance;

    [SerializeField] private GameObject _buttonStart;
    [SerializeField] private GameObject _buttonOption;
    [SerializeField] private GameObject _buttonQuit;
    [SerializeField] private GameObject _title;

    [SerializeField] private Toggle _toggleFullScreen;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _toggleFullScreen.isOn = Screen.fullScreen;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SceneLucas");
        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("hp", 4);
    }

    public void Option()
    {
        AudioManager.Instance.PlaySong("Button");
        _settingsMenu.SetActive(true);
        _buttonOption.SetActive(false);
        _buttonQuit.SetActive(false);
        _buttonStart.SetActive(false);
        _title.SetActive(false);
    }

    public void CloseOption()
    {
        AudioManager.Instance.PlaySong("Button");
        _settingsMenu.SetActive(false);
        _buttonOption.SetActive(true);
        _buttonQuit.SetActive(true);
        _buttonStart.SetActive(true);
        _title.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
