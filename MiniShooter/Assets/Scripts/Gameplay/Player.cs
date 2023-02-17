using System;
using UnityEngine;

public class Player : MonoBehaviour, IHuman
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _health = 3;

    public Gun Gun;
    public Action OnDeath;

    private Camera _camera => Camera.main;

    private void FixedUpdate() => Movement();

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.forward * _moveSpeed;
        else if (Input.GetKey(KeyCode.S))
            transform.position -= Vector3.forward * _moveSpeed;

        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * _moveSpeed;
        else if (Input.GetKey(KeyCode.A))
            transform.position -= Vector3.right * _moveSpeed;

        //rotation
        var mousePos = Input.mousePosition;
        mousePos.z = Vector3.Distance(transform.position, _camera.transform.position);
        var point = _camera.ScreenToWorldPoint(mousePos);
        point.y = transform.position.y;

        transform.LookAt(point);
    }

    public void Shoot(IGun gun) => gun.Shoot();

    public void GetDamage(float value)
    {
        _health -= value;
        if (_health <= 0) Death();
    }

    private void Death()
    {
        Destroy(gameObject);
        OnDeath.Invoke();
    }
}