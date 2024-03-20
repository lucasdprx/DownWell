using TMPro;
using UnityEngine;

public class TextProgression : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textProgression;
    private float _initPosPlayer;
    private float _progress;

    public static bool _win;

    private void Start()
    {
        _initPosPlayer = InputPlayer.Instance._rigidbody.transform.position.y;
        _win = false;
    }

    private void Update()
    {
        if (!_win)
        {
            _progress = Mathf.Clamp((_initPosPlayer - InputPlayer.Instance._rigidbody.gameObject.transform.position.y) * 100 / (GenerationProcedural.Instance._height + 10), 0, 100.0000f);
            _textProgression.text = "Progression : " + _progress.ToString("0.00") + "%";
            if (_progress >= 100 && !_win)
            {
                Time.timeScale = 0.0f;
                VictoryDefeat.Instance._uiVictoryDefeat.SetActive(true);
                _win = true;
            }
        }
    }
}
