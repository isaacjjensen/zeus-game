//Randall Howatt
//CSci 448

//Editted by Jordan Hoffman to allow for the menu to be navigated with the controller
//Also added the back button to the control page
using UnityEngine;
using System.Collections;

public class menuMain : MonoBehaviour {

	private string[] credits = { // change over time
		"University of North Dakota\n",
		"Instructor:",
		"\tDr. Ron Marsh\n",
		"Course:",
		"\tComputer Science 448\n",
        "\tComputer Science 492\n",
        "\tComputer Science 493\n",
		"A Game Created By:\n",
        "First Team:\n",
		"Ben Carpenter:",
		"\tLevel 2 Design",
		"\tObject Art/Animation",
		"\tMusic\n",
		"Randall Howatt:",
		"\tLevel 1 Design",
		"\tInterface/Menu Design",
		"\tSound Effects\n",
		"Alex Lewis:",
		"\tEnvironment Design",
		"\tObject Art/Animation",
		"\tPuzzle Programming\n",
		"Michael Schilling:",
		"\tCharacter Controls",
		"\tObject Programming",
		"\tPuzzle Programming\n",
        "Second Team:\n",
        "Christian Oliver Sandtveit:",
		"\tTime Trial Level Design and Implementation",
		"\tLevel 3 Hub",
		"\tProgramming",
        "Erik Sommer:",
		"\tIce Cave Level Design and Implementation",
        "\tLevel 3 Hub",
		"\t3D Models and Animations",
        "Darrin Winger:",
		"\tTeleport Level Design and Implementation",
        "\tLevel 3 Hub",
		"\tController Support\n",
		"Third Team:\n",
		"Jordan Hoffman:",
		"\tPlaytester",
		"\tAdditional Controller Support",
		"\tAdditional Objects and Functionality\n",
		"Fourth team:\n",
		"Alexander Nelson:",
		"\tUpdate levels\n",
		"Parker Combs:",
		"\tUpdate levels\n",
		"Isaac Jensen:",
		"\tUpdate levels\n",
		"Dustin Nelson:",
		"\tUpdate levels\n",
		"Nick Twamley:",
		"\tUpdate levels\n",
		"Special Thanks:\n",
		"Kasie Kinzler:",
		"\tArt Stills\n",
		"Rose Diemert:",
		"\tFirst Semester Team Member\n",
		"Mike Redlin:",
		"\tPrimary Narrator\n",
		"Ty Bommersbach:",
		"\tSecondary Narrator\n",
		"Accomodations:",
		"This game uses these art objects from OpenGameArt.org:",
		"\t\"Medieval Trestle Table\" by ulf (http://opengameart.org/users/ulf)",
		"\t\"Sickle\" by johndh (http://opengameart.org/users/johndh)",
		"\t\"Wooden Bridge 3D model\" by WeaponGuy (http://opengameart.org/users/weaponguy)\n",
		"This game uses these music files from Newgrounds.com:",
		"\t\".dystopia.\" by VegetarianMeat (http://vegetarianmeat.newgrounds.com/)",
		"\t\"Lower Dungeon\" by shesmackshard (http://shesmackshard.newgrounds.com/)\n",
		"This game uses these music files from OpenGameArt.org:",
		"\t\"Evil_bgm\" by teckpow (http://opengameart.org/users/teckpow)",
		"\t\"Shades\" by jalastram (http://opengameart.org/users/jalastram)\n",
		"This game uses these sounds from OpenGameArt.org:",
		"\t\"sell_buy_item.wav\" by Ogrebane (http://opengameart.org/users/ogrebane)",
		"\t\"sheep2.flac\" by Lamroot (http://opengameart.org/users/lamoot)",
		"\t\"waterfall1.ogg\" and \"stream1.ogg\" by kurt (http://opengameart.org/users/kurt)\n",
		"This game uses these sounds from freesound.org:",
		"\t\"bats.wav\" by soundbytez (http://www.freesound.org/people/soundbytez/)",
		"\t\"bridge.wav\" edited from Sergenious (http://www.freesound.org/people/Sergenious/)",
		"\t\"concrete blocks moving2.wav\" edited from FreqMan (http://www.freesound.org/people/FreqMan/)",
		"\t\"fire_minidisk (suonho).wav\" by suonho (http://www.freesound.org/people/suonho/)",
		"\t\"Indy Blow Darts Cue 3.wav\" edited from pscsound (http://www.freesound.org/people/pscsound/)",
		"\t\"Iron gate, street.wav\" edited from Trautwein (http://www.freesound.org/people/Trautwein/)",
		"\t\"Keys1.wav\" by EverHeat (http://www.freesound.org/people/EverHeat/)",
		"\t\"Moving a boulder.wav\" edited from BW_Clowes (http://www.freesound.org/people/BW_Clowes/)\n",
        "This game uses these art objects from blendswap.com:",
        "\t\"armor.blend\" by kxlexk (http://www.blendswap.com/blends/view/41883)\n",
        "\t\"alien_skull.blend\" by nbninja8 (http://www.blendswap.com/blends/view/1275)\n",
        "\t\"Alien Queen.blend\" by Rock76222 (http://www.blendswap.com/blends/view/74405)\n",
        "\t\"Spider Queen.blend\" by Calopre (http://www.blendswap.com/blends/view/69937)\n",
        "\t\"Balmora_Crate.blend\" by GyngaNynja (http://www.blendswap.com/blends/view/73027)\n",
		"This game features images rendered on the CrayOwulf Cluster in the Computer Science Department using RayGL (courtesy Kris Zarns) and POVRAY (www.povray.org).\n",
		"This game is distrubted under Creative Commons 0 (https://creativecommons.org/publicdomain/zero/1.0/)"
		} ;

	//These are textures that are used for the menu selector and controls page
	private Texture MenuSelector;
	private Texture mouseImage;
	private Texture wasdImage;
	private Texture eImage;
	private Texture cImage;
	private Texture spaceImage;
	private Texture shiftImage;
	private Texture bButtonImage;
	private Texture aButtonImage;
	private Texture xButtonImage;
	private Texture yButtonImage;
	private Texture lbButtonImage;
	private Texture lStickButtonImage;
	private Texture rStickButtonImage;
	private int levSelect;					//keeps track of what level select option the user is on
	private int numSelect;					//keeps track of what main menu option the user is on
	private int maxNumSelect;				//number of items on the main menu
	private int maxLevSelect;				//number of items on the levels select screen
	private float waitTime;					//counter used to delay the joystick
	private float waitPeriod;				//how long to wait for next input
	private bool axisReady;					//Determines when axis is ready to recieve next input


	//global variables
	public static string score;
	public static string time1;
	public static string time2;
	public static string health;
    public static bool hard = false ;
    public static bool meduim = false;
    public static bool easy = false;
    
	Vector2 scrollPosition;					//current position of the scroll wheel

	public enum Page {						//Pages available through the main menu
		Main, Levels, Difficulty, Credits, Controls
	}
	
	private Page currentPage;





	//Start gets resources and variables set when the main menu level is loaded
	void Start () {
		if (Input.GetJoystickNames ().Length == 0) {
			Cursor.visible = true;					//Only show the mouse cursor if there is no
		}												// controller plugged in
		score = "000000";
		time1 = "00:00";
		time2 = "00:00";
        health = "5";
		levSelect = 1;									//what level select option the user is on
		numSelect = 1;									//what main menu option the user is on
		maxNumSelect = 5;								//number of items on the main menu
		maxLevSelect = 7;								//number of items on the levels select screen
		waitTime = 0.0f;								//Timer for delay
		waitPeriod = 0.25f;								//Time to wait for analog stick delay
		axisReady = true;								//true when axis is ready to be used
		bButtonImage = Resources.Load("xboxControllerButtonB") as Texture; //"B" texture controller
		aButtonImage = Resources.Load("xboxControllerButtonA") as Texture; //"A" texture controller
		xButtonImage = Resources.Load("xboxControllerButtonX") as Texture; //"X" texture controller
		yButtonImage = Resources.Load("xboxControllerButtonY") as Texture; //"Y" texture controller
		lbButtonImage = Resources.Load("xboxControllerLeftShoulder") as Texture; //"LB" texture controller
		lStickButtonImage = Resources.Load ("xboxControllerLeftThumbstick") as Texture; //Left Joystick texture controller
		rStickButtonImage = Resources.Load ("xboxControllerRightThumbstick") as Texture; //Right Joystick texture controller
		MenuSelector = Resources.Load ("xboxControllerButtonA") as Texture; //MenuSelector texture
		Time.timeScale = 1;
		AudioListener.pause = false;					//Ensure audio listener is on
		mouseImage = Resources.Load ("MouseKey") as Texture; //Mouse texture
		wasdImage = Resources.Load ("WASDKey") as Texture; //"WASD" texture
		eImage = Resources.Load ("EKey") as Texture;	//"E" texture
		cImage = Resources.Load ("CKey") as Texture;	//"C" texture
		spaceImage = Resources.Load ("SpaceKey") as Texture; //Space texture
		shiftImage = Resources.Load ("ShiftKey") as Texture; //Shift texture
	}

	//-----------------------------------------------------------------------------------------------------
	//Currently Update contains code regarding input from a controller and how certain
	//inputs will be used to navigate the main menu
	void Update(){
		//print (1/Time.deltaTime);
		if (Input.GetJoystickNames ().Length != 0) {			//Only do this if controller is plugged in
			if (currentPage == Page.Main) {						//If player is currently on the main menu page
				if (Input.GetButtonDown ("Jump")) {				//Press the "A" button
					switch (numSelect) {					    //Switch case depending on numSeleect value	
					case 1:
						Application.LoadLevel ("Introduction"); //numSelect = 1, Start level 1
						break;
					case 2:
						currentPage = Page.Levels;				//numSelect = 2, Go to levels menu page
						break;
                    case 3:
						currentPage = Page.Controls;			//numSelect = 3, Go to controls menu page
						break;
					case 4:
						currentPage = Page.Credits;				//numSelect = 4, Go to credits menu page
						break;
					case 5:
						Application.Quit ();					//numSelect = 5, Quit the game
						break;
					default:
						Application.Quit ();					//Default, Quit the game
						break;
					} 
				}
	
				if (Input.GetAxisRaw ("MenuNavigation") == 1) {	//left analog stick pressed down
					if((axisReady == true) || (waitTime > waitPeriod)){ //if axis is ready or waitTime exceeds waitPeriod
						if (numSelect < maxNumSelect) {			//current maxNumSelect = 5
							numSelect += 1;						//increment numSelect
						}
					axisReady = false;							//mark axis is not ready
					waitTime = 0.0f;							//reset waitTime
					}
				} else if (Input.GetAxisRaw ("MenuNavigation") == (-1)) { //left analog stick pressed up
					if((axisReady == true) || (waitTime > waitPeriod)){ //if axis is ready or waitTime exceeds waitPeriod
						if (numSelect > 1) {
							numSelect -= 1;						//decrement numSelect
						}
					axisReady = false;							//mark axis is not ready
					waitTime = 0.0f;							//reset waitTime
					}
				}else{											//When left stick position recenters
					axisReady = true;							//mark axis is ready
				}
				

			}else if (currentPage == Page.Levels) {				//If player is currently on the level select menu
				if (Input.GetButtonDown ("Jump")){				//Press the "A" button
					switch (levSelect) {						//Switch case depending on levSelect value
					case 1:
						Application.LoadLevel ("Introduction"); //levSelect = 1, Load level 1
						break;
					case 2:
						Application.LoadLevel ("Transition");	//levSelect = 2, Load level 2
						break;
					case 3:
						Application.LoadLevel ("ForestClearing");	//levSelect = 3, Load Hub World
						break;
					case 4:
						Application.LoadLevel ("iceCave");		//levSelect = 4, Load Ice Caves
						break;
					case 5:
						Application.LoadLevel ("TimewornVillage"); //levSelect = 5, Load Time Trial
						break;
					case 6:
						Application.LoadLevel ("TeleportPuzzle"); //levSelect = 6, Load  Teleporter
						break;
					case 7:										
						currentPage = Page.Main;				//levSelect = 7, Return to main menu
						levSelect = 1;							//set levSelect = 1
						break;
					} 
				}
			
				if (Input.GetAxisRaw ("MenuNavigation") == 1) {	//left analog stick pressed down
					if((axisReady == true) || (waitTime > waitPeriod)){ //if axis is ready or waitTime exceeds waitPeriod
						if (levSelect < maxLevSelect) {		    //Current maxLevSelect = 7
							levSelect += 1;						//increment levSelect
						}
						axisReady = false;					    //mark axis is not ready
						waitTime = 0.0f;						//reset waitTime
					}
				} else if (Input.GetAxisRaw ("MenuNavigation") == (-1)) { //left analog stick pressed up
					if((axisReady == true) || (waitTime > waitPeriod)){ //if axis is ready or waitTime exceeds waitPeriod
						if (levSelect > 1) {					
							levSelect -= 1;						//decrement levSelect
						}
					axisReady = false;							//mark axis is not ready
					waitTime = 0.0f;							//rest waitTime
					}
				}else{											//when left stick position recenters
					axisReady = true;							//mark axis is ready
				}

			}else if ((currentPage == Page.Credits || currentPage == Page.Controls)) { //if player is currently on credits or controls menu
				if (Input.GetButtonDown ("Jump")) {				//press the "A" button
					currentPage = Page.Main;					//return to main menu
					scrollPosition.y = 0;						//reset scrollPosition to original location
				}
				if (Input.GetAxisRaw ("MenuNavigation") == 1) { //left analog stick pressed down
					if((axisReady == true) || (waitTime > waitPeriod)){ //if axis is ready or waitTime exceeds waitPeriod
						scrollPosition.y = scrollPosition.y + 100; //make the scroll bar scroll down
						axisReady = false;						//mark axis is not ready
						waitTime = 0.0f;						//reset waitTime
					}
				}else if (Input.GetAxisRaw ("MenuNavigation") == (-1)) { //left analog stick pressed up
					if((axisReady == true) || (waitTime > waitPeriod)){ //if axis is ready or waitTime exceeds waitPeriod
						scrollPosition.y = scrollPosition.y - 100; //make scroll bar scroll up
						axisReady = false;						//mark axis is not ready
						waitTime = 0.0f;						//reset waitTime
					}
				}else{											//when left stick position recenters
					axisReady = true;							//mark axis is ready	
				}
			}

		if (waitTime < 1.0f){
			waitTime += UnityEngine.Time.deltaTime;					//increment waitTime
			}
		}
	}




	//-----------------------------------------------------------------------------------------------------
	//Depeding on what the current page is set to the OnGUI method
	//will draw the appropriate GUI
	void OnGUI () {
		DrawHeader (new Rect(((Screen.width - 1000) / 2), (Screen.height / 12), 1000, 400));
		switch (currentPage) {
			case Page.Main:
				MainMenu();
				break;
			case Page.Credits:
				ShowCredits();
				break;
			case Page.Controls:
				ShowControls();
				break;
            case Page.Difficulty:
                ShowDifficulty();
                break;
            case Page.Levels:
				ShowLevels();
				break;
		} 
	}




	//-----------------------------------------------------------------------------------------------------
	//This is resposible for adding the main title text to
	//the main menu
	void DrawHeader(Rect position) {
		string text = "Hunt for the Artifact";
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





	//-----------------------------------------------------------------------------------------------------
	//Displays the credits written in the credit string
	void ShowCredits() {
		//Sets teh background color, font size, and text alignment
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 18;
		//begin the page
		BeginPage(500, 300);
		scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (500), GUILayout.Height (300));
		foreach(string credit in credits) {
			GUILayout.Label(credit);
		}
		GUILayout.EndScrollView ();
		//endPage draws back button
		EndPage();
		//If the controller is plugged in display the menu selector
		//at this position. This is where the back button will be located.
		//The menu selector and back button are outside of the page
		if (Input.GetJoystickNames ().Length != 0) {
			GUI.Label(new Rect((Screen.width/2) + 22, (Screen.height/2) + (Screen.height /3), 20, 20), MenuSelector);
		}
	}




	//-----------------------------------------------------------------------------------------------------
	//When called draws the back button one the page.
	void ShowBackButton() {
			if (GUI.Button (new Rect (((Screen.width / 2) - 30), ((Screen.height / 2) + (Screen.height / 3)), 75, 20), "Back")) {
				currentPage = Page.Main;
			}
	}


    


    //-----------------------------------------------------------------------------------------------------
    //This shows the GUI for the levels page
    void ShowLevels() {
		BeginPage (200, 200);									//Create a 200x200 window in the middle of the screen
		if (GUILayout.Button ("Level 1")) {						//Create a button that loads level 1
			Application.LoadLevel ("Introduction");
		}
		if (GUILayout.Button("Level 2")) {						//Create a button that loads level 2 
			Application.LoadLevel ("Transition");
		}
        if (GUILayout.Button("Level 3"))						//Create a button that loads Hub World
        {
            Application.LoadLevel("ForestClearing");
        }
        if (GUILayout.Button("Ice Cave"))						//Create a button that loads Ice Cave
        {
            Application.LoadLevel("iceCave");
        }
        if (GUILayout.Button("Timeworn Village"))				//Create a button that loads Time Trial
        {
            Application.LoadLevel("TimewornVillage");
        }
        if (GUILayout.Button("Teleporter Level"))				//Create a button that loads the Teleporter
        {
            Application.LoadLevel("TeleportPuzzle");
        }

		if (Input.GetJoystickNames ().Length != 0) {			//Only draws the MenSelector if controller is connected
			switch (levSelect) {								//MenuSelector position depends levSelect's value
			case 1:
				GUI.Label (new Rect (170, 0, 20, 20), MenuSelector); //draw menuSelector on level 1 button
				break;
			case 2:
				GUI.Label (new Rect (170, 25, 20, 20), MenuSelector); //draw menuSelector on level 2 button 
				break;
			case 3:
				GUI.Label (new Rect (170, 50, 20, 20), MenuSelector); //draw menuSelector on Hub World button
				break;
			case 4:
				GUI.Label (new Rect (170, 75, 20, 20), MenuSelector); //draw menuSelector on Ice Cave button
				break;
			case 5:
				GUI.Label (new Rect (170, 100, 20, 20), MenuSelector); //draw menuSelector on Time Trial button
				break;
			case 6:
				GUI.Label (new Rect (170, 125, 20, 20), MenuSelector); //draw menuSelector on Teleporter button
				break;
			} 
		}
		EndPage ();												//end page and draw back button
		if (levSelect == 7){									//draw menuSelector on back button
			GUI.Label (new Rect (((Screen.width / 2) + 25), (Screen.height / 2) + (Screen.height / 3), 20, 20), MenuSelector);
		}
	}




	//-----------------------------------------------------------------------------------------------------
	//allocates a specific area for GUI to be drawn
	void BeginPage(int width, int height) {
		GUILayout.BeginArea( new Rect(((Screen.width - width) / 2), ((Screen.height - height) / 2), width, height));
	}





	//-----------------------------------------------------------------------------------------------------
	//ends the area allocated for the GUI and calls the method
	//to draw the back button
	void EndPage() {
		GUILayout.EndArea();
		if (currentPage != Page.Main) {
			ShowBackButton();
		}
	}




	//-----------------------------------------------------------------------------------------------------
	//This draws the Controls pages GUI
	void ShowControls() {
		if (Input.GetJoystickNames ().Length == 0) {			//If a controller is not connected, display mouse and keyboard controls
			GUI.color = Color.white;							//set background color, font size, and text anchoring
			GUI.skin.label.fontSize = 30;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			BeginPage (400, 300);								//Draw a 400x300 area on the screen
			scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (400), GUILayout.Height (300));
																//Creates a scroll wheel
			GUILayout.BeginHorizontal ();						//Create a row
			GUILayout.BeginVertical ();							//Create a column for images
			GUILayout.Label (mouseImage);
			GUILayout.Label (wasdImage);
			GUILayout.Label (eImage);
			GUILayout.Label (spaceImage);
			GUILayout.Label (cImage, GUILayout.Height (75));
			GUILayout.Label (shiftImage);
			GUILayout.EndVertical ();							//end column
			GUILayout.BeginVertical ();							//Create a column for text
			GUILayout.Label ("Camera", GUILayout.Height (75));
			GUILayout.Label ("Movement", GUILayout.Height (75));
			GUILayout.Label ("Interact", GUILayout.Height (55));
			GUILayout.Label ("Jump", GUILayout.Height (75));
			GUILayout.Label ("Crouch", GUILayout.Height (75));
			GUILayout.Label ("Sprint", GUILayout.Height (75));
			GUILayout.EndVertical ();							//end column
			GUILayout.EndHorizontal ();							//end row
			GUILayout.EndScrollView ();							//end scroll area
			EndPage ();											//end the allocated area and draw back button
			GUI.skin.label.alignment = TextAnchor.UpperLeft;
		} else {												//If the controller is connected draw the controller controls
			GUI.color = Color.white;							//set background color, font size, and text anchoring
			GUI.skin.label.fontSize = 30;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			BeginPage (600, 300);								//Create a 600x300 area
			scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (600), GUILayout.Height (300));
																//Create a scroll wheel
			GUILayout.BeginHorizontal ();						//Create a row
			GUILayout.BeginVertical ();							//Create a column for images
			GUILayout.Label (rStickButtonImage, GUILayout.Height(75));
			GUILayout.Label (lStickButtonImage, GUILayout.Height(75));
			GUILayout.Label (xButtonImage, GUILayout.Height(75));
			GUILayout.Label (aButtonImage, GUILayout.Height(75));
			GUILayout.Label (bButtonImage, GUILayout.Height (75));
			GUILayout.Label (lbButtonImage, GUILayout.Height(75));
			GUILayout.EndVertical ();							//end column
			GUILayout.BeginVertical ();							//Create a column for text
			GUILayout.Label ("Camera", GUILayout.Height (75));
			GUILayout.Label ("Movement", GUILayout.Height (75));
			GUILayout.Label ("Interact", GUILayout.Height (55));
			GUILayout.Label ("Jump", GUILayout.Height (75));
			GUILayout.Label ("Crouch", GUILayout.Height (75));
			GUILayout.Label ("Sprint", GUILayout.Height (75));
			GUILayout.EndVertical ();							//end column
			GUILayout.EndHorizontal ();							//end row
			GUILayout.EndScrollView ();							//end scroll area
			EndPage ();											//end the allocated area and draw back button
			GUI.skin.label.alignment = TextAnchor.UpperLeft;
			GUI.Label(new Rect((Screen.width/2) + 22, (Screen.height/2) + (Screen.height /3), 20, 20), MenuSelector);
																//Draw the menuSelector on the back button
		}
	}

    /// <summary>
    /// Added show difficulty page
    /// </summary>
  

    void ShowDifficulty()
    {
       
        GUI.color = Color.white;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        
        BeginPage(200, 200);    //Create a 200x200 window in the middle of the screen

        if (GUILayout.Button("Easy"))
        {                       //Create a button that selects an easier difficulty
            easy = true; 
            
            Application.LoadLevel("Introduction");
        }
        if (GUILayout.Button("Medium"))
        {                       //Create a button that selects a meduim difficulty
            meduim = true;
          
            Application.LoadLevel("Introduction");
        }
        if (GUILayout.Button("Hard"))
        {                       //Create a button that selects a challenging difficulty
            hard = true;
           
            Application.LoadLevel("Introduction");
        }
        EndPage();
    }


    //-----------------------------------------------------------------------------------------------------
    //Contains the GUI for the main menu
    void MainMenu() {
		BeginPage(200,200);										//Create a 200x200 area on the screen
		if (GUILayout.Button ("Start Game")) {					//Create a buttons that loads level 1
			Application.LoadLevel ("Introduction"); 
		}
		if (GUILayout.Button ("Level Select")) {				//Create a button that goes to level select menu
			currentPage = Page.Levels;
		}
        if (GUILayout.Button("Difficulty"))
        {                                                       //Create a button that goes to difficulty select menu
            currentPage = Page.Difficulty;
        }
        if (GUILayout.Button ("Controls")) {					//Create a button that goes to controls menu
			currentPage = Page.Controls;
		}
		if (GUILayout.Button ("Credits")) {						//Create a button that goes to credits menu
			currentPage = Page.Credits;
		}
		if (GUILayout.Button ("Exit to Desktop")) {				//Create a button that exits the game
			Application.Quit ();
		}

		if (Input.GetJoystickNames ().Length != 0) {			//Only show MenuSelector if controller is connected
			switch (numSelect) {								//MenuSelector position depends on numSelect's value
			case 1:
				GUI.Label (new Rect (170, 0, 20, 20), MenuSelector); //draw menuSelector on Start Game button
				break;
			case 2:
				GUI.Label (new Rect (170, 25, 20, 20), MenuSelector); //draw menuSelector on Level Selection button
				break;
			case 3:
				GUI.Label (new Rect (170, 50, 20, 20), MenuSelector); //draw menuSelector on Show Controls button
				break;
			case 4:
				GUI.Label (new Rect (170, 75, 20, 20), MenuSelector); //draw menuSelector on Show Credits button
				break;
			case 5:
				GUI.Label (new Rect (170, 100, 20, 20), MenuSelector); //draw menuSelctor on Exit Game button
				break;
			default:
				GUI.Label (new Rect (170, 100, 20, 20), MenuSelector); //default: draw menuSelector on Exit Game button
 				break;											
			} 
		}
		EndPage ();												//end allocated area, but no back button since main menu page
	}
}