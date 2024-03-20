using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image _image;
    public bool _animation;
    public void StartAnimation()
    {
        _image.gameObject.SetActive(true);
        _animation = true;
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
                MenuManager.Instance.StartGame();
            }
        }
    }
}