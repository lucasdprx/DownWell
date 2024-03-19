using UnityEngine;

public class ColisionShoot : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Move_EnnemiFly _))
        {
            ShootPlayer.Instance.SpawnParticle(collision, ShootPlayer.Instance._particleFeather);
            ShootPlayer.Instance.AddImageBullet();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if (collision.gameObject.TryGetComponent(out Move_EnnemiWall _))
        {
            ShootPlayer.Instance.SpawnParticle(collision, ShootPlayer.Instance._particleFlask);
            ShootPlayer.Instance.AddImageBullet();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
