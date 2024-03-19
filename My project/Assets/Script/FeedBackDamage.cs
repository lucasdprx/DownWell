using UnityEngine;

public class FeedBackDamage : MonoBehaviour
{
    [SerializeField] private GameObject _wall1;
    [SerializeField] private GameObject _wall2;
    [SerializeField] private float _speed;
    private SpriteRenderer _spriteRenderer1;
    private SpriteRenderer _spriteRenderer2;

    public static bool _heTakeDamage;
    private bool _changeColor = true;

    private void Start()
    {
        _spriteRenderer1 = _wall1.GetComponent<SpriteRenderer>();
        _spriteRenderer2 = _wall2.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_heTakeDamage)
        {
            ChangeColorWall();
            if (_spriteRenderer1.color.r <= 50)
            {
                _changeColor = false;
                _heTakeDamage = false;
            }
        }
    }
    public void ChangeColorWall()
    {
        if (_changeColor)
        {
            _spriteRenderer1.color = new Color(100 / 255, _spriteRenderer1.color.g, _spriteRenderer1.color.b);
            _spriteRenderer2.color = new Color(100 / 255, _spriteRenderer2.color.g, _spriteRenderer2.color.b);
            _changeColor = false;
        }
        _spriteRenderer1.color -= new Color(_speed * Time.deltaTime, _spriteRenderer1.color.g, _spriteRenderer1.color.b);
        _spriteRenderer2.color -= new Color(_spriteRenderer2.color.r - _speed / 255 * Time.deltaTime, _spriteRenderer2.color.g, _spriteRenderer2.color.b);

    }
}
