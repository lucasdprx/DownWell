using TMPro;
using UnityEngine;

public class TextProgression : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textProgression;
    private float _initPosPlayer;
    public static float _progress;

    public bool _finish = false;

    private void Start()
    {
        _initPosPlayer = InputPlayer.Instance._rigidbody.transform.position.y;
    }

    private void Update()
    {
        if (LifeBar.Instance._nbLife > 0)
        {
            _progress = Mathf.Clamp((_initPosPlayer - InputPlayer.Instance._rigidbody.gameObject.transform.position.y) * 100 / (GenerationProcedural.Instance._height + 2), 0, 100.0000f);
            _textProgression.text = "Progression : " + _progress.ToString("0.00") + "%";
        }
        if (_progress >= 100 && !_finish)
        {
            _finish = true;
            AudioManager.Instance.PlaySong("Sucess");
            PlayerPrefs.SetInt("hp", LifeBar.Instance._nbLife);
            FadeOut.Instance.StartAnimation();
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        }
    }
}
