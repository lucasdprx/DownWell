using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;

    public Rigidbody2D _rigidbody;

    public static InputPlayer Instance;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _renderer = _player.GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _renderer.flipX = false;
            if (_rigidbody.velocity.x > 0)
                _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
            if (_rigidbody.velocity.x > -_maxSpeed)
            {
                _rigidbody.AddForce(Vector2.left * _speed * Time.deltaTime, ForceMode2D.Force);
                if (_rigidbody.velocity.x < -_maxSpeed)
                    _rigidbody.velocity = new Vector2(-_maxSpeed, _rigidbody.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _renderer.flipX = true;
            if (_rigidbody.velocity.x < 0)
                _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);

            if (_rigidbody.velocity.x < _maxSpeed)
            {
                _rigidbody.AddForce(Vector2.right * _speed * Time.deltaTime, ForceMode2D.Force);
                if (_rigidbody.velocity.x > _maxSpeed)
                    _rigidbody.velocity = new Vector2(_maxSpeed, _rigidbody.velocity.y);
            }
        }
        else
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x * 0.994f, _rigidbody.velocity.y);
    }
}