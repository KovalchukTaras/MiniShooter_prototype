public class PowerUpFreeze : PowerUp
{
    protected override void Activate(Player player)
    {
        GameController.Instance.EnemyCreator.FreezeEnemies(FxTime);
    }
}