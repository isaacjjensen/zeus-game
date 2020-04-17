using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float delayTime;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().enabled = false;
        Invoke("StartAnimation", delayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving && !GetComponent<Animator>().enabled)
        {
            GetComponent<Animator>().enabled = true;
        } else if (!isMoving && GetComponent<Animator>().enabled)
        {
            GetComponent<Animator>().enabled = false;
        }
    }

    public void StartAnimation()
    {
        isMoving = true;
    }

    public void StopAnimation()
    {
        isMoving = false;
    }
}
