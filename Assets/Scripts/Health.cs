using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private int maxHealth = 100;
	[SerializeField] private HealthUI healthUI;
	private int currentHealth;

	private void Start()
	{
		currentHealth = maxHealth;
	}

	public void GetHit(int damage) 
	{
		currentHealth -= damage;
		healthUI.UpdateHealthBar(currentHealth);

		if (currentHealth <= 0) 
		{
			Die();
		}
	}

	public void GetHealth(int health)
	{
		currentHealth += health;

		if (currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}

		healthUI.UpdateHealthBar(currentHealth);
	}

	private void Die()
	{
		Destroy(this.gameObject);
	}
}
