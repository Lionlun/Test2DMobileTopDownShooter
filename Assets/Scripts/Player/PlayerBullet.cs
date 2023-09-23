using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	private int damage = 10;
	private int speed = 5;

	private void Update()
	{
		Move();
	}

	private void Move()
	{
		transform.position += transform.right * speed * Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<EnemyBase>() != null)
		{
			var enemyHealth = collision.gameObject.GetComponent<Health>();
			enemyHealth.GetHit(damage);
			Destroy(this.gameObject);
		}
	}
}
