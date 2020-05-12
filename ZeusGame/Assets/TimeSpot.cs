using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpot : MonoBehaviour
{
    public GameObject objectToAnimate;
    public bool isOneTimeTrigger;

    private bool isTriggered = false;
    private bool playerIsInside = false;
    private GameObject player;
    private GameObject timeDevice;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        timeDevice = player.transform.Find("MainCamera").transform.Find("ToolCamera").transform.Find("timedevice(Clone)").gameObject;
        if (timeDevice != null)
        {
            timeDevice.GetComponent<TimeDevice>().SetLastTimeSpot(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Collider>().bounds.Contains(player.transform.position))
        {
            playerIsInside = true;
        } else
        {
            playerIsInside = true;
        }

    }

    public bool TriggerIfInBounds()
    {
        if (isOneTimeTrigger)
        {
            if (isTriggered)
            {
                return false;
            }
        }
        if (playerIsInside)
        {
            objectToAnimate.GetComponent<Animator>().SetTrigger("TimeReverse");
            isTriggered = true;
            if (isOneTimeTrigger)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            return true;
        }
        return false;
    }
}
