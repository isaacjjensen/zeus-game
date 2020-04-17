//Michael Schilling
//CSci 448
//Editted by Jordan Hoffman to respawn pillars after a certain delay
using UnityEngine;
using System.Collections;

public class FallingPlatform : AbstractResetable {

	public float resetTimeDelay = 10.0f;
	public float fallTimeDelay = 2.0f;
	public float fallDistance = 150.0f;
	private float finalHeight;
	private Vector3 originalLoc;

	void Start()
	{
		originalLoc = this.transform.position;
		finalHeight = transform.position.y - fallDistance;
	}

	void OnTriggerEnter(Collider Other)
	{
		if (Other.tag == "Player") 
		{
			if (!GetComponent<AudioSource>().isPlaying) {
					GetComponent<AudioSource>().Play ();
			}

			print ("I'm starting to fall!");
			StartCoroutine ("Fall");
		}

	}

	IEnumerator Fall()
	{
		yield return new WaitForSeconds(fallTimeDelay);
		GetComponent<Rigidbody>().isKinematic = false;
		GetComponent<Rigidbody>().useGravity = true;
		while(transform.position.y > finalHeight)
		{
			yield return null;
		}
		GetComponent<Rigidbody>().isKinematic = true;
		GetComponent<Rigidbody>().useGravity = false;
		yield return new WaitForSeconds(resetTimeDelay);//Time delay before pillar respawns
		StartCoroutine ("Reset");
	}

	public override void Reset()
	{
		this.transform.position = originalLoc;
		GetComponent<Rigidbody>().isKinematic = true;
		GetComponent<Rigidbody>().useGravity = false;
		print ("I have Reset");
	}
}
