using UnityEngine;
using System.Collections;

// The line directly below forces the game object to have a Rigidbody2D
	[RequireComponent(typeof(Rigidbody2D))]
	
public class Character_Movement : MonoBehaviour {

	// Rigidboy of character
	private Rigidbody2D RB;
	// User input vector input
	private Vector2 userInput;
	// Character Attributes access
	public Character_Attributes Player;
	//Set speed count down
	public float Speed_Count_Down = 5;
	//Set health count down
	public float Health_Count_Down = 2;
	// Music playing Bool
	public bool Music_Playing = true;




	// Use this for initialization
	void Start () 
	{
		// Ask our game object for the rigidbody 2d component
		RB = gameObject.GetComponent<Rigidbody2D>();
		// Set the player attributes
		Player = FindObjectOfType<Character_Attributes> ();
		UI_Manager.Instance.UpdateHealth();
		UI_Manager.Instance.UpdateSpeed ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		// Retrieve the axes
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		
		// store the axes in the user input variable
		userInput = new Vector2(horizontal, vertical);
		//Runs the count down timer
		Count_Down_Timer ();
		// Runs health check
		Health_Check ();
		// Runs the background music
		Background_Music ();
		//Update the Time Displayed
		UI_Manager.Instance.UpdateTime ();

	}

	// Movement control
	void FixedUpdate()
	{
		// teleport player with collision checks
		// transform the postion of the player
		Vector2 newPosition = transform.position;
		// move player over time
		newPosition += userInput * Player.Movement_Speed * Time.fixedDeltaTime;
		//move rigidbody to new position
		RB.MovePosition(newPosition);


	}

	// Check to see if player had entered a trigger
	void OnTriggerEnter2D (Collider2D collider)
	{
		// Check to see if collision with Health
		if (collider.tag == "Health") 
		{

			Player.Health = Player.Health - (10 * Player.Level);
			Health_Count_Down = 1;
			//Play sound for health damage
			Sound_Controller.On_Health_Damage ();
			UI_Manager.Instance.UpdateHealth();

		}
		// Check to see if collision with Speed
		if (collider.tag == "Speed") 
		{
			//Check to see player speed is not a maximum for Level
			if (Player.Movement_Speed < (15 * Player.Level)) 
			{
				Player.Movement_Speed = Player.Movement_Speed + (5 * Player.Level);
				//Play speed up sound
				Sound_Controller.On_Speed_Up ();
				UI_Manager.Instance.UpdateSpeed();
				Debug.Log( "Speed Tag Tester");
			}
		}
		// Check to see if collision with Freeze
		if (collider.tag == "Freeze") 
		{
			Player.Movement_Speed = 0;
			//Play Freeze sound effect
			Sound_Controller.On_Freeze ();
			Debug.Log ( " Its freezing in here");
			
		}
		// Check to see if collision with Level_Up
		if (collider.tag == "Level_Up")
		{
			// Level up the Player
			Player.Level = Player.Level + 1;
			Player.Level_Up = true;
		}
	}

	// Check to see if Player is still colliding with box collider
	void OnTriggerStay2D (Collider2D collider)
	{
		// Check to see if collision with Health
		if (collider.tag == "Health")
		{
			//Start subtracting from time
			Health_Count_Down -=Time.deltaTime;
			//check if count down is below zero
			if (Health_Count_Down <=0)
			{
				//Damage players health
				Player.Health = Player.Health - (10 * Player.Level);
				//Play sound for damage health
				Sound_Controller.On_Health_Damage ();
				UI_Manager.Instance.UpdateHealth();
				// Reset Count down timer
				Health_Count_Down = 1;
			}

		}
		// Check to see if collision with Level Complete
		if (collider.tag == "Level_Complete")
		{
			// Load Win Scene
			Application.LoadLevel("You_Won");
		}
	}

	// Count down Timer
	void Count_Down_Timer()
	{
		//Speed booster timer
		Speed_Count_Down -= Time.deltaTime;
		// check if speed count down is below zero
		if ( Speed_Count_Down <= 0)
		{ 
			//Set Player movement speed to original value
			Player.Movement_Speed = 5f;
			UI_Manager.Instance.UpdateSpeed();
			//Reset Count Down Timer
			Speed_Count_Down = 5;
		}

			// Game Timer
			Player.Game_Time -= Time.deltaTime;
			//	Check if Game_Timer is below zero
			if (Player.Game_Time <=0)
		{
			// Load Lost game scene
			Application.LoadLevel("You_Lost");
		}

	}

	//Check the player Health
	void Health_Check()
	{
		// players health zero or under
		if (Player.Health <=0)
		{
			//Load Lost game scene
			Application.LoadLevel("You_Lost");
		}
	}

	// Starts the background music playing
	void Background_Music()
	{
		//check to see if music is already playing
		if(Music_Playing)
		{
			Sound_Controller.On_Background_music ();
			//set music_playing to false to stop track starting again
			Music_Playing = false;
		}
	}
}