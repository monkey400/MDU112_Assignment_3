using UnityEngine;
using System.Collections;

public class Sound_Controller : MonoBehaviour {

	public static Sound_Controller Instance  { get; private set; }

	public AudioSource SFX;
	public AudioSource Background_Music;

	public AudioClip[] Health_Damge;
	public AudioClip[] Freeze;
	public AudioClip[] Speed_Up;
	public AudioClip[] Background_music;

	// Use this for initialization
	void Start () {
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