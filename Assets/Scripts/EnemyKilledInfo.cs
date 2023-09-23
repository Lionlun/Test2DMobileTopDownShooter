using TMPro;
using UnityEngine;

public class EnemyKilledInfo : MonoBehaviour, IDataSave
{
    public int OverallMonstersKilled { get; private set; }
	[SerializeField] private TextMeshProUGUI text;

	private void OnEnable()
	{
		GlobalEvents.OnEnemyDead += CountKills;
	}
	private void OnDisable()
	{
		GlobalEvents.OnEnemyDead -= CountKills;
	}

	public void LoadData(GameData data)
	{
		this.OverallMonstersKilled = data.MonstersKilled;
		UpdateText();
	}

	public void SaveData(ref GameData data)
	{
		Debug.Log("Kills are counted");
		data.MonstersKilled = this.OverallMonstersKilled;
	}
	private void CountKills()
	{
		OverallMonstersKilled++;
		UpdateText();
	}

	private void UpdateText()
	{
		text.text = "Monsters killed: " + OverallMonstersKilled; 
	}
}
