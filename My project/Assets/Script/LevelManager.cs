using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI _textLevel;

    public static LevelManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _textLevel.text = "Level : " + PlayerPrefs.GetInt("level").ToString();
    }
}
