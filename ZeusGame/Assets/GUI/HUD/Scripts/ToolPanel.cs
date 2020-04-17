using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolPanel : MonoBehaviour
{
    private Tool tool;

    public ToolPanel()
    {
        tool = null;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void setTool(Tool tool)
    {
        print("Setting tool...");
        this.tool = tool;
        if (tool != null)
        {
            updateSprite();
        }
    }

    private void updateSprite()
    {
        
        gameObject.transform.Find("ToolPicturePanel").transform.Find("ToolPicture")
            .GetComponent<Image>().sprite = tool.getBoxImage();
        gameObject.transform.Find("ToolPicturePanel").transform.Find("ToolPicture")
            .GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f); // Needs to be white with no transparency (maximum alpha)
    }

    public Tool getTool()
    {
        return tool;
    }

    public bool hasTool()
    {
        return tool != null;
    }
}
