using System.Collections;
using TMPro;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    public int _combo;
    public TextMeshProUGUI _textCombo;
    public static ComboSystem Instance;
    private float _speed;

    private void Awake()
    {
        Instance = this;
    }

    public void StartAnimation()
    {
        if (_combo == 11)
            _combo = 1;
        if (_combo == 10)
        {
            if (LifeBar.Instance._nbLife < 4)
            {
                LifeBar.Instance._nbLife += 1;
                LifeBar.Instance.AddImageLifeBar();
            }
            _textCombo.color = new Color(_textCombo.color.r, _textCombo.color.g, _textCombo.color.b, 1);
            _textCombo.text = "+1 Life";
            _speed = 0.25f;
            StartCoroutine(AnimationText(_textCombo));
        }
        else
        {
            _textCombo.color = new Color(_textCombo.color.r, _textCombo.color.g, _textCombo.color.b, 1);
            _textCombo.text = "Combo x" + _combo.ToString();
            _speed = 1;
            StartCoroutine(AnimationText(_textCombo));
        }
    }
    IEnumerator AnimationText(TextMeshProUGUI _text)
    {
        if (_textCombo.color.a > 0)
        {
            _text.color -= new Color(0, 0, 0, _speed * Time.deltaTime);
            yield return null;
            StartCoroutine(AnimationText(_text));
        }
    }
}
