using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryDefeat : MonoBehaviour
{
    public GameObject _uiVictoryDefeat;
    public static VictoryDefeat Instance;

    public TextMeshProUGUI _textDefeat;

    private void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {
        if (LifeBar.Instance._nbLife <= 0)
            PlayerPrefs.SetInt("hp", 4);
        SceneManager.LoadScene("SceneLucas");
        Time.timeScale = 1.0f;
        _uiVictoryDefeat.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
}
