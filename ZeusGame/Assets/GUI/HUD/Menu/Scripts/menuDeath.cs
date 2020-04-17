//Randall Howatt
//CSci 448
//Editted by Jordan Hoffman to allow controller to be used on menu
using UnityEngine;
using System.Collections;

public class menuDeath : MonoBehaviour {
	
	private bool isDead=false;

	private Texture blackScreen;
	private Texture MenuSelector;
	private int numSelect;
	private int numSelectMax;
	private float waitTime;
	private float waitPeriod;

    private HealthManager playerHealth;

	public enum Page {
		None, Main
	}
	
	private Page currentPage=Page.None;
	
	void Start () {
		numSelect = 1;
		numSelectMax = 3;
		waitTime = 0.0f;
		waitPeriod = 0.25f;
		blackScreen = Resources.Load ("BlackScreen") as Texture;
		MenuSelector = Resources.Load ("xboxControllerButtonA") as Texture;
        playerHealth = GameObject.Find("HUD").transform.Find("Health").gameObject.GetComponent<HealthManager>();
        //HealthManager test = GameObject.Find("HUD").transform.Find("Health").gameObject.GetComponent<HealthManager>();
        //if (test == null)
        //{
        //    print("huhhhhhhhhhhhhhhhh");
        //}
        //print
	}

	void Update(){

		if (currentPage == Page.Main) {
			//print(numSelect + "\n");
			if (Input.GetJoystickNames ().Length == 0) {
				
			} else {
				//if number of remaining lives is greater than 0
				//display all of the death menu options
				if (!playerHealth.isOutOfLives()) {
					if (Input.GetButtonDown ("Jump") && numSelect == 1) {
						EndDeath ();
					}
					if (Input.GetButtonDown ("Jump") && numSelect == 2) {
						Application.LoadLevel ("MainMenu");
					}
					if (Input.GetButtonDown ("Jump") && numSelect == 3) {
						Application.Quit ();
					}
				}else{
				//if number of remaining lives equals 0, only display options
				//to return to main menu or exit game
					numSelectMax = 2;
					if (Input.GetButtonDown ("Jump") && numSelect == 1) {
						Application.LoadLevel ("MainMenu");
					}
					if (Input.GetButtonDown ("Jump") && numSelect == 2) {
						Application.Quit ();
					}
				}
			}
		}

		if (currentPage == Page.Main) {
			//print (waitTime);
			if (waitTime > waitPeriod) {
				if (Input.GetAxis ("MenuNavigation") > 0) {
					if (numSelect < numSelectMax) {
						numSelect += 1;
					}
					waitTime = 0.0f;
				} else if (Input.GetAxis ("MenuNavigation") < 0) {
					if (numSelect > 1) {
						numSelect -= 1;
					}
					waitTime = 0.0f;
				}
			} else {
				if (waitTime < 1.0f) {
					waitTime += UnityEngine.Time.unscaledDeltaTime;
				}
			}
		}


	}
	
	void LateUpdate () {
		if (isDead) { 
			switch(currentPage) {
				case Page.None:
					StartDeath();
					break;
				default:
					currentPage = Page.Main;
					break;
			}
		}
	}
	
	void OnGUI () {
		if (isDead) {
			switch (currentPage) {
			case Page.Main:
				GUI.color = new Color32(255, 255, 255, 175);
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackScreen, ScaleMode.StretchToFill, true);
				DeathMenu();
				break;
			}
			DrawHeader (new Rect(((Screen.width - 1000) / 2), (Screen.height / 8), 1000, 400));
		}
	}
	
	public void killPlayer() { // call to display Death Menu
		isDead = true;
	}
	
	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect(((Screen.width - width) / 2), ((Screen.height - height) / 2), width, height));
	}
	
	private void DeathMenu() {
		BeginPage(200,200);
		GUI.skin.label.fontSize = 32;
		GUI.color = Color.white;
		string trysRemaining = playerHealth.getLifeCount().ToString();
		string restartText;
		if (!trysRemaining.Equals ("1")) {
			restartText = ("Restart " + trysRemaining + " lives remaining");
		}
		else {
			restartText = ("Restart " + trysRemaining + " life remaining");
		}
		if (!trysRemaining.Equals ("0")) { // only display if current lives are greater than zero
			if (GUILayout.Button (restartText)) {
				EndDeath ();
			}
		}
		if (GUILayout.Button ("Exit to Main Menu")) {
			Application.LoadLevel ("MainMenu");
		}
		if (GUILayout.Button ("Exit to Desktop")) {
			Application.Quit ();
		}

		if (Input.GetJoystickNames ().Length != 0) {
			switch (numSelect) {
			case 1:
				GUI.Label (new Rect (170, 0, 20, 20), MenuSelector);
				break;
			case 2:
				GUI.Label (new Rect (170, 25, 20, 20), MenuSelector);
				break;
			case 3:
				GUI.Label (new Rect (170, 50, 20, 20), MenuSelector);
				break;
			}
		}
		GUILayout.EndArea();

	}

	private void DrawHeader(Rect position) {
		string text = "You Are Dead";
		GUI.skin.label.fontSize = 64;
		GUIStyle centeredText = new GUIStyle ("label");
		centeredText.alignment = TextAnchor.UpperCenter;
		GUI.color = Color.black;
		position.x--;
		GUI.Label(position, text, centeredText);
		position.x += 2;
		GUI.Label(position, text, centeredText);
		position.x--;
		position.y--;
		GUI.Label(position, text, centeredText);
		position.y += 2;
		GUI.Label(position, text, centeredText);
		GUI.color = Color.white;
		position.y--;
		GUI.Label(position, text, centeredText); // regular text
	}
	
	void StartDeath() {
		isDead = true;
        DeathManagerTimeTrial.dead = true;
		AudioListener.pause = true;
		playerHealth.decrementLifeCount();
		GetComponent<menuPause> ().PauseGame (false);
        GetComponent<menuPause>().enabled = false;
		currentPage = Page.Main;
	}
	
	void EndDeath() {
		FindObjectOfType<Manager>().Reset();
		FindObjectOfType<LevelManager>().Reset ();
		isDead = false;
        DeathManagerTimeTrial.dead = false;
		AudioListener.pause = false;
		GetComponent<menuPause> ().enabled = true;
		GetComponent<menuPause> ().UnPauseGame (false);
		currentPage = Page.None;
		numSelect = 1;
	}
}