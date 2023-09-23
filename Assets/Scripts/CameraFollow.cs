using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform player;
	private Vector3 zOffset = new Vector3(0, 0, -10);

	private void Update()
	{
		FollowPlayer();
	}

	private void FollowPlayer()
	{
		if (player != null)
		{
			transform.position = player.position + zOffset;
		}
	}
}
