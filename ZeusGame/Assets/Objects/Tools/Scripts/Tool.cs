using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public Sprite boxImage;
    public Sprite circleImage;
    public string toolName;
    public Vector3 toolPosition;
    public Vector3 toolOrientation;

    private bool isBeingHeld;

    public abstract void action();

    // Used to differentiate animation between standing still, walking, and running
    public void updateAnimation(CharacterMotor character)
    {
        if (character.IsWalking())
        {
            gameObject.GetComponent<Animator>().SetBool("IsMoving", true);
        } else
        {
            gameObject.GetComponent<Animator>().SetBool("IsMoving", false);
        }
        if (character.IsSprinting())
        {
            gameObject.GetComponent<Animator>().SetBool("IsSprinting", true);
        } else
        {
            gameObject.GetComponent<Animator>().SetBool("IsSprinting", false);
        }
    }

    public void equip()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<Animator>().SetBool("IsEquipped", true);
    }

    public void unequip()
    {
        gameObject.GetComponent<Animator>().SetBool("IsEquipped", false);
        Invoke("setInactiveIfNotSelected", 1.0f);
    }

    private void setInactiveIfNotSelected()
    {
        if (!isBeingHeld)
        {
            gameObject.SetActive(false);
        }
    }

    public void select()
    {
        isBeingHeld = true;
    }

    public void unselect()
    {
        isBeingHeld = false;
    }

    public Sprite getBoxImage()
    {
        return boxImage;
    }

    public Sprite getCircleImage()
    {
        return circleImage;
    }

    public string getToolName()
    {
        return toolName;
    }

    public Vector3 getPositionVector()
    {
        return toolPosition;
    }

    public Vector3 getOrientationVector()
    {
        return toolOrientation;
    }

    public bool isEqual(Tool inTool)
    {
        return inTool.boxImage == boxImage &&
               inTool.circleImage == circleImage &&
               inTool.toolName == toolName;
    }
}
