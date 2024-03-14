using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;

    public Rigidbody2D _rigidbody;

    public static InputPlayer Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (_rigidbody.velocity.x > 0)
                _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
            if (_rigidbody.velocity.x > -_maxSpeed)
            {
                _rigidbody.AddForce(Vector2.left * _speed / 10, ForceMode2D.Force);
                if (_rigidbody.velocity.x < -_maxSpeed)
                    _rigidbody.velocity = new Vector2(-_maxSpeed, _rigidbody.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (_rigidbody.velocity.x < 0)
                _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);

            if (_rigidbody.velocity.x < _maxSpeed)
            {
                _rigidbody.AddForce(Vector2.right * _speed / 10, ForceMode2D.Force);
                if (_rigidbody.velocity.x > _maxSpeed)
                    _rigidbody.velocity = new Vector2(_maxSpeed, _rigidbody.velocity.y);
            }
        }
    }
}