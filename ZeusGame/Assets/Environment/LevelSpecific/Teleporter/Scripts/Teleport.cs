using UnityEngine;
using System.Collections;
//Editted by Jordan Hoffman to rotate player when coming out of some of the portals
public class Teleport : MonoBehaviour {
    public Transform exit;
	private CharacterMotor player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<CharacterMotor> ();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider other)
    {
        other.transform.position = exit.transform.position;
		player.SetVelocity(Vector3.zero);
		if (exit.tag.Equals("Teleport12")){
			other.transform.Rotate(0,270,0);
		}
		if (exit.tag.Equals ("Teleport10")) {
			other.transform.Rotate(0,90,0);
		}
    }
}
