//Created by Jordan Hoffman when player is standing within the room, pressing R or Y will
//reset the position of the rocks.
using UnityEngine;
using System.Collections;

public class RockResetZone : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		
	}

	void OnTriggerStay(Collider Player){
			if (Player.tag == "Player") {
				if (Input.GetKeyUp (KeyCode.R) || Input.GetKeyDown("joystick button 3")){
					PuzzleRock[] allPuzzleRocks = GameObject.FindObjectsOfType<PuzzleRock>();
					for (int i = 0; i < allPuzzleRocks.Length; i++)
					{
						allPuzzleRocks[i].transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
						allPuzzleRocks[i].Reset();
					}
				}
		}
	}
}

