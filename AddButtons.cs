using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour {

	[SerializeField]
	private Transform puzzleField;
	[SerializeField]
	private GameObject btn;
	public static int Level_count ;
	void Awake ()
	{
		for (int i = 0; i <Level_count; i++) {
			GameObject button = Instantiate (btn);
			button.name = "" + i;
			button.transform.SetParent (puzzleField,false);
		}
	}


}