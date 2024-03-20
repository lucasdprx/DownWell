using System.Collections;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private Transform _posShoot;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _speedShoot;

    public Rigidbody2D _rbPlayer;
    [SerializeField] private int _ForceJump;

    public int _maxBullet;
    public int _nbBullet;
    [SerializeField] private float _heightImageBullet;
    [SerializeField] private RectTransform _imageBullet;
    private Vector3 _initposImage;

    public ParticleSystem _particleShoot;
    public ParticleSystem _particleFeather;
    public ParticleSystem _particleFlask;
    public ParticleSystem _particleExplosion;

    public static ShootPlayer Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _nbBullet = _maxBullet;
        _initposImage = _imageBullet.position;
        _imageBullet.sizeDelta = new Vector2(_imageBullet.sizeDelta.x, _heightImageBullet);
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !GamePaused._gameIsPaused && !TextProgression._win)
        {
            if (IsGrounded._isGrounded)
                Jump(0.75f);
            else if (_nbBullet > 0)
            {
                SpawnBullet();
                _particleShoot.Play();
                _nbBullet--;
                UpdateImageBullet();
            }
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
        bal.GetComponent<Rigidbody2D>().AddForce(Vector2.down * _speedShoot, ForceMode2D.Force);
        InputPlayer.Instance._rigidbody.velocity = new Vector2(InputPlayer.Instance._rigidbody.velocity.x, 1);
        StartCoroutine(DespawnBullet(0.5f, bal));
    }

    public void Jump(float multiplier)
    {
        _rbPlayer.velocity = new Vector2(_rbPlayer.velocity.x, 0);
        _rbPlayer.AddForce(Vector2.up * _ForceJump * multiplier, ForceMode2D.Force);
    }
    public void UpdateImageBullet()
    {
        _imageBullet.sizeDelta = new Vector2(_imageBullet.sizeDelta.x, _heightImageBullet / _maxBullet * _nbBullet);
        _imageBullet.transform.position -= new Vector3(0, _heightImageBullet / (_maxBullet * 2) , 0);
    }

    public void ResetImageBullet()
    {
        _imageBullet.sizeDelta = new Vector2(_imageBullet.sizeDelta.x, _heightImageBullet);
        _imageBullet.transform.position = _initposImage;
    }

    public void AddImageBullet()
    {
        if (_nbBullet < _maxBullet)
        {
            _nbBullet++;
            _imageBullet.sizeDelta = new Vector2(_imageBullet.sizeDelta.x, _heightImageBullet / _maxBullet * _nbBullet);
            _imageBullet.transform.position += new Vector3(0, _heightImageBullet / (_maxBullet * 2), 0);
        }
    }
    public void SpawnParticle(Collision2D collision, ParticleSystem _particle)
    {
        _particle.transform.position = collision.transform.position;
        _particle.Play();
    }
}
