using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthUI : MonoBehaviour
{
	private Slider slider;

	private void Start()
	{
		slider = GetComponent<Slider>();
	}

	public void UpdateHealthBar(int health)
	{
		slider.value = health;
	}
}
