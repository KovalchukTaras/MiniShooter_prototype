using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1;
    [SerializeField] private float _damage = 1;

    private const float _destroyTime = 2f;
    private float _timer;

    private void FixedUpdate()
    {
        transform.position += transform.forward * _moveSpeed;

        Timer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHuman human))
            human.GetDamage(_damage);

        Destroy();
    }

    private void Timer()
    {
        _timer += Time.deltaTime;
        if (_timer >= _destroyTime)
        {
            Destroy();
            _timer = 0;
        }
    }

    private void Destroy() => gameObject.SetActive(false);
}

