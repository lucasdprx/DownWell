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
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
            _isGrounded = false;
    }
}
