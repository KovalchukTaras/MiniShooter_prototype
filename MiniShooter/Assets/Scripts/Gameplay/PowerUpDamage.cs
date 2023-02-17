public class PowerUpDamage : PowerUp
{
    protected override void Activate(Player player)
    {
        GameController.Instance.EnemyCreator.IncreaseDamage(FxTime);
    }
}