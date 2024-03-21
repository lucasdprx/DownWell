using UnityEngine;

public class ColisionShoot : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Move_EnnemiFly _))
        {
            AudioManager.Instance.PlaySong("Bird");
            ShootPlayer.Instance.SpawnParticle(collision, ShootPlayer.Instance._particleFeather);
            ShootPlayer.Instance.AddImageBullet();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if (collision.gameObject.TryGetComponent(out Move_EnnemiWall _))
        {
            AudioManager.Instance.PlaySong("Snail");
            ShootPlayer.Instance.SpawnParticle(collision, ShootPlayer.Instance._particleFlask);
            ShootPlayer.Instance.AddImageBullet();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 7)
        {
            AudioManager.Instance.PlaySong("Break");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
