using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatRay : Tool
{
    public override void action()
    {
        if (!gameObject.GetComponent<Animator>().GetBool("IsFiring"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("TriggerOn");
            gameObject.GetComponent<HeatRayBeam>().TurnBeamOn();
            print("Bzzzz!");
        }
    }

    public void stopFiring()
    {
        if (gameObject.GetComponent<Animator>().GetBool("IsFiring") && !gameObject.GetComponent<Animator>().GetBool("IsCoolingDown"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("TriggerOff");
            gameObject.GetComponent<HeatRayBeam>().TurnBeamOff();
        }
    }
}
