using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public GameObject[] collectiblePanels = new GameObject[6];

    void Start()
    {
    }

    public bool AddCollectible(Collectible.CollectibleType type)
    {
        if (collectiblePanels[(int)type] != null && collectiblePanels[(int)type].GetComponent<CollectiblePanel>() != null)
        {
            if (collectiblePanels[(int)type].GetComponent<CollectiblePanel>().AddCollectible(type))
            {
                return true;
            }
        }
        return false;
    }
}
