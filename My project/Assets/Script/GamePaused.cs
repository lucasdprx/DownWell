using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePaused : MonoBehaviour
{
    [SerializeField] private GameObject _settingMenu;
    [SerializeField] private GameObject _gamePaused;
    private float _res;

    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonOption;
    [SerializeField] private Button _buttonMainMenu;

    [SerializeField] private Slider _sliderSFX;

    public static bool _gameIsPaused;

    private void Start()
    {
        SetValueSliderSFX();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }
    public void Resume()
    {
        AudioManager.Instance.PlaySong("Button");
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
            _buttonMainMenu.gameObject.SetActive(true);
            _buttonOption.gameObject.SetActive(true);
            _buttonStart.gameObject.SetActive(true);
            PlayerPrefs.SetFloat("SFX", _sliderSFX.value);
        }
    }

    public void Option()
    {
        AudioManager.Instance.PlaySong("Button");
        _settingMenu.SetActive(true);
        _buttonMainMenu.gameObject.SetActive(false);
        _buttonOption.gameObject.SetActive(false);
        _buttonStart.gameObject.SetActive(false);
    }

    public void CloseOption()
    {
        AudioManager.Instance.PlaySong("Button");
        _settingMenu.SetActive(false);
        _buttonMainMenu.gameObject.SetActive(true);
        _buttonOption.gameObject.SetActive(true);
        _buttonStart.gameObject.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
        _gameIsPaused = false;
        PlayerPrefs.SetInt("SaveSFX", 1);
        PlayerPrefs.SetFloat("SFX", _sliderSFX.value);
    }

    public void SetValueSliderSFX()
    {
        _sliderSFX.value = PlayerPrefs.GetFloat("SFX");
    }
}
