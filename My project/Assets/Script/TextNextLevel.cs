using System.Collections;
using TMPro;
using UnityEngine;

public class TextNextLevel : MonoBehaviour
{
    [SerializeField] private int _nbFlickers;
    [SerializeField] private float _speed;
    [SerializeField] private TextMeshProUGUI _textLevelUp;
    void Start()
    {
        if (PlayerPrefs.GetInt("level") > 1)
            StartCoroutine(AnimationText());
    }

    IEnumerator AnimationText()
    {
        for (int i = 0; i < _nbFlickers; i++)
        {
            yield return new WaitForSeconds(_speed);
            if (_textLevelUp.gameObject.activeSelf)
                _textLevelUp.gameObject.SetActive(false);
            else
                _textLevelUp.gameObject.SetActive(true);
        }
        _textLevelUp.gameObject.SetActive(false);
    }
}
