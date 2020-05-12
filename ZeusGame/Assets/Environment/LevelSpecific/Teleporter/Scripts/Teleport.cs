using UnityEngine;
using System.Collections;
//Editted by Jordan Hoffman to rotate player when coming out of some of the portals
public class Teleport : MonoBehaviour {
    public Transform exit;
    private Material defaultMaterial;
    public Material portalMaterial;
	private CharacterMotor player;
    private bool isOpen = false;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<CharacterMotor> ();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider other)
    {
        if (isOpen)
        {
            other.transform.position = exit.transform.position;
            player.SetVelocity(Vector3.zero);
            if (exit.tag.Equals("Teleport12"))
            {
                other.transform.Rotate(0, 270, 0);
            }
            if (exit.tag.Equals("Teleport10"))
            {
                other.transform.Rotate(0, 90, 0);
            }

        }
    }

    public void OpenPortal()
    {
        print("Opening Portal");
        isOpen = true;
        defaultMaterial = gameObject.GetComponent<MeshRenderer>().material;
        gameObject.GetComponent<MeshRenderer>().material = portalMaterial;
    }

    public void ClosePortal()
    {
        isOpen = false;
        gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
    }
}
