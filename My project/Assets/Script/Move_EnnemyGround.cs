using UnityEngine;

public class Move_EnnemyGround : MonoBehaviour
{
    [SerializeField] private float _forceExplosion;
    [SerializeField] private ParticleSystem _particleExplosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out InputPlayer _) || collision.gameObject.TryGetComponent(out IsGrounded _))
        {
            ShootPlayer.Instance.SpawnParticle(collision, ShootPlayer.Instance._particleExplosion);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.rigidbody.velocity.x, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * _forceExplosion, ForceMode2D.Force);
            FeedBackDamage._heTakeDamage = true;
            LifeBar.Instance.UpdateImageLifeBar();
            Destroy(gameObject);
        }
        if (collision.gameObject.TryGetComponent(out ColisionShoot _))
        {
            ShootPlayer.Instance.SpawnParticle(collision, ShootPlayer.Instance._particleExplosion);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
