using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public List<Enemy> EnemiesInScene;
    [Space]
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Player _player;

    public void CreateEnemies(int enemiesCount)
    {
        EnemiesInScene = new List<Enemy>();

        for (int i = 0; i < enemiesCount; i++)
        {
            var enemy = Instantiate(_enemyPrefab, RandomEnemyPosition(45), Quaternion.identity);
            enemy.MoveTarget = _player.transform;
            enemy.OnDeath += RestartEnemy;
            EnemiesInScene.Add(enemy);
        }
    }

    private Vector3 RandomEnemyPosition(float groundSize)
    {
        return new Vector3(
            UnityEngine.Random.Range(-groundSize, groundSize),
            1,
            UnityEngine.Random.Range(-groundSize, groundSize)
            );
    }

    private async void RestartEnemy(Enemy enemy)
    {
        await Task.Delay(TimeSpan.FromSeconds(4));

        if (enemy == null) return;
        enemy.gameObject.SetActive(true);
        enemy.transform.position = RandomEnemyPosition(45);
    }

    public async void FreezeEnemies(float time)
    {
        foreach (var enemy in EnemiesInScene)
            enemy.Freeze = true;

        await Task.Delay(TimeSpan.FromSeconds(time));

        foreach (var enemy in EnemiesInScene)
            enemy.Freeze = false;
    }

    public async void IncreaseDamage(float time)
    {
        foreach (var enemy in EnemiesInScene)
            enemy.DamageIncrease = true;

        await Task.Delay(TimeSpan.FromSeconds(time));

        foreach (var enemy in EnemiesInScene)
            enemy.DamageIncrease = false;
    }
}
