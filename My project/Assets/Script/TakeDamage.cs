using System.Collections;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private int _nbFlicker;
    [SerializeField] private float _speedFlicker;
    [SerializeField] private float _timeScale;
    private bool _canTakeDamage = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.TryGetComponent(out Move_EnnemiFly EnnemiFly) || collision.gameObject.TryGetComponent(out Move_EnnemiWall EnnemiWall)) && _canTakeDamage
            && !collision.otherCollider.gameObject.TryGetComponent(out IsGrounded isGrounded))
        {
            AudioManager.Instance.PlaySong("Damage");
            LifeBar.Instance.UpdateImageLifeBar();
            if (!LifeBar.Instance._isDeath)
            {
                _canTakeDamage = false;
                FeedBackDamage._heTakeDamage = true;
                StartCoroutine(AnimationDeath(_speedFlicker));
            }
        }
    }

    IEnumerator AnimationDeath(float seconds) 
    {
        Time.timeScale = _timeScale;
        for (int i = 0; i < _nbFlicker; i++)
        {
            yield return new WaitForSeconds(seconds);
            if (gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled)
                gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
            else
                gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
        }
        gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
        _canTakeDamage = true;
        Time.timeScale = 1.0f;
    }
}
