//Michael Schilling
//CSci 448
using UnityEngine;
using System.Collections;

public abstract class Interactable : MonoBehaviour {
    public Color glowColor;
    public Material[] materials;

	public abstract void Interact(Transform interactor);

    public void OnHover()
    {
        
    }

    public void OnHoverExit()
    {
        
    }
}
