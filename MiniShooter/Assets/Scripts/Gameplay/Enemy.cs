using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IHuman
{
    public EnemySO EnemySO;
    public Gun Gun;

    [HideInInspector] public Transform MoveTarget;

    [HideInInspector] public bool Freeze;
    [HideInInspector] public bool DamageIncrease;

    public Action<Enemy> OnDeath;

    private float _moveSpeed;
    private float _health;

    private void OnEnable() => UpdateData();

    private void FixedUpdate()
    {
        Movement(MoveTarget);
        Shooting();
    }

    private void Movement(Transform moveTarget)
    {
        if (moveTarget == null || Freeze) return;

        transform.position += transform.forward * _moveSpeed;
        transform.LookAt(moveTarget.position);
    }

    private void Shooting()
    {
        if (Gun.Recharged && !Freeze) Shoot(Gun);
    }

    private void UpdateData()
    {
        _health = EnemySO.Health;
        _moveSpeed = EnemySO.MoveSpeed;
    }

    public void Shoot(IGun gun) => gun.Shoot();

    public void GetDamage(float value)
    {
        if (DamageIncrease) value *= 2;
        _health -= value;

        if (_health <= 0) Death();
        Debug.Log($"Hit. Damage Value = {value}");
    }

    private void Death()
    {
        gameObject.SetActive(false);
        OnDeath.Invoke(this);
        Freeze = false;

        ScoreCounter.Instance.Score += 1;
    }
}
