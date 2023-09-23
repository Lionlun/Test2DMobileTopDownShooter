using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour, IDataSave
{
	[SerializeField] private Joystick joystick;
	private Animator animator;
	private Rigidbody2D rb;
	private Vector3 localScale;
	private int speed = 3;
	

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		localScale = transform.localScale;
	}

	private void FixedUpdate()
	{
		Move();
		Flip();
	}

	private void Move()
	{
		rb.velocity = new Vector3(joystick.Horizontal*speed, joystick.Vertical*speed, 0);
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
	
	private void Flip()
	{
		if (rb.velocity.x >= 0)
		{
			this.gameObject.transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
		}
		else 
		{
			this.gameObject.transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
		}
	}
}
