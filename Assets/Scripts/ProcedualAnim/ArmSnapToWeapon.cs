using UnityEngine;

public class ArmSnapToWeapon : MonoBehaviour
{
	[SerializeField] private Transform target;

	private void Update()
	{
		transform.position = target.position;
	}
}
