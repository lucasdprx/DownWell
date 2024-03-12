using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _player;
    public void Update()
    {
        _camera.transform.position = new Vector3(_camera.transform.position.x, _player.transform.position.y - 3.0f, _camera.transform.position.z);
    }
}
