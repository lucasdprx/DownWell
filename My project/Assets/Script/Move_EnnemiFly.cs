using UnityEngine;

public class Move_EnnemiFly : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distRayCast;
    private float _direction = 1;

    [SerializeField] private float _distEnnemi;

    private bool _isFollow;
    void FixedUpdate()
    {
        if (Vector3.Distance(ShootPlayer.Instance._rbPlayer.gameObject.transform.position, gameObject.transform.position) <= _distEnnemi)
        {
            RotateSprite();
            if (Vector3.Distance(ShootPlayer.Instance._rbPlayer.gameObject.transform.position, gameObject.transform.position) >= 2)
                MoveEnnemyFly();
        }
        else
        {
            Patrol();
        }
    }

    private void RotateSprite()
    {
        _isFollow = true;
        if (gameObject.GetComponentInChildren<SpriteRenderer>().flipX)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        Vector3 dir = ShootPlayer.Instance._rbPlayer.transform.position - gameObject.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, gameObject.transform.rotation.y, 1));

        if (gameObject.transform.eulerAngles.z > 90 && gameObject.transform.eulerAngles.z <= 270)
            gameObject.GetComponentInChildren<SpriteRenderer>().flipY = true;
        else
            gameObject.GetComponentInChildren<SpriteRenderer>().flipY = false;
    }

    private void Patrol()
    {
        if (_isFollow)
        {
            gameObject.transform.eulerAngles = Vector3.zero;
            _isFollow = false;
            gameObject.GetComponentInChildren<SpriteRenderer>().flipY = false;
        }

        if (_direction < 0)
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
        else
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _direction * Vector2.right, _distRayCast);
        if (hit.collider != null)
            if (hit.collider.gameObject.layer == 7 || hit.collider.gameObject.layer == 6)
            {
                _direction = -_direction;
            }
        gameObject.transform.position += new Vector3(_speed * _direction * Time.deltaTime, 0, 0);
    }

    private void MoveEnnemyFly()
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, transform.right, _distRayCast * 2);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.layer != 7 && hit.collider.gameObject.layer != 6)
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, ShootPlayer.Instance._rbPlayer.transform.position, _speed * Time.fixedDeltaTime);
        }
        else
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, ShootPlayer.Instance._rbPlayer.transform.position, _speed * Time.fixedDeltaTime);
    }
}
