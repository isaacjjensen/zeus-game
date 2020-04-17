using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolInventoryManager : MonoBehaviour
{
    public GameObject[] toolPanelGameObjects = new GameObject[8];
    private GameObject lastSelectedPanel;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void AddToolToInventory(Tool toolToAdd)
    {
        if (Array.Exists(toolPanelGameObjects, toolPanelGameObject => 
                                               toolPanelGameObject.GetComponent<ToolPanel>().hasTool() 
                                               && toolPanelGameObject.GetComponent<ToolPanel>().getTool().isEqual(toolToAdd))) {
            print("Tool " + toolToAdd.getToolName() + " already exists in inventory.");
            return;
        }
        for (int i = 0; i < toolPanelGameObjects.Length; i++)
        {
            if (!toolPanelGameObjects[i].GetComponent<ToolPanel>().hasTool())
            {
                toolPanelGameObjects[i].GetComponent<ToolPanel>().setTool(toolToAdd);
                return;
            }
        }
        print("Tool inventory is full! Could not add " + toolToAdd.getToolName());
    }

    public void SelectTool(GameObject inToolPanelGameObject)
    {
        if (lastSelectedPanel == inToolPanelGameObject)
        {
            inToolPanelGameObject.GetComponent<Animator>().SetBool("IsSelected", false);
            gameObject.transform.parent.transform.Find("EquippedToolPanel").GetComponent<EquippedToolManager>().equipTool(null);
            GameObject.Find("HUD").GetComponent<GUIManager>().getHandManager().equipTool(null);
            lastSelectedPanel = null;
        } else
        {
            foreach (GameObject panel in toolPanelGameObjects)
            {
                if (panel != inToolPanelGameObject)
                {
                    panel.GetComponent<Animator>().SetBool("IsSelected", false);
                }
                else
                {
                    if (panel.GetComponent<ToolPanel>().hasTool())
                    {
                        Tool tool = panel.GetComponent<ToolPanel>().getTool();
                        panel.GetComponent<Animator>().SetBool("IsSelected", true);
                        lastSelectedPanel = inToolPanelGameObject;
                        gameObject.transform.parent.transform.Find("EquippedToolPanel").GetComponent<EquippedToolManager>().equipTool(tool);
                        GameObject.Find("HUD").GetComponent<GUIManager>().getHandManager().equipTool(tool);
                    } else
                    {
                        lastSelectedPanel = null;
                        gameObject.transform.parent.transform.Find("EquippedToolPanel").GetComponent<EquippedToolManager>().equipTool(null);
                        GameObject.Find("HUD").GetComponent<GUIManager>().getHandManager().equipTool(null);
                    }
                }
            }
        }
    }

    public void LoadSelectedTool()
    {
        foreach (GameObject panel in toolPanelGameObjects)
        {
            panel.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.392157f);
        }
        if (lastSelectedPanel != null && lastSelectedPanel.GetComponent<ToolPanel>().hasTool())
        {
            lastSelectedPanel.GetComponent<Animator>().SetBool("IsSelected", true);
        }
    }

    public void UnloadSelectedTool()
    {
        foreach (GameObject panel in toolPanelGameObjects)
        {
            panel.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.392157f);
        }
    }
}
