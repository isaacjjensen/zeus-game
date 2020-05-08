using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIManager : MonoBehaviour
{
    private CollectibleManager collectibleManager;
    private EquippedToolManager equippedToolManager;
    private HandManager handManager;
    private HintManager hintManager;
    private InventoryTabManager inventoryTabManager;
    private ToolInventoryManager toolInventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        print("Starting GUI Manager");
        gameObject.transform.Find("HintText").GetComponent<TextMeshProUGUI>().text = "";
        if (!findAndSetEquippedToolManager())
        {
            print("ERROR: HUD hierarchy has changed, could not find Equipped Tool Panel or it no longer has the EquippedToolManager script attached.");
        }
        if (!findAndSetToolInventoryManager())
        {
            print("ERROR: HUD hierarchy has changed, could not find Tool Inventory Panel or it no longer has the ToolInventoryManager script attached.");
        }
        if (!findAndSetHandManager())
        {
            print("ERROR: HUD hierarchy has changed, could not find Hand Panel or it no longer has the HandManager script attached.");
        }
        if (!findAndSetHintManager())
        {
            print("ERROR: HUD hierarchy has changed, could not find Hint Text or it no longer has the HintManager script attached.");
        }
        if (!findAndSetInventoryTabManager())
        {
            print("ERROR: HUD hierarchy has changed, could not find Hint Text or it no longer has the HintManager script attached.");
        }
        if (!findAndSetCollectibleManager())
        {
            print("ERROR: HUD hierarchy has changed, could not find Hint Text or it no longer has the HintManager script attached.");
        }
    }

    private bool findAndSetToolInventoryManager()
    {
        toolInventoryManager = gameObject.transform.Find("InventoryPanel")
                                    .transform.Find("InventorySubpanel")
                                    .transform.Find("ToolSuperPanel")
                                    .transform.Find("ToolInventoryPanel").GetComponent<ToolInventoryManager>();
        return toolInventoryManager != null;
    }

    private bool findAndSetEquippedToolManager()
    {
        equippedToolManager = gameObject.transform.Find("InventoryPanel")
                                    .transform.Find("InventorySubpanel")
                                    .transform.Find("ToolSuperPanel")
                                    .transform.Find("EquippedToolPanel").GetComponent<EquippedToolManager>();
        return equippedToolManager != null;
    }

    private bool findAndSetHandManager()
    {
        handManager = gameObject.transform.Find("HandPanel").GetComponent<HandManager>();
        return handManager != null;
    }

    private bool findAndSetHintManager()
    {
        hintManager = gameObject.transform.Find("HintText").GetComponent<HintManager>();
        return hintManager != null;
    }

    private bool findAndSetInventoryTabManager()
    {
        inventoryTabManager = gameObject.transform.Find("InventoryPanel")
                                    .transform.Find("InventorySubpanel")
                                    .transform.Find("HeaderPanel").GetComponent<InventoryTabManager>();
        return hintManager != null;
    }

    private bool findAndSetCollectibleManager()
    {
        collectibleManager = gameObject.transform.Find("InventoryPanel")
                                    .transform.Find("InventorySubpanel")
                                    .transform.Find("CollectiblesSuperPanel")
                                    .transform.Find("CollectiblesPanel").GetComponent<CollectibleManager>();
        return collectibleManager != null;
    }

    public ToolInventoryManager getToolInventoryManager()
    {
        return toolInventoryManager;
    }

    public EquippedToolManager getEquippedToolManager()
    {
        return equippedToolManager;
    }

    public HandManager getHandManager()
    {
        return handManager;
    }

    public HintManager getHintManager()
    {
        return hintManager;
    }

    public InventoryTabManager getInventoryTabManager()
    {
        return inventoryTabManager;
    }

    public CollectibleManager getCollectibleManager()
    {
        print("Yeet, mutha fucka");
        if (collectibleManager == null)
        {
            print("Oooof");
        }
        return collectibleManager;
    }
}
