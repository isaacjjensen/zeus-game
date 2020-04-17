using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortPoint : MonoBehaviour
{
    public string LevelToPortTo;
    public Vector3 location;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Application.LoadLevel(LevelToPortTo);
        }
    }
}
