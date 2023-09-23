using UnityEngine;

public class ArmProcedual : MonoBehaviour
{
	[SerializeField] private Transform target;

	private void Update()
	{
		transform.position = target.position;
	}
}
