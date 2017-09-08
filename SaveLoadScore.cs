using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class SaveLoadScore : MonoBehaviour {
	public static float HighScore;
	public string filename;
	public Text hscore_text;
	void Start () {
		if (filename=="") filename="Data/Save/HighScore.txt";
		Load ();
		hscore_text = gameObject.GetComponent<Text>();

		}

	void Load ()
	{
		StreamReader streamread = new StreamReader("Data/Save/HighScore.txt");
		if (streamread != null) {
			while (!streamread.EndOfStream)
				HighScore = System.Convert.ToSingle (streamread.ReadLine ());
			Debug.Log ("load:" + HighScore);
		}

	}
	void Save()
	{
		
			StreamWriter sv = new StreamWriter ("Data/Save/HighScore.txt");

		string name = string.Format ("{0}", CalculateStatistic.Statistic);
			sv.WriteLine (name);
			Debug.Log ("Save!!!");
			sv.Close ();


	}


	void Update () {
		if (hscore_text!=null)
			hscore_text.text = "Your High Score:" + (int)HighScore;
		if (CalculateStatistic.Statistic > HighScore)
			Save ();
	}
}
