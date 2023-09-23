using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour, IDataSave
{
	[SerializeField] private Joystick joystick;
	private Animator animator;
	private Rigidbody2D rb;
	private int speed = 3;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	private void FixedUpdate()
	{
		Move();
	}
	private void Move()
	{
		rb.velocity = new Vector3(joystick.Horizontal*speed, joystick.Vertical*speed, 0);
		Debug.Log(rb.velocity.magnitude);
		animator.SetFloat("Speed", rb.velocity.magnitude);
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
