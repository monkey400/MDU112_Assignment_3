using UnityEngine;
using System.Collections;

public class UI_Manager : MonoBehaviour {
	public static UI_Manager Instance;

		
	void Awake()
	{
		Instance = this;
	}
	
	public UnityEngine.UI.Text Health;
	public UnityEngine.UI.Text Speed;
	public UnityEngine.UI.Text Time;

	public void UpdateHealth()
	{
		Health.text = "Health: " + Character_Attributes.Instance.Health;

	}

	public void UpdateSpeed()
	{
		Speed.text = "Speed: " + Character_Attributes.Instance.Movement_Speed;

	}

	public void UpdateTime()
	{
		Time.text = "Time: " + Character_Attributes.Instance.Game_Time;
	}

}
