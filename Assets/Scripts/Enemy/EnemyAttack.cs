using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	private bool isWithinAttackRange;
	private int damage = 10;
	private Health playerHealth;
	private float attackCooldown;
	private float attackCooldownRefresh = 1f;
	[SerializeField] private Animator animator;

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
			animator.SetBool("IsAttacking", true);
			playerHealth.GetHit(damage);
			attackCooldown = attackCooldownRefresh;
		}
		else
		{
			animator.SetBool("IsAttacking", false);
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
			playerHealth = collision.gameObject.GetComponent<Health>();
			isWithinAttackRange = true; 
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
