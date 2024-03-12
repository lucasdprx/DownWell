using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            _player.transform.position += new Vector3( -_speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _player.transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);
        }
    }
}
