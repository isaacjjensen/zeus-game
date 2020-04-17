//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public class KeyedDoor : Interactable {

	public int requiredKeys = 3;
	private int keysLeft;

    private KeysManager keysManager;

    void Start()
	{
		keysLeft = requiredKeys;
    }

	public override void Interact (Transform interactor)
	{
        if (keysManager == null)
        {
            keysManager = GameObject.Find("HUD").GetComponent<GUIManager>().getEquippedToolManager().getKeysManager();
        }
        int keyCount = keysManager.getKeyCount();
		if (keyCount < requiredKeys)
		{
            keysManager.decreaseKeyCountBy(keyCount);
			keysLeft -= keyCount;
			if (keysLeft != 0 )
            {
                string message;
                if (keysLeft == 1)
                {
                    message = "You need " + keysLeft + " more Key to Unlock this Door";
                }
                else
                {
                    message = "You need " + keysLeft + " more Keys to Unlock this Door";
                }
                GameObject.Find("HUD").GetComponent<GUIManager>().getHintManager().SubmitHintMessage(message, 4.0f);
			}
		}
		else
		{
			keysManager.decreaseKeyCountBy(requiredKeys);
			keysLeft = 0;

		}
		if (keysLeft <= 0)
		{
			GetComponent<SlidingDoor>().Activate();
			if (GetComponent<AudioSource>().isPlaying == false)
			{
				GetComponent<AudioSource>().Play();
			}
		}
	}
}
