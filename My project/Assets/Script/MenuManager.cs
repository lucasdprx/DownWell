using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsMenu;

    public static MenuManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SceneLucas");
    }

    public void Option()
    {
        _settingsMenu.SetActive(true);
    }

    public void CloseOption()
    {
        _settingsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
