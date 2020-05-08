using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactable
{
    public CollectibleType type;

    public override void Interact(Transform interactor)
    {
        print("Trying to collect");
        Collect();
    }

    public void Collect()
    {
        if (GameObject.Find("HUD") == null)
        {
            print("shit");
        }
        if (GameObject.Find("HUD").GetComponent<GUIManager>() == null)
        {
            print("poop");
        }
        CollectibleManager bob = GameObject.Find("HUD").GetComponent<GUIManager>().getCollectibleManager();
        if (bob == null)
        {
            print("fuck");
        }
        if (type == null)
        {
            print("well okay");
        }
        print(bob);
        print("something");
        if (bob.AddCollectible(type))
        {
            print("Success");
            gameObject.SetActive(false);
        }
        else
        {
            print("Nope");
        }
    }

    public enum CollectibleType
    {
        ALIEN_ARTIFACT = 0,
        ALIEN_CORE = 1,
        ALIEN_FLOWER = 2,
        GOLD_CRYSTAL = 3,
        GAMETOY_CARTRIDGE = 4,
        DATAPAD = 5
    }
}
