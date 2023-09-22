using Unity.VisualScripting;

public class Enemy : EnemyBase
{
	private GlobalEvents globalEvents = new GlobalEvents();

	private void OnDestroy()
	{
		globalEvents.SendEnemyDead();
	}
}
