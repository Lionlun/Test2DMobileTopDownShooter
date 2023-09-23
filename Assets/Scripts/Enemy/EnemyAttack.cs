using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	private bool isWithinAttackRange;
	private int damage = 10;
	private Health playerHealth;
	private float attackCooldown;
	private float attackCooldownRefresh = 1f;

	private void Start()
	{
		attackCooldown = attackCooldownRefresh;
	}

	private void Update()
	{
		HandleAttackCooldown();
		Attack();
	}
	private void Attack()
	{
		if(isWithinAttackRange && attackCooldown <=0)
		{
			Debug.Log("Attack!");
			playerHealth.GetHit(damage);
			attackCooldown = attackCooldownRefresh;
		}
	}

	private void HandleAttackCooldown()
	{
		if (attackCooldown > 0)
		{
			attackCooldown -= Time.deltaTime;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerMovement>() != null)
		{
			isWithinAttackRange = true;
			playerHealth = collision.gameObject.GetComponent<Health>();
			
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerMovement>() != null)
		{
			isWithinAttackRange = false;
		}
	}
}
