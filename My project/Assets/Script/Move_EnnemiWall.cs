using UnityEngine;

public class Move_EnnemiWall : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distRayCast;
    private float _direction = 1;
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _direction * Vector2.up, _distRayCast);
        if (hit.collider != null)
            if (hit.collider.gameObject.layer == 7)
            {
                _direction = -_direction;
                gameObject.transform.Rotate(new Vector3(0f, 180f, 0f));
            }
        gameObject.transform.position += new Vector3(0, _speed * _direction * Time.fixedDeltaTime, 0);
    }
}
