using UnityEngine;
using System.Collections;
//Edited by Jordan Hoffman to slow down rotation speed of the cylinders

public class RotatingPlatform : MonoBehaviour {
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100f);
    }

}
