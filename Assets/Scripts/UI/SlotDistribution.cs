using System.Collections.Generic;
using UnityEngine;

public class SlotDistribution : MonoBehaviour
{
	[SerializeField] private List<Slot> slots;
	private Dictionary<int, int> ocuppiedSlots = new Dictionary<int, int>();

	public void Add(Item item)
	{
		if (ocuppiedSlots.ContainsKey(item.Id))
		{
			var slotIndex = ocuppiedSlots[item.Id];
			slots[slotIndex].AddQuantity();
		}
		else
		{
			for (int i = 0; i < slots.Count; i++)
			{
				if (!slots[i].IsOccupied)
				{
					slots[i].SetItem(item);
					slots[i].AddQuantity();
					ocuppiedSlots.Add(item.Id, i);
					return;
				}
			}
		}
	}

	public void Remove(Slot slot)
	{
		var slotIndex = ocuppiedSlots[slot.Item.Id];

		if(slots[slotIndex].Quantity > 1)
		{
			slots[slotIndex].MinusQuantity();
		}
		else if(slots[slotIndex].Quantity <= 1)
		{
			ocuppiedSlots.Remove(slots[slotIndex].Item.Id);
			slots[slotIndex].MinusQuantity();
			slots[slotIndex].RemoveItem();
		}
	}

	public void ClearAllSlots()
	{
		foreach(var slot in slots)
		{
			slot.ClearSlot();
		}
	}
}
