using System;
using System.Threading.Tasks;
using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    public string BulletName;

    [SerializeField] private Transform _bulletStartPos;
    [SerializeField] private float _rechargeTime = .5f;

    public bool Recharged = true;

    private void Start()
    {
        if (!Recharged) Recharging();
    }

    public void Shoot()
    {
        if (!Recharged) return;

        ObjectPooler.Instance.SpawnFromPool(BulletName, _bulletStartPos.position, transform.rotation);

        Recharged = false;
        Recharging();
    }

    public async void Recharging()
    {
        await Task.Delay(TimeSpan.FromSeconds(_rechargeTime));
        Recharged = true;
    }
}
