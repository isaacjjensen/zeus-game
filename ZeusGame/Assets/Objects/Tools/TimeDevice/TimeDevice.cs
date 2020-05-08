using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDevice : Tool
{
    public override void action()
    {
        if (!gameObject.GetComponent<Animator>().GetBool("IsUsing"))
        {
            print("Woop woop woop!");
            gameObject.GetComponent<Animator>().SetTrigger("UseTrigger");
        }
    }
}
