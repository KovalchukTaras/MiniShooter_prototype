using System;
using System.Threading.Tasks;
using UnityEngine;

public class PowerUpCreator : MonoBehaviour
{
    public float RestartTime = 5f;
    public PowerUp[] PowerUpPrefabs;

    public void CreateRandom()
    {
        int num = UnityEngine.Random.Range(0, PowerUpPrefabs.Length);

        var obj = Instantiate(PowerUpPrefabs[num], RandomPosition(45), Quaternion.identity);
        obj.OnActivated += RestartPowerUp;
    }

    private Vector3 RandomPosition(float groundSize)
    {
        return new Vector3(
            UnityEngine.Random.Range(-groundSize, groundSize),
            1.22f,
            UnityEngine.Random.Range(-groundSize, groundSize)
            );
    }

    public async void RestartPowerUp(PowerUp powerUp)
    {
        await Task.Delay(TimeSpan.FromSeconds(RestartTime));

        if (powerUp == null) return;
        powerUp.gameObject.SetActive(true);
        powerUp.transform.position = RandomPosition(45);
    }
}