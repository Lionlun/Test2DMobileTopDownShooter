using System.Collections.Generic;
using UnityEngine;

public class Inventory: MonoBehaviour, IDataSave
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

	public void UpdateAllItems()
	{
		slotsDistribution.ClearAllSlots();

		foreach (Item item in Items) 
		{
			slotsDistribution.Add(item);
		}
	}

	public void LoadData(GameData data)
	{
		Items = data.PlayerItems;
		UpdateAllItems();
	}

	public void SaveData(ref GameData data)
	{
		data.PlayerItems = Items;
	}
}
