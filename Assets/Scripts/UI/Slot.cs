using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
	public Item Item { get; set; }
	public bool IsOccupied { get; set; }
	public int Quantity { get; set; } = 0;

	[SerializeField] private Image Icon;
	[SerializeField] private Sprite defaultIcon;
	[SerializeField] private TextMeshProUGUI text;

	private void Start()
	{
		UpdateQuantityUI();
	}

	public void SetItem(Item item)
	{
		Item = item;
		IsOccupied = true;
		SetIcon();
	}

	public void RemoveItem()
	{
		RemoveIcon();
		IsOccupied = false;
		Item = null;
	}

	public void UpdateQuantityUI()
	{
		if (Quantity > 1)
		{
			text.text = "x" + Quantity;
		}
		else
		{
			text.text = "";
		}
	}

	public void ClearSlot()
	{
		Item = null;
		Quantity = 0;
		Icon.sprite = defaultIcon;
		IsOccupied = false;
		text.text = "";
	}

	public void AddQuantity()
	{
		Quantity++;
		UpdateQuantityUI();
	}
	public void MinusQuantity()
	{
		Quantity--;
		UpdateQuantityUI();
	}

	private void SetIcon()
	{
		Icon.sprite = Item.Icon;
	}

	private void RemoveIcon()
	{
		Icon.sprite = defaultIcon;
	}
}
