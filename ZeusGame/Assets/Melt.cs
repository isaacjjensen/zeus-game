using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melt : MonoBehaviour
{
    private float meltRate = 0.0025f;

    public void Melting()
    {
        gameObject.transform.localScale -= new Vector3(meltRate, 0, 0);
    }
}
