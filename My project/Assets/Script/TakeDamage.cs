using System.Collections;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private int _nbFlicker;
    [SerializeField] private float _speedFlicker;
    private bool _canTakeDamage = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.TryGetComponent(out Move_EnnemiFly EnnemiFly) || collision.gameObject.TryGetComponent(out Move_EnnemiWall EnnemiWall)) && _canTakeDamage
            && !collision.otherCollider.gameObject.TryGetComponent(out IsGrounded isGrounded))
        {
            _canTakeDamage = false;
            StartCoroutine(AnimationDeath(_speedFlicker));
        }
    }

    IEnumerator AnimationDeath(float seconds) 
    {
        for (int i = 0; i < _nbFlicker; i++)
        {
            yield return new WaitForSeconds(seconds);
            if (gameObject.GetComponent<SpriteRenderer>().enabled)
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            else
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        _canTakeDamage = true;
    }
}