using UnityEngine;
using System.Collections;

public class Character_Attributes : MonoBehaviour {

	//Creates the character attributes and settings the intial values

	//Create Character level
	public int Level = 1;

	//Create Character Attriubutes Base
	public int Agility = 1;
	public int Acuity = 1;
	public int Health = 100;
	public int Stamina = 20;
	public bool Level_Up = false;

	//Create Character Movement Speed Base
	public float Movement_Speed = 5f;

	// Use this for initialization
	void Start () {

		//Set Characters Attributes
		Agility = Agility * Level;
		Acuity = Acuity * Level;
		Health = Health * Level;
		Stamina = Stamina * Level;
			
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Level_Up)
		{
			Agility = Agility * Level;
			Acuity = Acuity * Level;
			Health = Health * Level;
			Stamina = Stamina * Level;
			Level_Up = false;
			Debug.Log ( "Its level up time");

			Movement_Speed = Stamina/Agility + Acuity;
		}

	}
}
