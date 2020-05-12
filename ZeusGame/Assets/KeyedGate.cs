using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyedGate : Interactable
{
    public GameObject gate;

    public int requiredKeys = 3;
    private int keysLeft;

    private bool firstTime = true;
    private bool gateIsOpen = false;
    private string message;

    private KeysManager keysManager;

    void Start()
    {
        keysLeft = requiredKeys;
    }

    public override void Interact(Transform interactor)
    {
        if (keysManager == null)
        {
            keysManager = GameObject.Find("HUD").GetComponent<GUIManager>().getEquippedToolManager().getKeysManager();
        }
        if (firstTime)
        {
            message = "This terminal requires " + requiredKeys + " physical keys in order to allow the command to unlock the gate.";
            GameObject.Find("HUD").GetComponent<GUIManager>().getHintManager().SubmitHintMessage(message, 4.0f);
            firstTime = false;
        } else
        {
            int keyCount = keysManager.getKeyCount();
            if (keyCount < requiredKeys)
            {
                keysManager.decreaseKeyCountBy(keyCount);
                keysLeft -= keyCount;
                if (keysLeft != 0)
                {
                    if (keysLeft == 1)
                    {
                        message = "You need " + keysLeft + " more keys to";
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
            if (keysLeft <= 0 && !gateIsOpen)
            {
                gate.transform.Rotate(new Vector3(0, 1, 0), 90.0f);
            }
        }
    }
}
