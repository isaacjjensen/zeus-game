using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeDevice : Tool
{
    public PostProcessProfile defaultProfile;
    public PostProcessProfile timeProfile;

    private TimeSpot lastTimeSpot;

    private float defaultSpeed;

    public override void action()
    {
        if (!gameObject.GetComponent<Animator>().GetBool("IsUsing"))
        {
            if (lastTimeSpot != null && lastTimeSpot.TriggerIfInBounds())
            {
                gameObject.GetComponent<Animator>().SetTrigger("UseTrigger");
            }
        }
    }

    public void TimeWarp()
    {
        GameObject.Find("Global Post Processing").GetComponent<PostProcessVolume>().profile = timeProfile;
        defaultSpeed = GameObject.Find("Player").GetComponent<CharacterMotor>().sliding.slidingSpeed;
        GameObject.Find("Player").GetComponent<CharacterMotor>().sliding.slidingSpeed = 0;
    }

    // Bad name xD
    public void UnTimeWarp()
    {
        GameObject.Find("Global Post Processing").GetComponent<PostProcessVolume>().profile = defaultProfile;
        GameObject.Find("Player").GetComponent<CharacterMotor>().sliding.slidingSpeed = defaultSpeed;
    }

    public void SetLastTimeSpot(TimeSpot spot)
    {
        lastTimeSpot = spot;
    }
}
