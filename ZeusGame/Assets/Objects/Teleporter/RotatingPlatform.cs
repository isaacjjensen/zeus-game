using UnityEngine;
using System.Collections;
//Edited by Jordan Hoffman to slow down rotation speed of the cylinders

public class RotatingPlatform : MonoBehaviour {
    /*void Start()
    {
    }*/
    void Update()
    {
        transform.Rotate(Vector3.up * 1.2f);
    }
    
    void OnCollisionStay(Collision collision)
    {
        
        //collision.transform.Rotate(Vector3.right * 10);
        
    }


}
