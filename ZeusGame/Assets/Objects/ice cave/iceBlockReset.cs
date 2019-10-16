

//Editted by Jordan Hoffman to add functionality for controller to reset ice block, prevent
//the ice block from moving after being reset, and prevent resetting ice block on top of 
//player
using UnityEngine;
using System.Collections;

public class iceBlockReset : MonoBehaviour {

	public GameObject iceBlock;
	private GameObject player;

	// Use this for initialization
	void Start () {
		iceBlock = GameObject.Find ("iceBlock");
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.R) || Input.GetKeyDown("joystick button 3")) 
		{
			float x = 37.08F;
			float y = -2.1954F;
			float z = -6F;
			//Player cannot reset the ice block when standing where the ice block resets to.
			if (player.transform.position.x > (x + 1.2) || player.transform.position.x < (x - 1.2) || player.transform.position.z > (z + 1.2) || player.transform.position.z < (z - 1.2)){
				iceBlock.transform.position = new Vector3 (x, y, z);
				iceBlock.GetComponent<Rigidbody>().isKinematic = false;
				iceBlock.GetComponent<Rigidbody>().velocity = Vector3.zero;
				iceBlock.GetComponent<Rigidbody>().isKinematic = true;
			}
		
		}
	}
}
