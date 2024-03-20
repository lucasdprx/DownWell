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
    }

    public void Option()
    {
        _settingsMenu.SetActive(true);
        _buttonOption.SetActive(false);
        _buttonQuit.SetActive(false);
        _buttonStart.SetActive(false);
    }

    public void CloseOption()
    {
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
