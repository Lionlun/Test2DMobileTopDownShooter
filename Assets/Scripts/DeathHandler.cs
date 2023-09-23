using UnityEngine;


public class DeathHandler : MonoBehaviour
{
	public virtual void Die()
	{
		this.gameObject.SetActive(false);
	}
}
