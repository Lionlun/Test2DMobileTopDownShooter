using UnityEngine;

public class OnMouseFilter : MonoBehaviour
{
	[SerializeField] private LayerMask affectedLayers;

	private void Start()
	{
		Camera.main.eventMask = affectedLayers;
	}
}
