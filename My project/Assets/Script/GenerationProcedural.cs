using UnityEngine;

public class GenerationProcedural : MonoBehaviour
{
    [Header("Tiles")]
    [SerializeField] private GameObject _blockDestructible;

    [Header("Ennemy")]
    [SerializeField] private GameObject _ennemyFly;
    [SerializeField] private GameObject _ennemyWall;
    [SerializeField] private GameObject _ennemyGround;

    [Header("Map")]
    [SerializeField] private Transform _player;
    [SerializeField] private int _seed;
    [SerializeField] private float _chanceSpawn;

    [Header("Lenght")]
    public int _height;
    [SerializeField] private int _width;

    [Header("ChanceSpawn")]
    [SerializeField] private int _chanceSpawnEnnemyFly;
    [SerializeField] private int _chanceSpawnEnnemyWall;
    [SerializeField] private int _chanceSpawnEnnemyGround;

    public static GenerationProcedural Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _height += PlayerPrefs.GetInt("level") * 50;
        _chanceSpawnEnnemyFly -= PlayerPrefs.GetInt("level") * 30;
        _chanceSpawnEnnemyWall -= PlayerPrefs.GetInt("level") * 5;
        _chanceSpawnEnnemyGround -= PlayerPrefs.GetInt("level") * 4;
        if (_chanceSpawnEnnemyGround < 0)
            _chanceSpawnEnnemyGround = 0;
        _seed = Random.Range(-100000, 100000);
        GenerationMap();
    }

    public void GenerationMap()
    {
        for (int y = (int)_player.position.y - 2; y > (int)_player.position.y - _height; y--)
        {
            for (int x = 0; x < _width; x++)
            {
                if (Mathf.PerlinNoise(x / 10f + _seed, y / 10f + _seed) >= _chanceSpawn)
                {
                    Instantiate(_blockDestructible, new Vector3(x, y), Quaternion.identity, gameObject.transform);
                }
                else if (Random.Range(0, _chanceSpawnEnnemyFly) == 0 && y < (int)_player.position.y - 5)
                {
                    GameObject ennemyFly = Instantiate(_ennemyFly, new Vector3(x, y), Quaternion.identity);
                }
                else if ((x == _width - 1 || x == 0) && Random.Range(0, _chanceSpawnEnnemyWall) == 0 && y < (int)_player.position.y - 5)
                {
                    GameObject ennemyWall = Instantiate(_ennemyWall, new Vector3(x, y), Quaternion.identity);
                    if (x == _width - 1)
                        ennemyWall.transform.Rotate(0, 180, 0);
                }
                else if (Mathf.PerlinNoise(x / 10f + _seed, (y - 1) / 10f + _seed) >= _chanceSpawn && Random.Range(0, _chanceSpawnEnnemyGround) == 0 && y < (int)_player.position.y - 4)
                {
                    GameObject ennemyGround = Instantiate(_ennemyGround, new Vector3(x, y), Quaternion.identity);
                }
            }
        }
    }
}
