using System;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public float FxTime = 10;
    public Action<PowerUp> OnActivated;

    protected abstract void Activate(Player player);

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Activate(player);
            OnActivated.Invoke(this);
            Death();
        }
    }

    private void Death() => gameObject.SetActive(false);
}