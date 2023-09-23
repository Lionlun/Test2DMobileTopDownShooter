using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
	private Animator animator;
	private Rigidbody2D rb;
    private float minDistanceToPlayer = 0.7f;
	private float speed = 2;
	private Vector3 localScale;

	private void Start()
	{
		localScale = transform.localScale;
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	private void MoveToPlayer(Vector3 player)
    {
		if (Vector3.Distance(transform.position, player) > minDistanceToPlayer)
		{
			animator.SetBool("IsMoving", true);
			transform.position = Vector3.MoveTowards(transform.position, player, speed * Time.deltaTime);

			FlipTowardsPlayer(player);
		}

		else
		{
			animator.SetBool("IsMoving", false);
		}
    }
	
	private void FlipTowardsPlayer(Vector3 player)
	{
		if (transform.position.x > player.x)
		{
			this.gameObject.transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
		}
		else
		{
			this.gameObject.transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerMovement>() != null)
		{
			MoveToPlayer(collision.transform.position);
		}
	}
}

