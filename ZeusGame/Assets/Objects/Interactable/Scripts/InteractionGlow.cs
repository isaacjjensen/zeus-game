using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGlow : MonoBehaviour {
    public Color InitColor;
    public Color ChangeColor;
    public Material[] material;
    private Renderer rend;

    private void Start() {
        rend = GetComponentInChildren<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }
    void OnMouseOver() {
        rend.sharedMaterial = material[1];
    }
    void OnMouseExit() {
        rend.sharedMaterial = material[0];
    }
}
