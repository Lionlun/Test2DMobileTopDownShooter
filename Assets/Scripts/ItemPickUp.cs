using System;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
	public static Action<Item> OnPickUp;

	[SerializeField] private Item item;
	[SerializeField] private Inventory inventory;

	private void PickUp()
	{
		Inventory.Items.Add(item);
		OnPickUp?.Invoke(item);
		Destroy(gameObject);
	}

	private void OnMouseDown()
	{
		PickUp();
	}
}
