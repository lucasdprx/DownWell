using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image _image;
    public bool _animation;

    public static FadeOut Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void StartAnimation()
    {
        Time.timeScale = 1.0f;
        _image.gameObject.SetActive(true);
        _animation = true;
        if (MenuManager.Instance != null)
            PlayerPrefs.SetFloat("SFX", MinValue.values);
    }

    private void Update()
    {

        if (_animation)
        {
            if (_image.color.a < 1)
            {
                _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _image.color.a + Time.deltaTime);
            }
            else
            {
                _animation = false;
                if (MenuManager.Instance != null)
                    MenuManager.Instance.StartGame();
                else 
                    VictoryDefeat.Instance.StartGame();
            }
        }
    }
}
