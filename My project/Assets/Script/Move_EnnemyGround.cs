using UnityEngine;

public class Move_EnnemyGround : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distRayCast;

    private float _direction = 1;
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, new Vector3(_direction, -0.5f, 0), _distRayCast);
        RaycastHit2D hit2 = Physics2D.Raycast(gameObject.transform.position, new Vector3(_direction, 0, 0), _distRayCast);
        Debug.DrawRay(transform.position, new Vector3(_direction, -0.5f, 0) * _distRayCast, Color.red);
        Debug.DrawRay(transform.position, new Vector3(_direction, 0, 0) * _distRayCast, Color.red);
        if (hit.collider != null)
        {
            _direction = -_direction;
        }
        gameObject.transform.position += new Vector3(_speed * _direction * Time.fixedDeltaTime, 0, 0);
    }
}
