//Written by Jordan Hoffman to make 1 of the 5 cylindars move up and down
using UnityEngine;
using System.Collections;

public class RaisingCylinder : MonoBehaviour
{
	private Vector3 origLocation;
	private float MaxUpandDown = 5.0f;
	private float Up, Down;
	private bool UporDown;

	public float moveSpeed = 2f;

	// Use this for initialization
	void Start ()
	{
		origLocation = this.transform.position;
		Up = origLocation.y + MaxUpandDown;
		Down = origLocation.y - MaxUpandDown;
		UporDown = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//If the cylinder is moving down check if it has reached the bottom.
		//If so move to minimum height and start moving upward.
		if (UporDown == false) {
			if (this.transform.position.y > Down){
				float newY = this.transform.position.y - (moveSpeed * Time.deltaTime);
				if (newY < Down){
					this.transform.position = new Vector3(origLocation.x, Down, origLocation.z);
					UporDown = true;
				}else{
					this.transform.position = new Vector3(origLocation.x, newY, origLocation.z);
				}
			}
		//If the cylinder is moving up check if it has reached the top.
		//If so move to maximum height and start moving downward.
		} else {
			if (this.transform.position.y < Up){
				float newY = this.transform.position.y + (moveSpeed * Time.deltaTime);
				if (newY > Up){
					this.transform.position = new Vector3(origLocation.x, Up, origLocation.z);
					UporDown = false;
				}else{
					this.transform.position = new Vector3(origLocation.x, newY, origLocation.z);
				}
			}
		}
	}
}

