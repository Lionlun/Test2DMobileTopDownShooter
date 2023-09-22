using System;

public class GlobalEvents
{
	public static Action OnEnemyDead;

	public void SendEnemyDead()
	{
		OnEnemyDead?.Invoke();
	}
}
