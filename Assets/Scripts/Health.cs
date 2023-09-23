using UnityEngine;

[RequireComponent(typeof(DeathHandler))]
public class Health : MonoBehaviour
{
	public int CurrentHealth { get; set; }
	[SerializeField] private int maxHealth = 100;
	[SerializeField] protected HealthUI HealthUI;
	private DeathHandler DeathHandler;

	private void Awake()
	{
		Debug.Log("CURRENT HEALTH UPD");
		CurrentHealth = maxHealth;

	}
	private void Start()
	{
		DeathHandler = GetComponent<DeathHandler>();
	}

	public void GetHit(int damage) 
	{
		CurrentHealth -= damage;
		HealthUI.UpdateHealthBar(CurrentHealth);

		if (CurrentHealth <= 0) 
		{
			DeathHandler.Die();
		}
	}

	public void GetHealth(int health)
	{
		CurrentHealth += health;

		if (CurrentHealth > maxHealth)
		{
			CurrentHealth = maxHealth;
		}

		HealthUI.UpdateHealthBar(CurrentHealth);
	}

	public void UpdateHealthUI()
	{
		HealthUI.UpdateHealthBar(CurrentHealth);
	}
}
