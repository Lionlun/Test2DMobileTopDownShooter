using UnityEngine;

[RequireComponent(typeof(DeathHandler))]
public class Health : MonoBehaviour
{
	public int CurrentHealth { get; set; }
	[SerializeField] private int maxHealth = 100;
	[SerializeField] private HealthUI healthUI;
	private DeathHandler deathHandler;

	private void Start()
	{
		CurrentHealth = maxHealth;
		deathHandler = GetComponent<DeathHandler>();
	}

	public void GetHit(int damage) 
	{
		CurrentHealth -= damage;
		healthUI.UpdateHealthBar(CurrentHealth);

		if (CurrentHealth <= 0) 
		{
			deathHandler.Die();
		}
	}

	public void GetHealth(int health)
	{
		CurrentHealth += health;

		if (CurrentHealth > maxHealth)
		{
			CurrentHealth = maxHealth;
		}

		healthUI.UpdateHealthBar(CurrentHealth);
	}
}
