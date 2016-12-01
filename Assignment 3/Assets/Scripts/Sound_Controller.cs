using UnityEngine;
using System.Collections;

public class Sound_Controller : MonoBehaviour {

	// Create a singleton of the
	public static Sound_Controller Instance  { get; private set; }

	//Create Channels for sound effects
	// Sound fx channel
	public AudioSource SFX;
	// Background Music Channel
	public AudioSource Background_Music;

	//Create array for each sound
	// Health Damage
	public AudioClip[] Health_Damge;
	// Freeze
	public AudioClip[] Freeze;
	//Speed Up
	public AudioClip[] Speed_Up;
	// Background Music
	public AudioClip[] Background_music;

	// Use this for initialization
	void Start () {
		//Gives the attribues to the singleton
		Instance = this;
	}

	private void PlaySound (AudioSource destinationSource, AudioClip clip)
	{
		destinationSource.PlayOneShot (clip); 
	}

	public static void On_Health_Damage ()
	{
		AudioClip clip = Instance.Health_Damge [0];
		Instance.PlaySound (Instance.SFX, clip);
	}

	public static void On_Freeze ()
	{
		AudioClip clip = Instance.Freeze [0];
		Instance.PlaySound (Instance.SFX, clip);
	}

	public static void On_Speed_Up ()
	{
		AudioClip clip = Instance.Speed_Up [0];
		Instance.PlaySound (Instance.SFX, clip);
	}

	public static void On_Background_music ()
	{
		AudioClip clip = Instance.Background_music [0];
		Instance.PlaySound (Instance.Background_Music, clip);
	}
}