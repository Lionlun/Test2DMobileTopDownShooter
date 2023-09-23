using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IDataSave
{
	[SerializeField] private Joystick joystick;
	private Rigidbody2D rb;
	private int speed = 3;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		Move();
	}
	private void Move()
	{
		rb.velocity = new Vector3(joystick.Horizontal*speed, joystick.Vertical*speed, 0);
	}

	public void LoadData(GameData data)
	{
		this.transform.position = data.PlayerPosition;
	}

	public void SaveData(ref GameData data)
	{
		data.PlayerPosition = this.transform.position;
	}
}
