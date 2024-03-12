using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;

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
            _rigidbody.AddForce(Vector2.left * _speed / 10, ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (_rigidbody.velocity.x < 0)
                _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
            _rigidbody.AddForce(Vector2.right * _speed / 10, ForceMode2D.Force);
        }
    }
}