using UnityEngine;
using System.Collections;

public class Character_Attributes : MonoBehaviour {

	public int Level = 1;
	public int Agility = 1;
	public int Acuity = 1;
	public int Health = 100;
	public int stamina = 10;
	
	public float movement_speed = 5f;

	// Use this for initialization
	void Start () {

		Agility = Agility * Level;
		Acuity = Acuity * Level;
		Health = Health * Level;
		stamina = stamina * Level;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
