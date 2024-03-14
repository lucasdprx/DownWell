using UnityEngine;

public class ColisionShoot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out InputPlayer Player) && collision.gameObject.layer != 6)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
