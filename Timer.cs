using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer: MonoBehaviour  {
	public static float Time_remaning;//sostoyanie vremeni ot rezima
	private float active_Time_remaning;
	public static float statistic_time;
	public static float plus_time=0;
	public static bool Ui_Timer;
	public static bool timer_endgame;
	public static bool color_timer=false;
	public Text  text_tim;
	public float set1 = 0;

	void Start () {
		timer_endgame = false;
		text_tim = gameObject.GetComponent <Text> ();
		active_Time_remaning = Time_remaning;
			}
		
	public void Text_timer()
	{

		if (Ui_Timer == false)
			text_tim.text  = "-- --";

		else {

			if (TochController.time_reset == true) {

				TochController.time_reset = false;
			}

			if (color_timer==true) {//esli svpadenie to +3 sec, color=red -  poka zaderjka
				active_Time_remaning += plus_time;

				text_tim.color = Color.red;
				text_tim.text = "Time: " + (int)active_Time_remaning;

				plus_time = 0;
			} else {
				text_tim.color = Color.black;
				text_tim.text = "Time: " + (int)active_Time_remaning;
				active_Time_remaning -=Time.deltaTime;
			}


			if (active_Time_remaning <= set1) {
				statistic_time = active_Time_remaning;
				timer_endgame = true;
				Debug.Log ("End GAME");
			}


		}

	}
	void Update ()
	{Text_timer ();}

}
