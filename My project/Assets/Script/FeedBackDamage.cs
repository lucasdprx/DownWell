using UnityEngine;

public class FeedBackDamage : MonoBehaviour
{
    [SerializeField] private GameObject _wall1;
    [SerializeField] private GameObject _wall2;
    [SerializeField] private float _speed;
    private SpriteRenderer _spriteRenderer1;
    private SpriteRenderer _spriteRenderer2;
    private Color _color;

    public static bool _heTakeDamage;
    private static bool _changeColor = true;

    private void Start()
    {
        _spriteRenderer1 = _wall1.GetComponent<SpriteRenderer>();
        _spriteRenderer2 = _wall2.GetComponent<SpriteRenderer>();
        _color = _spriteRenderer1.color;
    }

    private void Update()
    {
        print(_spriteRenderer1.color.r);
        if (_heTakeDamage)
        {
            ChangeColorWall();
            if (_spriteRenderer1.color.r <= 0.196f)
            {
                _changeColor = true;
                _heTakeDamage = false;
                _spriteRenderer1.color = _color;
                _spriteRenderer2.color = _color;
            }
        }
    }
    public void ChangeColorWall()
    {
        if (_changeColor)
        {
            _spriteRenderer1.color = new Color(0.4f, _spriteRenderer1.color.g, _spriteRenderer1.color.b, 1);
            _spriteRenderer2.color = new Color(0.4f, _spriteRenderer2.color.g, _spriteRenderer2.color.b, 1);
            _changeColor = false;
        }
        _spriteRenderer1.color -= new Color(Time.deltaTime, 0, 0, 0);
        _spriteRenderer2.color -= new Color(Time.deltaTime, 0, 0, 0);
    }
}
