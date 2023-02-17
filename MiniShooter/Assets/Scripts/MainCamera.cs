using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _difference;

    void Start() => _difference = transform.position - _player.position;

    void FixedUpdate()
    {
        if (_player != null)
            transform.position = _player.position + _difference;
    }
}