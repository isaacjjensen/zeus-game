//Edited by Jordan Hoffman to add functionality for controller to reset ice block, prevent
//the ice block from moving after being reset, and prevent resetting ice block on top of 
//player
//Further edited by Parker Combs to preserve block rotation and fit better with new push script
using UnityEngine;
using System.Collections;

public class iceBlockReset : MonoBehaviour
{

	public GameObject iceBlock;
	private GameObject player;
	public Quaternion originalRotation;

	// Use this for initialization
	void Start()
	{
		iceBlock = GameObject.Find("iceBlock");
		player = GameObject.Find("Player");
		originalRotation = iceBlock.transform.rotation; //keeps track of ice block's original orientation
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyUp(KeyCode.R) || Input.GetKeyDown("joystick button 3"))
		{
			float x = 35.26F;
			float y = 29.95F;
			float z = -54.03F;
			float resetSpeed = 0.1F;
			//Player cannot reset the ice block when standing where the ice block resets to.
			if (player.transform.position.x > (x + 1.2) || player.transform.position.x < (x - 1.2) || player.transform.position.z > (z + 1.2) || player.transform.position.z < (z - 1.2))
			{
				iceBlock.transform.position = new Vector3(x, y, z);
				iceBlock.transform.rotation = Quaternion.Slerp(iceBlock.transform.rotation, originalRotation, Time.time * resetSpeed); //resets to original rotation
																																	   //iceBlock.GetComponent<Rigidbody>().isKinematic = false;
				iceBlock.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}
	}
}