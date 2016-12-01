using UnityEngine;
using System.Collections;

public class Play_Music : MonoBehaviour {

	// Used for controlling music
	private bool music_playing = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Calls the music to be played
		Background_Music ();
	}

	//Plays Music
	void Background_Music()
	{
		// checkt to see if music is playing
		if(music_playing)
		{
			// Plays music
			Sound_Controller.On_Background_music ();
			// Stops music from playing
			music_playing = false;
		}
	}
}
