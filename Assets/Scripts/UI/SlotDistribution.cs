using System.Collections.Generic;
using UnityEngine;

public class SlotDistribution : MonoBehaviour
{
	[SerializeField] private List<Slot> slots;
	private Dictionary<int, int> ocuppiedSlots = new Dictionary<int, int>();
	private int currentSlotIndex = 0;

	public void Add(Item item)
	{
		if (ocuppiedSlots.ContainsKey(item.Id))
		{
			var slotIndex = ocuppiedSlots[item.Id];
			slots[slotIndex].Quantity++;
			slots[slotIndex].SetQuantity();
		}
		else
		{
			for (int i = 0; i < slots.Count; i++)
			{
				if (!slots[i].IsOccupied)
				{
					slots[i].SetItem(item);
					slots[i].Quantity++;
					slots[i].SetQuantity();
					ocuppiedSlots.Add(item.Id, i);
					return;
				}
				else
				{
					Debug.Log("Cell is occupied");
				}
			}
		}
	}

	public void Remove(Slot slot)
	{
		var slotIndex = ocuppiedSlots[slot.Item.Id];

		if(slots[slotIndex].Quantity > 1)
		{
			slots[slotIndex].Quantity--;
			slots[slotIndex].SetQuantity();
		}
		else if(slots[slotIndex].Quantity <= 1)
		{
			ocuppiedSlots.Remove(slots[slotIndex].Item.Id);
			slots[slotIndex].Quantity--;
			slots[slotIndex].SetQuantity();
			slots[slotIndex].RemoveItem();
		}
	}
}
