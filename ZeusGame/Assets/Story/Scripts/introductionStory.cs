//Randall Howatt
//CSci 448

//Editted by Jordan Hoffman to allow skipping the cutscene
//by pressing start on the controller.
using UnityEngine;
using System.Collections;

public class introductionStory : MonoBehaviour {

	private int stillIndex;
	private float lastUpdate;
	private float beginTime;

	private Texture[] introStills;
	
	void Start () {
		Time.timeScale = 1;
		AudioListener.pause = false;
		string loadTexture = "";
		introStills = new Texture[6];
		for (int i = 0; i < 6; i++) {
			loadTexture = ("IntroductionStill" + (i + 1));
			introStills[i] = Resources.Load (loadTexture) as Texture;
		}
		beginTime = Time.time;
		lastUpdate = Time.time;
		stillIndex = 0;
		GetComponent<AudioSource>().Play();
	}
	
	void LateUpdate () {
		if ((Time.time - beginTime) >= 30.0f) {
			Application.LoadLevel ("Level1");
		}
		if (((Time.time - lastUpdate) >= 5.0f) && (stillIndex < 6)) {
			stillIndex++;
			lastUpdate = Time.time;
		}
		if (Input.GetKeyDown ("escape") || Input.GetKeyDown ("joystick button 7")) {
			Application.LoadLevel ("Level1");
		}
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), introStills[stillIndex]);
	}
}