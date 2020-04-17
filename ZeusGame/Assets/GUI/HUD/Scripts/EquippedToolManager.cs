using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedToolManager : MonoBehaviour
{
    private Tool equippedTool;

    // Start is called before the first frame update
    void Start()
    {
    }
    
    public void equipTool(Tool inTool)
    {
        if (inTool != null && equippedTool != null)
        {
            gameObject.GetComponent<Animator>().SetBool("ToolEquipped", false);
            setEquippedToolText("Empty");
        }

        equippedTool = inTool;
        if (equippedTool != null)
        {
            gameObject.transform.Find("EquippedToolRune").transform.Find("EquippedToolImage").GetComponent<Image>().sprite = equippedTool.circleImage;
            gameObject.GetComponent<Animator>().SetBool("ToolEquipped", true);
            setEquippedToolText(equippedTool.getToolName());
        } else
        {
            gameObject.GetComponent<Animator>().SetBool("ToolEquipped", false);
            setEquippedToolText("Empty");
        }
    }

    private void setEquippedToolText(string text)
    {
        gameObject.transform.Find("ToolName").GetComponent<Text>().text = text;
    }

    public void loadEquippedTool()
    {
        if (equippedTool != null)
        {
            gameObject.GetComponent<Animator>().SetBool("ToolEquipped", true);
        }
    }

    public KeysManager getKeysManager()
    {
        KeysManager keysManager = gameObject.transform.Find("KeysPanel").gameObject.GetComponent<KeysManager>();
        keysManager.Initialize();
        return keysManager;
    }
}
