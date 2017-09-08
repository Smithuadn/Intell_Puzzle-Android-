using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
	
	[SerializeField]
	public Sprite bgImage;

	public Sprite[] puzzles;
	public List<Sprite> gamePuzzles = new List <Sprite> ();

	public List<Button> btns = new List <Button> (); 
	private bool firstCheck, secondCheck;
	private int countCheck;
	public static int countCorrectCheck;
	private int gameCheck;
	private int firstCheckIndex, secondCheckIndex;
	private string firstCheckPuzzle, secondCheckPuzzle;

	void Awake ()
	{
		puzzles = Resources.LoadAll<Sprite> ("Sprites/puzzle");
	}

	void Start () {
		GetButtons ();
		AddListeners ();
		AddGamePuzzles ();
		ShuffleList (gamePuzzles);

		gameCheck = gamePuzzles.Count / 2;


	}
	void Update ()
	{
		if (Timer.timer_endgame == true) {
			SceneManager.LoadScene("Finish Game");
		}
	}
	void GetButtons()
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("Puzzle Button");
		for (int i = 0; i<objects.Length;i++)
		{
			
			btns.Add(objects[i].GetComponent<Button>());
			btns [i].image.sprite = bgImage;
		}
	}

	void AddGamePuzzles()
	{
		int looper = btns.Count;
		int index = 0;
		for (int i = 0; i < looper; i++) 
		{
			if (index == looper / 2) {
				index = 0;
			}
			gamePuzzles.Add (puzzles [index]);

			index++;
		}

	}


	void AddListeners()
	{
		
			foreach (Button btn in btns) {
				btn.onClick.AddListener (() => PickAPuzzle ());
			}

	}

	public void PickAPuzzle()
	{
		if (TochController.Pause == false) {
			if (!firstCheck) {
				firstCheck = true;
				firstCheckIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
				firstCheckPuzzle = gamePuzzles [firstCheckIndex].name;

				btns [firstCheckIndex].image.sprite = gamePuzzles [firstCheckIndex];
			} else if (!secondCheck) {
				secondCheck = true;
				secondCheckIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
				secondCheckPuzzle = gamePuzzles [secondCheckIndex].name;
				btns [secondCheckIndex].image.sprite = gamePuzzles [secondCheckIndex];
				countCheck++;
				StartCoroutine (checkifThepuzzleMatch ());
			
			}
		}
	}
	IEnumerator checkifThepuzzleMatch()
	{
		yield return new WaitForSeconds (.1f);
		if (firstCheckPuzzle == secondCheckPuzzle && firstCheckIndex != secondCheckIndex) {
			Timer.plus_time =2;

			Timer.color_timer = true;
			yield return new WaitForSeconds (.1f);
			Timer.color_timer = false;
			btns [firstCheckIndex].interactable = true;
			btns [secondCheckIndex].interactable = true;

			btns [firstCheckIndex].image.color = new Color (0, 0, 0, 0);
			btns [secondCheckIndex].image.color = new Color (0, 0, 0, 0);



			CheckIfTheGameisFinished ();
		} else {
		yield return new WaitForSeconds (.1f);
		btns [firstCheckIndex].image.sprite = bgImage;
		btns [secondCheckIndex].image.sprite = bgImage;

		}

		yield return new WaitForSeconds (.1f);
		firstCheck = secondCheck = false;
	}

	void CheckIfTheGameisFinished ()
	{
		countCorrectCheck++;
		if (countCorrectCheck == gameCheck)
		{
			SceneManager.LoadScene("Finish Game");
		}
	}
	void ShuffleList (List<Sprite> list)
	{
		for (int i = 0; i < list.Count; i++) 
		{
			Sprite temp = list [i];
			int randomIndex = Random.Range (i, list.Count);
			list [i] = list [randomIndex];
			list [randomIndex] = temp;
		}
	}

}
