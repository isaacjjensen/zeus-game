//Michael Schilling
//CSci 448
//Editted by Jordan Hoffman to give a hint about puzzle
using UnityEngine;
using System.Collections;

public class LeverPuzzle : MonoBehaviour {

	public puzzleLever[] leversInPuzzle; // this is important for order
	private int currentLeverIndex = 0;
	public Activatable ItemToActivate;
	bool showMessage;	//bool value for displaying message

	// Use this for initialization
	void Start () {
		showMessage = false;
		for (int i = 0; i < leversInPuzzle.Length; i++)
		{
			leversInPuzzle[i].master = this;
			leversInPuzzle[i].INDEX = i;
		}
	}

	public void LeverActivated(int leverCount)
	{
		if (leverCount == currentLeverIndex)
		{
			currentLeverIndex++;
			if (currentLeverIndex == leversInPuzzle.Length)
			{
				ItemToActivate.Activate ();
				print ("puzzle complete!");
			}
		}
		else
		{
			currentLeverIndex = 0;
			for (int i = 0; i < leversInPuzzle.Length; i++)
			{
				leversInPuzzle[i].Deactivate();
			}
			showMessage = true; //if player fails to get puzzle display hint
			Invoke("HideMessage", 3.0f);
		}
	}

	void OnGUI()
	{
		if (showMessage) {
			GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Search the maze for a clue");
		}
	}

	void HideMessage()
	{
		showMessage = false;
	}
}
