using UnityEngine;

public class Move_Ennemi : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distRayCast;
    private float _direction = 1;
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _direction * Vector2.right, _distRayCast);
        if (hit.collider != null)
            if (hit.collider.gameObject.layer == 7 || hit.collider.gameObject.layer == 6)
                _direction = -_direction;
        gameObject.transform.position += new Vector3(_speed * _direction * Time.deltaTime, 0, 0);

    }
}