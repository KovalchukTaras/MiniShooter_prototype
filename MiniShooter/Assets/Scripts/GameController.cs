using UnityEngine;

public class GameController : MonoBehaviour
{
    public UIController UIController;
    public Player Player;
    public EnemyCreator EnemyCreator;
    public PowerUpCreator PowerUpCreator;

    public static GameController Instance;
    private void Awake() => Instance = this;

    private void Start()
    {
        Time.timeScale = 1;
        Player.OnDeath += GameOver;

        EnemyCreator.CreateEnemies(10);
        PowerUpCreator.CreateRandom();
    }

    private void GameOver()
    {
        Time.timeScale = 0;
    }

    public void PauseTurnOn()
    {
        Time.timeScale = 0;
        UIController.ShowPauseMenu();
    }

    public void PauseTurnOff()
    {
        Time.timeScale = 1;
        UIController.HidePauseMenu();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}