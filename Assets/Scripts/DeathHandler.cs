using UnityEngine;


public class DeathHandler : MonoBehaviour
{
	public virtual void Die()
	{
		Destroy(this.gameObject);
	}
}
