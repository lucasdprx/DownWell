using UnityEngine;

public class ColisionShoot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out InputPlayer Player))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
