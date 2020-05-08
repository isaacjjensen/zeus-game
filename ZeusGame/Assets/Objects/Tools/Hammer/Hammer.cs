using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Tool
{
    public override void action()
    {
        gameObject.GetComponent<Animator>().SetTrigger("UseTrigger");
    }
}
