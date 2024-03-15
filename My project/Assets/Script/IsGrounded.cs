using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public static bool _isGrounded;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            _isGrounded = true;
            ShootPlayer.Instance._nbBullet = ShootPlayer.Instance._maxBullet;
            ShootPlayer.Instance.ResetImageBullet();
        }
        
        if (other.TryGetComponent(out Move_EnnemiFly EnnemiFly) || other.TryGetComponent(out Move_EnnemiWall EnnemiWall))
        {
            ShootPlayer.Instance.Jump(0.5f);
            ShootPlayer.Instance._nbBullet = ShootPlayer.Instance._maxBullet;
            ShootPlayer.Instance.ResetImageBullet();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
            _isGrounded = false;
    }
}
