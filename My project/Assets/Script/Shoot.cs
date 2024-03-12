using System.Collections;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private Transform _posShoot;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _speedShoot;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBullet();
        }
    }

    IEnumerator DespawnBullet(float seconde, GameObject _gameObject)
    {
        yield return new WaitForSeconds(seconde);
        Destroy(_gameObject);
    }

    private void SpawnBullet()
    {
        GameObject bal = Instantiate(_bullet, _posShoot);
        bal.GetComponent<Rigidbody2D>().AddForce(-Vector2.up * _speedShoot, ForceMode2D.Force);
        InputPlayer.Instance._rigidbody.velocity = new Vector2(InputPlayer.Instance._rigidbody.velocity.x, 1);
        bal.AddComponent<ColisionShoot>();
        StartCoroutine(DespawnBullet(0.5f, bal));
    }
}
