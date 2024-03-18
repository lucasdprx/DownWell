using UnityEngine;

public class ColisionShoot : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Move_EnnemiFly _))
        {
            ShootPlayer.Instance.ParticleFeather(collision);
            ShootPlayer.Instance.AddImageBullet();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if (collision.gameObject.TryGetComponent(out Move_EnnemiWall _))
        {
            ShootPlayer.Instance.ParticleFlaske(collision);
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
