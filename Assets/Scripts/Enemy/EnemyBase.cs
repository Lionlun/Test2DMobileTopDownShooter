using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
	protected int Id;


	public void SetId(int id)
	{
		Id = id;
	}
}
