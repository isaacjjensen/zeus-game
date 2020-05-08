using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPickup : Interactable
{
    public GameObject toolPrefab;

    private Tool tool;
    private GUIManager guiManager;

    void Start()
    {
        if (!findAndSetGUIManager())
        {
            print("ERROR: Could not find HUD or the HUD does not have the GUIManager script attached.");
        }
        if (!instantiateTool())
        {
            print("ERROR: Could not instantiate a new Tool from the provided Tool Prefab.");
        }
    }

    private bool findAndSetGUIManager()
    {
        guiManager = GameObject.Find("HUD").GetComponent<GUIManager>();
        return guiManager != null;
    }

    private bool instantiateTool()
    {
        GameObject instanceGameObject;
        instanceGameObject = Instantiate(toolPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        tool = instanceGameObject.GetComponent<Tool>();
        instanceGameObject.SetActive(false);
        return tool != null;
    }

    public override void Interact(Transform interactor)
    {
        AddToolToInventory();
    }

    private void AddToolToInventory()
    {
        GameObject cameraObject = GameObject.Find("ToolCamera");
        Camera camera = cameraObject.GetComponent<Camera>();
        Vector3 cameraForward = camera.transform.forward;
        Vector3 cameraRight = camera.transform.right;
        Vector3 cameraUp = camera.transform.up;
        Vector3 toolPosition = tool.getPositionVector();
        Vector3 toolOrientation = tool.getOrientationVector();
        guiManager.getToolInventoryManager().AddToolToInventory(tool);
        tool.gameObject.transform.position = camera.transform.position 
                                                + new Vector3(
                                                    toolPosition.x * cameraForward.x 
                                                        + toolPosition.y * cameraRight.x 
                                                        + toolPosition.z * cameraUp.x,
                                                    toolPosition.x * cameraForward.y 
                                                        + toolPosition.y * cameraRight.y 
                                                        + toolPosition.z * cameraUp.y,
                                                    toolPosition.x * cameraForward.z 
                                                        + toolPosition.y * cameraRight.z 
                                                        + toolPosition.z * cameraUp.z
                                                 );
        tool.gameObject.transform.rotation = camera.transform.rotation;
        tool.gameObject.transform.Rotate(toolOrientation.x, toolOrientation.y, toolOrientation.z, Space.Self);
        tool.gameObject.transform.parent = camera.transform;
        gameObject.SetActive(false);
    }
}
