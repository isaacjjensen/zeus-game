using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avalanche : MonoBehaviour
{
    public GameObject[] rockObjects = new GameObject[12];

    public void MakeRigid()
    {
        foreach (GameObject rock in rockObjects)
        {
            rock.AddComponent<Rigidbody>();
            rock.GetComponent<Rigidbody>().mass = 10000;
        }
    }
}
