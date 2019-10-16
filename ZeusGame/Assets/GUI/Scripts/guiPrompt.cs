//Randall Howatt
//CSci 448

//Edited by Jordan Hoffman. Added the hidePrompt method(used by MenuPause.cs) to hide
//the prompt when pausing the game
using UnityEngine;
using System.Collections;

public class guiPrompt : MonoBehaviour {

	private int promptSecond;
	private int numberOfKeys = 0;
	private float lastUpdate;

    private Texture bButtonImage;
    private Texture aButtonImage;
    private Texture xButtonImage;
    private Texture yButtonImage;
    private Texture lbButtonImage;
	private Texture eImage;
    private Texture cImage;
	private Texture spaceImage;
	private Texture shiftImage;

	public enum Page {
		None, Crouch, Interact, Jump, Sprint, Key, Trap, Sensitivity, Pillars, ObjandSwitches, ResetRocks, MoreKeys
	}
	
	private Page currentPage;

	void Start () {
		promptSecond = 0;
		lastUpdate = Time.time;
        bButtonImage = Resources.Load("xboxControllerButtonB") as Texture;
        aButtonImage = Resources.Load("xboxControllerButtonA") as Texture;
        xButtonImage = Resources.Load("xboxControllerButtonX") as Texture;
        yButtonImage = Resources.Load("xboxControllerButtonY") as Texture;
        lbButtonImage = Resources.Load("xboxControllerLeftShoulder") as Texture;
		eImage = Resources.Load ("EKey") as Texture;
        cImage = Resources.Load ("Ckey") as Texture;
		spaceImage = Resources.Load ("SpaceKey") as Texture;
		shiftImage = Resources.Load ("ShiftKey") as Texture;
		currentPage = Page.None;
	}

	void LateUpdate() {
		if (currentPage != Page.None) {
			if ((Time.time - lastUpdate) > 1.0f) { // update every second
				promptSecond++;
				lastUpdate = Time.time;
			}
			if (promptSecond >= 5) {
				promptSecond = 0;
				currentPage = Page.None;
			}
		}
	}

	void OnGUI() {
		switch (currentPage) {
            case Page.Crouch:
                ShowCrouch();
                break;
			case Page.Interact:
				ShowInteract();
				break;
			case Page.Jump:
				ShowJump();
				break;
			case Page.Sprint:
				ShowSprint();
				break;
			case Page.Key:
				ShowKey();
				break;
			case Page.Trap:
				ShowTrap ();
				break;
			case Page.Sensitivity:
				ShowSensitivity();
				break;
			case Page.Pillars:
				ShowPillars();
				break;
			case Page.ObjandSwitches:
				ShowObjandSwitches();
				break;
			case Page.ResetRocks:
				ShowResetRocks();
				break;
			case Page.MoreKeys:
			ShowMoreKeys (numberOfKeys);
				break;
			default:
				currentPage = Page.None;
				break;
		}
	}

	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect(((Screen.width - width) / 2), (3 * ((Screen.height - height) / 4)), width, height));
	}

	public void Reset() {
		currentPage = Page.None;
	}

	public void ActivateInteractPrompt() { // call to display Interact prompt
		promptSecond = 0;					//Switching between two prompts will reset the timer
		currentPage = Page.Interact;
	}

    public void ActivateCrouchPrompt() // call to display Crouch prompt
    { 
		promptSecond = 0;
        currentPage = Page.Crouch;
    }

	public void ActivateJumpPrompt() { // call to display Jump prompt
		promptSecond = 0;
		currentPage = Page.Jump;
	}

	public void ActivateSprintPrompt() { // call to display Sprint prompt
		promptSecond = 0;
		currentPage = Page.Sprint;
	}

	public void ActivateKeyPrompt() { // call to display Key prompt
		promptSecond = 0;
		currentPage = Page.Key;
	}

	public void ActivateTrapPrompt() { // call to display Trap prompt
		promptSecond = 0;
		currentPage = Page.Trap;
	}

	public void ActivateSensitivityPrompt(){ // call to display sensitivity prompt
		promptSecond = 0;
		currentPage = Page.Sensitivity;
	}

	public void ActivatePillarsPrompt(){ //call to display falling pillar prompt
		promptSecond = 0;
		currentPage = Page.Pillars;
	}

	public void ActivateObjandSwitchesPrompt(){ //call to display weighing down switches with objects prompt
		promptSecond = 0;
		currentPage = Page.ObjandSwitches;
	}

	public void ActivateResetRocksPrompt(){ //call to display reseting puzzle rocks prompt
		promptSecond = 0;
		currentPage = Page.ResetRocks;
	}
	
	public void ActivateMoreKeysPrompt(int value) { // call to display More Keys prompt
		promptSecond = 0;
		numberOfKeys = value;
		currentPage = Page.MoreKeys;
	}

	void ShowInteract() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Press", GUILayout.Width (100), GUILayout.Height (75));
        if (Input.GetJoystickNames().Length == 0)
        {
            GUILayout.Label(eImage, GUILayout.Width(100));
        }
        else
        {
            GUILayout.Label(xButtonImage, GUILayout.Width(100), GUILayout.Height(75));
        }
		GUILayout.Label ("to Interact with Objects", GUILayout.Width (350), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

    void ShowCrouch()
    {
        GUI.color = Color.white;
        GUI.skin.label.fontSize = 32;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        BeginPage(1000, 100);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Press", GUILayout.Width(100), GUILayout.Height(75));
        if (Input.GetJoystickNames().Length == 0)
        {
            GUILayout.Label(cImage, GUILayout.Width(100), GUILayout.Height(75));
        }
        else {
            GUILayout.Label(bButtonImage, GUILayout.Width(100), GUILayout.Height(75));
        }

        GUILayout.Label("to Crouch", GUILayout.Width(200), GUILayout.Height(75));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUI.skin.label.alignment = TextAnchor.UpperLeft;
        GUILayout.EndArea();
    }

	void ShowJump() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Press", GUILayout.Width (100), GUILayout.Height (75));
        if (Input.GetJoystickNames().Length == 0)
        {
            GUILayout.Label(spaceImage);
        }
        else
        {
            GUILayout.Label(aButtonImage, GUILayout.Width(100), GUILayout.Height(75));
        }
		GUILayout.Label ("to Jump", GUILayout.Width (125), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

	void ShowSprint() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Hold", GUILayout.Width (75), GUILayout.Height (75));
        if (Input.GetJoystickNames().Length == 0)
        {
            GUILayout.Label(shiftImage);
        }
        else
        {
            GUILayout.Label(lbButtonImage, GUILayout.Width(100), GUILayout.Height(75));
        }
        GUILayout.Label ("to Sprint", GUILayout.Width (130), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

	void ShowKey() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Find Keys, Switches, and Levers to open Locked Doors", GUILayout.Width (550), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

	void ShowTrap() {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Watch Out for Traps and Other Obstacles", GUILayout.Width (550), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

	void ShowSensitivity(){
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Look Sensitivity can be changed in the Pause Menu", GUILayout.Width (550), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

	void ShowPillars(){
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Watch out for falling platforms", GUILayout.Width (550), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

	void ShowObjandSwitches(){
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Switches can be held down with objects", GUILayout.Width (550), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

	void ShowResetRocks(){
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Press", GUILayout.Width (100), GUILayout.Height (75));
		if (Input.GetJoystickNames().Length == 0)
		{
			GUILayout.Label ("R to reset the rocks while in this room", GUILayout.Width (550), GUILayout.Height (75));
		}
		else
		{
			GUILayout.Label(yButtonImage, GUILayout.Width(75), GUILayout.Height(75));
			GUILayout.Label ("to reset the rocks while in this room", GUILayout.Width (550), GUILayout.Height(75));
		}
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}
	
	void ShowMoreKeys(int value) {
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		string text = "";
		if (value == 1) {
			text = ("You Need " + value + " More Key to Unlock This Door");
		}
		else {
			text = ("You Need " + value + " More Keys to Unlock This Door");
		}
		BeginPage (1000, 100);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		GUILayout.Label (text, GUILayout.Width (800), GUILayout.Height (75));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal ();
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.EndArea();
	}

	//Used if the game is paused while a prompt is up
	public void hidePrompt(){
		currentPage = Page.None;
	}
}