using UnityEngine;

public class ColisionShoot : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Move_EnnemiFly _))
        {
            ShootPlayer.Instance.ParticleFeather(collision);
        }

        if (collision.gameObject.TryGetComponent(out Move_EnnemiFly EnnemiFly) || collision.gameObject.TryGetComponent(out Move_EnnemiWall EnnemiWall))
        {
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
