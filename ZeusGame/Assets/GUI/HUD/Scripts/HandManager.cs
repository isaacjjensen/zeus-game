using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour
{
    private Tool equippedTool, lastEquippedTool;
    private bool toolIsEquipped, toolIsSelected;
    private Sprite defaultSprite;

    // Start is called before the first frame update
    void Start()
    {
        defaultSprite = gameObject.transform.Find("ToolPane").transform.Find("ToolImage").GetComponent<Image>().sprite;
    }

    public void equipTool(Tool tool)
    {
        equippedTool = tool;
        updateToolSprite(tool);
        if (lastEquippedTool != tool && lastEquippedTool != null)
        {
            lastEquippedTool.unequip();
        }
        if (tool != null)
        {
            gameObject.GetComponent<Animator>().SetBool("ToolEquipped", true);
            gameObject.GetComponent<Animator>().SetBool("ToolSelected", true);
            toolIsEquipped = true;
            toolIsSelected = true;
            tool.equip();
            tool.unselect();
        } else
        {
            gameObject.GetComponent<Animator>().SetBool("ToolEquipped", false);
            toolIsEquipped = false;
            toolIsSelected = false;
        }
        lastEquippedTool = tool;
    }

    private void updateToolSprite(Tool tool)
    {
        if (tool == null)
        {
            gameObject.transform.Find("ToolPane").transform.Find("ToolImage").GetComponent<Image>().sprite = defaultSprite;
        } else
        {
            gameObject.transform.Find("ToolPane").transform.Find("ToolImage").GetComponent<Image>().sprite = tool.getCircleImage();
        }
    }

    public void toggleHoldingTool()
    {
        if (toolIsEquipped)
        {
            toolIsSelected = !toolIsSelected;
        } else
        {
            toolIsSelected = false;
        }
        gameObject.GetComponent<Animator>().SetBool("ToolSelected", toolIsSelected);
        if (toolIsSelected)
        {
            equippedTool.equip();
            equippedTool.select();
        } else
        {
            equippedTool.unequip();
            equippedTool.unselect();
        }
    }

    public bool isHoldingTool()
    {
        return toolIsEquipped && toolIsSelected;
    }

    public Tool getEquippedTool()
    {
        return equippedTool;
    }
}
