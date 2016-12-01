using UnityEngine;
using System.Collections;

public class Level_Loader : MonoBehaviour {


	public void Load_Level (string Scene_Name)
	{
		Application.LoadLevel (Scene_Name);
	}
}
