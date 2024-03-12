using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedMax;

    [SerializeField] private Rigidbody2D _rigidbody;
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (_rigidbody.velocity.magnitude < _speedMax)
                _rigidbody.AddForce(Vector2.left * _speed, ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (_rigidbody.velocity.magnitude <_speedMax)
                 _rigidbody.AddForce(Vector2.right * _speed, ForceMode2D.Force);

        }
    }
}