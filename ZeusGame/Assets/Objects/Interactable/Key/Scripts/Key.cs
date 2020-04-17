//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class Key : Interactable {

	private KeysManager keysManager;

	void Start () {
    }

    public override void Interact (Transform interactor)
	{
        if (keysManager == null)
        {
            keysManager = GameObject.Find("HUD").GetComponent<GUIManager>().getEquippedToolManager().getKeysManager();
        }
        keysManager.incrementKeyCount();
		AudioSource.PlayClipAtPoint (GetComponent<AudioSource>().clip, transform.position);
		GameObject.Destroy(this.gameObject);
	}
}
