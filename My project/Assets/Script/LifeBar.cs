using TMPro;
using UnityEngine;

public class LifeBar : MonoBehaviour
{

    public static LifeBar Instance;
    [SerializeField] private RectTransform _imageLifeBar;
    [SerializeField] private float _widthImageLifeBar;
    [HideInInspector] public int _nbLife;
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
                Time.timeScale = 0.0f;
                VictoryDefeat.Instance._uiVictoryDefeat.SetActive(true);
            }
        }
    }
}
