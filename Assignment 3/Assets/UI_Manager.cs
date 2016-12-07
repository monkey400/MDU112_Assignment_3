using UnityEngine;
using System.Collections;

public class UI_Manager : MonoBehaviour {
	public static UI_Manager Instance;
		
	void Awake()
	{
		Instance = this;
	}
	
	public GUIText Health;
	public void UpdateHealth(int hitCount)
	{
		Health.text = "Health: ";
		//hitCountDisplay.text = "Hit Count: " + hitCount;
	}
}
