using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public static bool _isGrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            _isGrounded = true;
            ShootPlayer.Instance._nbBullet = ShootPlayer.Instance._maxBullet;
            ShootPlayer.Instance.ResetImageBullet();
        }

        if (collision.gameObject.TryGetComponent(out Move_EnnemiFly EnnemiFly) || collision.gameObject.TryGetComponent(out Move_EnnemiWall EnnemiWall))
        {
            ShootPlayer.Instance.Jump(0.5f);
            ShootPlayer.Instance._nbBullet = ShootPlayer.Instance._maxBullet;
            ShootPlayer.Instance.ResetImageBullet();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
            _isGrounded = false;

    }
}
