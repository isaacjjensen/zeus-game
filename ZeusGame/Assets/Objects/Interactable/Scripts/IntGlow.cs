using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntGlow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Running with Glow script.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        Debug.Log("*GLOW*");
    }

    private void OnMouseExit()
    {
        Debug.Log("Glow end.");
    }
}
