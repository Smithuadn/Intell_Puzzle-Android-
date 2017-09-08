using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TochController : MonoBehaviour {
	public List<Button> btns = new List <Button> (); 

	public Sprite b1Image,b2Image;
	public int switch_bot;
	public static bool Pause ;

	public static bool time_reset=false;
	void GetButtons()
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("Button Control");
		for (int i = 0; i<objects.Length;i++)
		{

			btns.Add(objects[i].GetComponent<Button>());

		}
	}


	void AddListeners()
	{
		
		foreach (Button btn in btns) {
			
			btn.onClick.AddListener (() => Function ());

			foreach (Button btn_lev in btns) 

				btn.onClick.AddListener (() => Function ());

		}
	}
	public void Function()
	{    
		string switch_bot=UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		switch (switch_bot) {
		case ("Play_Pause"):
			
			if (!Pause) { 
				btns [0].image.sprite = b1Image;
				Time.timeScale = 0; 
				Pause = true;

			} else {
				btns [0].image.sprite = b2Image;
				Time.timeScale = 1; 
				Pause = false;

			}
			break;
		case ("Replay"):
			time_reset = true;
			SceneManager.LoadScene ("Game Scene");
			//goto case ("Button_Normal");
			break;

		case ("Game_Menu"):
			SceneManager.LoadScene ("MainMenu");
			Debug.Log ("case 3");
			break;

		case ("Button_Play"):
			SceneManager.LoadScene ("Load Mode Level");

			break;
		
		case ("Button_HighScore"):
			SceneManager.LoadScene ("Finish Game");

			break;
		case ("Button_Quit"):
			Application.Quit();

			break;
		case ("Button_How to"):
			SceneManager.LoadScene ("How to");

			break;

		case ("Button_Settings"):
			SceneManager.LoadScene ("Settings");

			break;

		case ("Button_Easy"):
			AddButtons.Level_count = 12;
			Timer.Ui_Timer = false;
			CalculateStatistic.Level_mode = 1;
			SceneManager.LoadScene ("Game Scene");
			break;
		case ("Button_Normal"):
			AddButtons.Level_count = 16;
			Timer.Time_remaning = 26;
			Timer.Ui_Timer = true;
			CalculateStatistic.Level_mode = 2;
			SceneManager.LoadScene ("Game Scene");

			break;
		case ("Button_Hard"):
			AddButtons.Level_count = 20;
			Timer.Time_remaning = 16;
			Timer.Ui_Timer = true;
			CalculateStatistic.Level_mode = 3;
			SceneManager.LoadScene ("Game Scene");

			break;
		}
		


	}

	void Start()
	{
		
		GetButtons ();

		Pause = false;
	}


	void Update () {
		
	}
}
