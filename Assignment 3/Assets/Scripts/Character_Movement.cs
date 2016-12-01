using UnityEngine;
using System.Collections;

// The line directly below forces the game object to have a Rigidbody2D
	[RequireComponent(typeof(Rigidbody2D))]
	public class Character_Movement : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector2 userInput;
	public Character_Attributes Player;
	public float Speed_Count_Down = 5;
	public float Health_Count_Down = 2;
	public float Game_Time = 180;




	// Use this for initialization
	void Start () {
		// Ask our game object for the rigidbody 2d component
		rb = gameObject.GetComponent<Rigidbody2D>();
		Player = FindObjectOfType<Character_Attributes> ();
		Sound_Controller.On_Background_music ();
			}
	
	// Update is called once per frame
	void Update () {
		// Retrieve the axes
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		
		// store the axes in the user input variable
		userInput = new Vector2(horizontal, vertical);
		Count_Down_Timer ();
		Health_Check ();

	}
	
	void FixedUpdate()
	{
		// Method 2 - teleport with collision checks
		Vector2 newPosition = transform.position;
		newPosition += userInput * Player.movement_speed * Time.fixedDeltaTime;
		rb.MovePosition(newPosition);

	}

	void OnCollisionEnter2D (Collision2D collision)
	{

	}

	void OnCollisionStay2D (Collision2D collision)
	{

	}

	void OnCollisionExit2D (Collision2D collision)
	{

	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Health") {
			Player.Health = Player.Health - 10;
			Health_Count_Down = 1;
			Debug.Log (Player.Health);
			Sound_Controller.On_Health_Damage ();

		}

		if (collider.tag == "Speed") {
			if (Player.movement_speed < 15) {
				Player.movement_speed = Player.movement_speed + 5;
				Sound_Controller.On_Speed_Up ();
			}
		}

		if (collider.tag == "Freeze") {
			Player.movement_speed = 0;
			Sound_Controller.On_Freeze ();
			
		}
	}

	void OnTriggerStay2D (Collider2D collider)
	{
		if (collider.tag == "Health")
		{
			Health_Count_Down -=Time.deltaTime;
			if (Health_Count_Down <=0)
			{
			Player.Health = Player.Health - 10;
			Debug.Log (Player.Health);
			Health_Count_Down = 1;
			}
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{

	}

	void Count_Down_Timer()
	{
		Speed_Count_Down -= Time.deltaTime;
			if ( Speed_Count_Down <= 0)
		{ 
			Player.movement_speed = 5f;
			Speed_Count_Down = 5;
		}

		Game_Time -= Time.deltaTime;
			if (Game_Time <=0)
		{
			Application.LoadLevel("You_Lost");
		}

	}

	void Health_Check()
	{
		if (Player.Health <=0)
		{
			Application.LoadLevel("You_Lost");
		}
	}
}