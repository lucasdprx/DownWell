using TMPro;
using UnityEngine;

public class LifeBar : MonoBehaviour
{

    public static LifeBar Instance;
    [SerializeField] private RectTransform _imageLifeBar;
    [SerializeField] private float _widthImageLifeBar;
    [HideInInspector] public int _nbLife;
    [HideInInspector] public bool _isDeath;
    [SerializeField] private int _maxLife;

    [SerializeField] private TextMeshProUGUI _textLife;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _nbLife = _maxLife;
        _textLife.text = _nbLife.ToString() + " / " + _maxLife.ToString();
    }
    public void UpdateImageLifeBar()
    {
        if (_nbLife > 0)
        {
            _nbLife--;
            _textLife.text = _nbLife.ToString() + " / " + _maxLife.ToString();
            _imageLifeBar.sizeDelta = new Vector2(_widthImageLifeBar / _maxLife * _nbLife, _imageLifeBar.sizeDelta.y);
            _imageLifeBar.transform.position -= new Vector3(_widthImageLifeBar / (_maxLife * 2), 0, 0);
            if (_nbLife <= 0)
            {
                _isDeath = true;
                Time.timeScale = 0.0f;
                VictoryDefeat.Instance._textDefeat.text = "You no longer have any life points" + "\n" + "You made it to wave " + PlayerPrefs.GetInt("level").ToString();
                PlayerPrefs.SetInt("level", 1);
                VictoryDefeat.Instance._uiVictoryDefeat.SetActive(true);
            }
        }
    }
}
