using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour
{
	public static List<Item> Items { get; private set; } = new List<Item>();
	[SerializeField] private SlotDistribution slotsDistribution;

	private void OnEnable()
	{
		ItemPickUp.OnPickUp += ListItems;
	}

	private void OnDisable()
	{
		ItemPickUp.OnPickUp -= ListItems;
	}

	public void ListItems(Item item)
	{
		slotsDistribution.Add(item);
	}
}
