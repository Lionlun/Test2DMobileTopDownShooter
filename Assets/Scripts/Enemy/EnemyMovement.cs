using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float minDistanceToPlayer = 0.7f;
	private float speed = 2;

    private void MoveToPlayer(Vector3 player)
    {
		if (Vector3.Distance(transform.position, player) > minDistanceToPlayer)
		{
			transform.position = Vector3.MoveTowards(transform.position, player, speed * Time.deltaTime);
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
