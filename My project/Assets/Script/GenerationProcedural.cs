using UnityEngine;

public class GenerationProcedural : MonoBehaviour
{
    [SerializeField] private GameObject _blockDestructible;
    [SerializeField] private GameObject _blockInvinsible;
    [SerializeField] private GameObject _ennemiFly;
    [SerializeField] private GameObject _ennemiWall;

    [SerializeField] private Transform _player;

    [SerializeField] private int _seed;

    [SerializeField] private float _chanceSpawn;
    [SerializeField] private int _height;
    [SerializeField] private int _width;

    [SerializeField] private int _chanceSpawnEnnemiFly;
    [SerializeField] private int _chanceSpawnEnnemiWall;

    void Start()
    {
        _seed = Random.Range(-100000, 100000);
        GenerationMap();
    }

    public void GenerationMap()
    {
        for (int y = (int)_player.position.y - 2; y > -_height; y--)
        {
            for (int x = 0; x < _width; x++)
            {
                if (Mathf.PerlinNoise(x / 10f + _seed, y / 10f + _seed) >= _chanceSpawn)
                {
                    Instantiate(_blockDestructible, new Vector3(x, y), Quaternion.identity, gameObject.transform);
                }
                else if(Random.Range(0, _chanceSpawnEnnemiFly) == 0)
                {
                    GameObject ennemiFly = Instantiate(_ennemiFly, new Vector3(x, y), Quaternion.identity);
                }
                else if ((x == _width - 1 || x == 0) && Random.Range(0, _chanceSpawnEnnemiWall) == 0)
                {
                    GameObject ennemiWall = Instantiate(_ennemiWall, new Vector3(x, y), Quaternion.identity);
                }
            }
        }
    }
}
