using UnityEngine;

public class RemoveButton : MonoBehaviour
{
	[SerializeField] private Slot slot;
	[SerializeField] private SlotDistribution distribution;
	private bool isActive = false;
	
	public void Toggle()
	{
		isActive = !isActive;
		this.gameObject.SetActive(isActive);
	}

	public void Remove()
	{
		if(slot.Item != null)
		{
			distribution.Remove(slot);
		}
	}
}
