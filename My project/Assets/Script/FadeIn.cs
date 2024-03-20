using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image _image;
    public bool _animation;
    public void Start()
    {
        _animation = true;
    }

    private void Update()
    {
        if (_animation)
        {
            if (_image.color.a > 0)
            {
                _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _image.color.a - Time.deltaTime);
            }
            else
            {
                _image.gameObject.SetActive(false);
                _animation = false;
            }
        }
    }
}
