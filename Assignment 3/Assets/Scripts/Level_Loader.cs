using UnityEngine;
using System.Collections;

public class Level_Loader : MonoBehaviour {

	//Used to load levels
	// takes in the name of the level
	public void Load_Level (string Scene_Name)
	{
		if (Scene_Name == "Quit")
		{
			Application.Quit();
		}
		else
		//loads the level
		Application.LoadLevel (Scene_Name);
	}
}
