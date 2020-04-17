//Written by Christian Sandtveit
//Script which is used so that player can interact with books pressing the interact button (e)

//Editted by Jordan Hoffman to add alternate text for controller input
using UnityEngine;
using System.Collections;

public class InteractBook : MonoBehaviour
{
    public float rayLength; //Length of ray, i.e. how far away player can interact with book
    bool showBook1, showBook2, showBook3, showBook4, showBook5,showBook6;
    public AudioClip bookOpen;
    private AudioSource bOpen;

    // Use this for initialization
    void Start()
    {
        rayLength = 1.5f;
        showBook1 = false;
        showBook2 = false;
		showBook3 = false;
        showBook4 = false;
        showBook5 = false;
		showBook6 = false;
        bOpen = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Display text to screen
    void OnGUI()
    {
        bOpen.PlayOneShot(bookOpen);
        if (showBook1)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Search the caves for keys and treasures!");
        }
        if (showBook2)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Pull the lever and see what happens!");
        }
		if (showBook3)
		{
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Find the keys to unlock the gate.");
		}
        if (showBook4)
        {
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 400), "All you need is belief! Try walking to the door.");
        }
        if (showBook5)
        {
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 400), "Pick up a dart with E. Throw with left mouse");
        }
		if (showBook6) {
			if (Input.GetJoystickNames ().Length == 0) {
				GUI.Label (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 400), "Push the ice block by clicking E. Reset the ice block by clicking R.");
			} else{
				GUI.Label (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 400), "Push the ice block by pressing X. Reset the ice block by pressing Y.");
			}
		}
    }

    //Set bool variable to false, so that text dissapears
    void HideBook1()
    {
        showBook1 = false;
    }

    //Set bool variable to false, so that text dissapears
    void HideBook2()
    {
        showBook2 = false;
    }

	//Set bool variable to false, so that text dissapears
	void HideBook3()
	{
		showBook3 = false;
	}

    //Set bool variable to false, so that text dissapears
    void HideBook4()
    {
        showBook4 = false;
    }

    //Set bool variable to false, so that text dissapears
    void HideBook5()
    {
        showBook5 = false;
    }
	//Set bool variable to false, so that text dissapears
	void HideBook6()
	{
		showBook6 = false;
	}
}
