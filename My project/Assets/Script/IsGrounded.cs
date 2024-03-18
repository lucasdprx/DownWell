using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public static bool _isGrounded;
    [SerializeField] private ParticleSystem _particleFeather;
    [SerializeField] private ParticleSystem _particleFlask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            _isGrounded = true;
            ShootPlayer.Instance._nbBullet = ShootPlayer.Instance._maxBullet;
            ShootPlayer.Instance.ResetImageBullet();
        }

        if (collision.gameObject.TryGetComponent(out Move_EnnemiFly _))
        {
            _particleFeather.gameObject.transform.position = collision.transform.position;
            _particleFeather.Play();
            ShootPlayer.Instance.Jump(0.5f);
            ShootPlayer.Instance.AddImageBullet();
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.TryGetComponent(out Move_EnnemiWall _))
        {
            _particleFlask.gameObject.transform.position = collision.transform.position;
            _particleFlask.Play();
            ShootPlayer.Instance.Jump(0.5f);
            ShootPlayer.Instance.AddImageBullet();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
            _isGrounded = false;

    }
}
