using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Tool
{
    public override void action()
    {
        if (!gameObject.GetComponent<Animator>().GetBool("IsUsing"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("UseTrigger");

            gameObject.GetComponent<HammerBreak>().ScheduleImpact();
        }
    }
}
