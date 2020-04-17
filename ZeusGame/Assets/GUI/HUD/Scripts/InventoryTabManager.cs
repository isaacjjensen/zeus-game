using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTabManager : MonoBehaviour
{
    public enum InventoryTab
    {
        TOOLS = 0,
        COLLECTIBLES = 1,
        NOTES = 2
    }

    private bool initialized = false;
    private GameObject[] headerTexts = new GameObject[3];
    private GameObject[] inventoryPanels = new GameObject[3];
    private InventoryTab currentTab = InventoryTab.TOOLS;

    void Start()
    {
        if (!initialized)
        {
            Initialize();
        }
    }

    public void Load()
    {
        if (!initialized)
        {
            Initialize();
        }
        for (int i = 0; i < 3; ++i)
        {
            if (i == (int)currentTab)
            {
                headerTexts[i].GetComponent<Animator>().SetBool("IsSelected", true);
                headerTexts[i].GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else
            {
                headerTexts[i].GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 0.352941f);
            }
        }
    }

    private void Initialize()
    {
        headerTexts[(int)InventoryTab.TOOLS] = gameObject.transform.Find("ToolsText").gameObject;
        headerTexts[(int)InventoryTab.COLLECTIBLES] = gameObject.transform.Find("CollectiblesText").gameObject;
        headerTexts[(int)InventoryTab.NOTES] = gameObject.transform.Find("NotesText").gameObject;

        headerTexts[(int)currentTab].GetComponent<Animator>().SetBool("IsSelected", true);

        inventoryPanels[(int)InventoryTab.TOOLS] = gameObject.transform.parent.transform.Find("ToolSuperPanel").gameObject;
        inventoryPanels[(int)InventoryTab.COLLECTIBLES] = gameObject.transform.parent.transform.Find("CollectiblesSuperPanel").gameObject;
        inventoryPanels[(int)InventoryTab.NOTES] = gameObject.transform.parent.transform.Find("NotesSuperPanel").gameObject;

        initialized = true;
    }

    public void ChangeTab(int tab)
    {
        if (tab != (int)currentTab)
        {
            currentTab = (InventoryTab)tab;
            AnimateTabs();
            ChangePanel();
        }
    }

    private void AnimateTabs()
    {
        for (int i = 0; i < 3; ++i)
        {
            if (i == (int)currentTab)
            {
                headerTexts[i].GetComponent<Animator>().SetBool("IsSelected", true);
            } else
            {
                headerTexts[i].GetComponent<Animator>().SetBool("IsSelected", false);
            }
        }
    }

    private void ChangePanel()
    {
        for (int i = 0; i < 3; ++i)
        {
            if (i == (int)currentTab)
            {
                inventoryPanels[i].SetActive(true);
            }
            else
            {
                inventoryPanels[i].SetActive(false);
            }
        }
    }
}
