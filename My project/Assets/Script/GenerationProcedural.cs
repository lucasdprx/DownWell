using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenerationProcedural : MonoBehaviour
{
    [SerializeField] private GameObject _blockDestructible;
    [SerializeField] private GameObject _blockInvinsible;

    [SerializeField] private int _widht;
    [SerializeField] private int _height;

    private List<List<int>> _blocks = new();
    void Start()
    {
        for (int i = 0; i < _widht; i++)
        {
            _blocks.Add(new List<int>(_height));
            for (int j = 0; j < _height; j++)
            {
                _blocks[i].Add(0);
            }
        }
        GenerationMapLeft();
        GenerationMapRight();
        GenerateBlockDestructible();
    }

    private void GenerationMapLeft()
    {
        int _rand = Random.Range(0, _height / 2);
        for (int i  = 0; i < _widht; i++)
        {
            for (int j = 0; j < _rand; j++)
            {
                GameObject tile = Instantiate(_blockDestructible, new Vector3(j, i), Quaternion.identity);
                _blocks[i][j] = 1;
            }
            _rand += Random.Range(-2, 3);
            if (_rand > (_height - 1) / 2)
                _rand = (_height - 1) / 2;
            if (_rand < 0)
                _rand = 0;
            Instantiate(_blockDestructible, new Vector3(0, i), Quaternion.identity);
            _blocks[i][0] = 1;
        }
    }
    private void GenerationMapRight()
    {
        int _rand = Random.Range(0, _height / 2);
        for (int i = 0; i < _widht; i++)
        {
            for (int j = 0; j < _rand; j++)
            {
                GameObject tile = Instantiate(_blockDestructible, new Vector3(_height - 1 - j, i), Quaternion.identity);
                _blocks[i][_height - 1 - j] = 1;
            }
            _rand += Random.Range(-2, 3);
            if (_rand > (_height - 1) / 2)
                _rand = (_height - 1) / 2;
            if (_rand < 0)
                _rand = 0;
            Instantiate(_blockDestructible, new Vector3(_height - 1, i), Quaternion.identity);
            _blocks[i][_height - 1] = 1;
        }
    }

    private void GenerateBlockDestructible()
    {
        for (int i = 0; i < _widht; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                if (Random.Range(0,8) == 0)
                    if (_blocks[i][j] == 0 && _blocks[i][j + 1] == 0)
                    {
                        Instantiate(_blockInvinsible, new Vector3(j, i), Quaternion.identity);
                        Instantiate(_blockInvinsible, new Vector3(j + 1, i), Quaternion.identity);
                    }
                else if (Random.Range(0, 8) == 1)
                        for (int k = 0; k < 3; k++)
                        {

                        }
            }
        }
    }
}
