//Randall Howatt
//CSci 448

//Editted by Jordan Hoffman to remove headbob, add xbox buttons to menu, add crouch to menu
//removed the GUIprompt when paused, enable user to pause with controller, added the ability
//for the player to change their look sensitivity, made it so controller and keyboard can
//navigate menu without mouse
using UnityEngine;
using System.Collections;

public class menuPause : MonoBehaviour
{
	private float savedTimeScale;

	private MouseLook playerCamera;
	private	MouseLook mainCamera;
	private float sense;
	//The following bool values are used to determine if 
	//a button was pressed
	private bool minus;
	private bool plus;
	private int numSelect;
	private float waitTime;
	private float waitPeriod;
	
	private Texture mouseImage;
	private Texture wasdImage;
	private Texture eImage;
	private Texture cImage;
	private Texture spaceImage;
	private Texture shiftImage;
	private Texture blackScreen;
	private Texture bButtonImage;
	private Texture aButtonImage;
	private Texture xButtonImage;
	private Texture yButtonImage;
	private Texture lbButtonImage;
	private Texture lStickButtonImage;
	private Texture rStickButtonImage;
	private Texture MenuSelector;

	
	public enum Page {
		None, Main, Controls
	}
	
	private Page currentPage;
	
	void Start() {
		numSelect = 1;
		waitTime = 0.0f;
		waitPeriod = 0.25f;
		sense = 10.0f;
		minus = false;
		plus = false;
		Time.timeScale = 1;
		playerCamera = GameObject.Find ("Player").GetComponent<MouseLook>();
		mainCamera = Camera.main.GetComponent<MouseLook>();
		//GetComponent<HeadBob> ().enabled = true; Edited out since component not used
		AudioListener.pause = false;
		mouseImage = Resources.Load ("MouseKey") as Texture;
		wasdImage = Resources.Load ("WASDKey") as Texture;
		eImage = Resources.Load ("EKey") as Texture;
		cImage = Resources.Load ("CKey") as Texture;
		spaceImage = Resources.Load ("SpaceKey") as Texture;
		shiftImage = Resources.Load ("ShiftKey") as Texture;
		blackScreen = Resources.Load ("BlackScreen") as Texture;
		bButtonImage = Resources.Load("xboxControllerButtonB") as Texture;
		aButtonImage = Resources.Load("xboxControllerButtonA") as Texture;
		xButtonImage = Resources.Load("xboxControllerButtonX") as Texture;
		yButtonImage = Resources.Load("xboxControllerButtonY") as Texture;
		lbButtonImage = Resources.Load("xboxControllerLeftShoulder") as Texture;
		lStickButtonImage = Resources.Load ("xboxControllerLeftThumbstick") as Texture;
		rStickButtonImage = Resources.Load ("xboxControllerRightThumbstick") as Texture;
		MenuSelector = Resources.Load ("xboxControllerButtonA") as Texture;
	}

	void Update (){
		if (currentPage == Page.Main) {
			//print(numSelect + "\n");
			if (Input.GetJoystickNames ().Length == 0) {

			} else {
				if (Input.GetKeyDown ("joystick button 4") && IsGamePaused ()) {
					minus = true;
				}
			
				if (Input.GetKeyDown ("joystick button 5") && IsGamePaused ()) {
					plus = true;
				}

				if (Input.GetButtonDown ("Jump") && numSelect == 1) {
					UnPauseGame (true);
				}
				if (Input.GetButtonDown ("Jump") && numSelect == 2) {
					currentPage = Page.Controls;
				}
				if (Input.GetButtonDown ("Jump") && numSelect == 3) {
					Application.LoadLevel ("MainMenu");
				}
				if (Input.GetButtonDown ("Jump") && numSelect == 4) {
					Application.Quit ();
				}
			}
		} else if (currentPage == Page.Controls) {
			if (Input.GetJoystickNames ().Length != 0 && (Input.GetButtonDown("Jump") || Input.GetButtonDown ("Crouch")) && IsGamePaused ()) {
				currentPage = Page.Main;
			}
		}

        if (GameObject.Find("Player").GetComponent<Manager>().IsInventoryShowing() 
            && (Input.GetKeyDown("escape") || Input.GetKeyDown("return") || Input.GetKeyDown("joystick button 7"))) // Close inventory window if it is up instead of pulling up menu
        {
            GameObject.Find("Player").GetComponent<Manager>().ToggleInventoryWindow(InventoryTabManager.InventoryTab.TOOLS);
        } else if (IsGamePaused () && (Input.GetKeyDown ("escape") || Input.GetKeyDown ("return") || Input.GetKeyDown ("joystick button 7"))) {
			if (currentPage == Page.Controls){
				currentPage = Page.Main;
			}
			UnPauseGame (true);
		}else if (Input.GetKeyDown ("escape") || Input.GetKeyDown ("return") || Input.GetKeyDown ("joystick button 7")){
			switch (currentPage) {
			case Page.None: 
				PauseGame (true); 
				break;
			default: 
				currentPage = Page.Main;
				break;
			}
		}
		if (currentPage == Page.Main) {
			//print (waitTime);
			if (waitTime > waitPeriod) {
				if (Input.GetAxis ("MenuNavigation") > 0) {
					if (numSelect < 4) {
						numSelect += 1;
					}
					waitTime = 0.0f;
				} else if (Input.GetAxis ("MenuNavigation") < 0) {
					if (numSelect > 1) {
						numSelect -= 1;
					}
					waitTime = 0.0f;
				}
			}else{
				if (waitTime < 1.0f){
					waitTime += UnityEngine.Time.unscaledDeltaTime;
				}
			}
		}

	}
	
	void OnGUI () {
		if (IsGamePaused ()) {
			GUI.color = new Color32 (255, 255, 255, 175);
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), blackScreen);

			switch (currentPage) {
				case Page.Main:
					MainPauseMenu ();
					break;
				case Page.Controls:
					ShowControls ();
					break;
				}  
	
		}
	}

	
	void ShowBackButton() {
		if (Input.GetJoystickNames ().Length == 0) {
			if (GUI.Button (new Rect (((Screen.width / 2) - 30), ((Screen.height / 2) + (Screen.height / 3)), 75, 20), "Back")) {
				currentPage = Page.Main;
			}
		} else {
			if ((GUI.Button (new Rect (((Screen.width / 2) - 30), ((Screen.height / 2) + (Screen.height / 3)), 75, 20), "Back"))) {
				currentPage = Page.Main;
			}
			GUI.Label(new Rect((Screen.width/2) + 22, (Screen.height/2) + (Screen.height /3), 20, 20), MenuSelector);
		}
	}
	
	void ShowControls() {
		//This route creates the GUI for the game controls
			if (Input.GetJoystickNames ().Length == 0) { //If controller is not connected print out keyboard keys
				GUI.color = Color.white;
				GUI.skin.label.fontSize = 30;
				GUI.skin.label.alignment = TextAnchor.MiddleCenter;
				BeginPage (300, 500);
				GUILayout.BeginHorizontal ();
				GUILayout.BeginVertical ();
				GUILayout.Label (mouseImage, GUILayout.Height (64), GUILayout.Width (64));
				GUILayout.Label (wasdImage, GUILayout.Height (90), GUILayout.Width (90));
				GUILayout.Label (eImage, GUILayout.Height (55), GUILayout.Width (55));
				GUILayout.Label (spaceImage, GUILayout.Height (75), GUILayout.Width (75));
				GUILayout.Label (cImage, GUILayout.Height (55), GUILayout.Width (55));
				GUILayout.Label (shiftImage, GUILayout.Height (64), GUILayout.Width (70));
				GUILayout.EndVertical ();
				GUILayout.BeginVertical ();
				GUILayout.Label ("Camera", GUILayout.Height (75));
				GUILayout.Label ("Movement", GUILayout.Height (80));
				GUILayout.Label ("Interact", GUILayout.Height (55));
				GUILayout.Label ("Jump", GUILayout.Height (75));
				GUILayout.Label ("Crouch", GUILayout.Height (60));
				GUILayout.Label ("Sprint", GUILayout.Height (75));
				GUILayout.EndVertical ();
				GUILayout.EndHorizontal ();
				EndPage ();
				GUI.skin.label.alignment = TextAnchor.UpperLeft;
			} else {			//If controller is connected print out controller buttons
				GUI.color = Color.white;
				GUI.skin.label.fontSize = 30;
				GUI.skin.label.alignment = TextAnchor.MiddleCenter;
				BeginPage (300, 500);
				GUILayout.BeginHorizontal ();
				GUILayout.BeginVertical ();
				GUILayout.Label (rStickButtonImage, GUILayout.Height (60), GUILayout.Width (60));
				GUILayout.Label (lStickButtonImage, GUILayout.Height (60), GUILayout.Width (60));
				GUILayout.Label (xButtonImage, GUILayout.Height (60), GUILayout.Width (60));
				GUILayout.Label (aButtonImage, GUILayout.Height (60), GUILayout.Width (60));
				GUILayout.Label (bButtonImage, GUILayout.Height (60), GUILayout.Width (60));
				GUILayout.Label (lbButtonImage, GUILayout.Height (49), GUILayout.Width (113));
				GUILayout.EndVertical ();
				GUILayout.BeginVertical ();
				GUILayout.Label ("Camera", GUILayout.Height (60));
				GUILayout.Label ("Movement", GUILayout.Height (60));
				GUILayout.Label ("Interact", GUILayout.Height (55));
				GUILayout.Label ("Jump", GUILayout.Height (75));
				GUILayout.Label ("Crouch", GUILayout.Height (60));
				GUILayout.Label ("Sprint", GUILayout.Height (65));
				GUILayout.EndVertical ();
				GUILayout.EndHorizontal ();
				EndPage ();
				GUI.skin.label.alignment = TextAnchor.UpperLeft;
			}
	}
	
	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect(((Screen.width - width) / 2), ((Screen.height - height) / 2), width, height));
	}
	
	void EndPage() {
		GUILayout.EndArea();
		if (currentPage != Page.Main) {
			ShowBackButton();
		}
	}
	
	void MainPauseMenu() {
		GUI.color = Color.white;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		BeginPage(200,200);
		if (Input.GetJoystickNames ().Length == 0) { //If controller is not connected
			if (GUILayout.Button ("Resume")) {
				UnPauseGame (true);
			}
			if (GUILayout.Button ("Controls")) {
				currentPage = Page.Controls;
			}

			if (GUILayout.Button ("Exit to Main Menu")) {
				Application.LoadLevel ("MainMenu");
			}

			GUILayout.Label ("Sensitivity");
			//The following code allows the user to change their sensitivity in the menu
			GUILayout.BeginHorizontal ();

			if (GUILayout.Button ("-", GUILayout.Width (75))) {
				if (sense > 1) {
					sense -= 1;
					playerCamera.sensitivityX -= 1.0f;
					mainCamera.sensitivityY -= 1.0f;
				}
			}

			if (sense == 1) {
				GUILayout.Label ("Min");
			} else if (sense == 20) {
				GUILayout.Label ("Max");
			} else {
				GUILayout.Label ("" + sense);
			}

			if (GUILayout.Button ("+", GUILayout.Width (75))) {
				if (sense < 20) {
					sense += 1;
					playerCamera.sensitivityX += 1.0f;
					mainCamera.sensitivityY += 1.0f;
				}
			}

			GUILayout.EndHorizontal ();
			if (GUILayout.Button ("Exit to Desktop")) {
				Application.Quit ();
			}
		} else { ///////////////////////////////////////////////////////////////
				//If controller is connected
			if (GUILayout.Button ("Resume")) {
				UnPauseGame (true);
			}
			if (GUILayout.Button ("Controls")) {
				currentPage = Page.Controls;
			}
			if (GUILayout.Button ("Exit to Main Menu")) {
				Application.LoadLevel ("MainMenu");
			}
			
			GUILayout.Label ("Sensitivity");
			//The following code allows the user to change their sensitivity in the menu
			GUILayout.BeginHorizontal ();
			
			if (GUILayout.Button ("LB", GUILayout.Width (75)) || minus == true) {
				minus = false;
				if (sense > 1) {
					sense -= 1;
					playerCamera.sensitivityX -= 1.0f;
					mainCamera.sensitivityY -= 1.0f;
				}
			}
			
			if (sense == 1) {
				GUILayout.Label ("Min");
			} else if (sense == 20) {
				GUILayout.Label ("Max");
			} else {
				GUILayout.Label ("" + sense);
			}
			
			if (GUILayout.Button ("RB", GUILayout.Width (75)) || plus == true) {
				plus = false;
				if (sense < 20) {
					sense += 1;
					playerCamera.sensitivityX += 1.0f;
					mainCamera.sensitivityY += 1.0f;
				}
			}
			GUILayout.EndHorizontal ();
			if (GUILayout.Button ("Exit to Desktop")) {
				Application.Quit ();
			}
		}

		if (Input.GetJoystickNames ().Length != 0){
			switch (numSelect) {
				case 1:
					GUI.Label(new Rect(170, 0 , 20, 20), MenuSelector);
				break;
				case 2:
					GUI.Label(new Rect(170, 25 , 20, 20), MenuSelector);
				break;
				case 3:
					GUI.Label(new Rect(170, 50 , 20, 20), MenuSelector);
				break;
				case 4:
					GUI.Label(new Rect(170, 142 , 20, 20), MenuSelector);
				break;
			} 
		}
		EndPage();
	}
	
	public void PauseGame(bool check) {
		if(Input.GetJoystickNames ().Length == 0){
			Cursor.visible = true;
		}
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
		AudioListener.pause = true;
		playerCamera.enabled = false;
		mainCamera.enabled = false;
		if (check) { // Death flag check. If false it does not display the Pause Menu and only pauses the game.
			currentPage = Page.Main;
		}
	}
	
	public void UnPauseGame(bool check) {
		Time.timeScale = savedTimeScale;
		GetComponent<MouseLook>().enabled = true;
		AudioListener.pause = false;
		playerCamera.enabled = true;
		mainCamera.enabled = true;
		if (check) {
			currentPage = Page.None;
		}
		Cursor.visible = false;
		numSelect = 1;
	}
	
	public bool IsGamePaused() {
		return (currentPage != Page.None);
	}
}