using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
	public int Id { get; private set; }

	public void SetId(int id)
	{
		Id = id;
	}
}
