using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceBeginPushed : MonoBehaviour
{
    public AudioClip icePushLong;
    public AudioClip icePushShort;
    public AudioSource icePush;
    private Rigidbody block;

    void Start()
    {
        AudioSource[] iceSounds = GetComponents<AudioSource>();
        block = GetComponent<Rigidbody>();
        icePush = iceSounds[0];
        icePushLong = iceSounds[0].clip;
        icePushShort = iceSounds[1].clip;
    }

    void FixedUpdate()
    {
        if (block.velocity.magnitude >= 0.2)
        {
            icePush.PlayOneShot(icePushLong);
        }
    }

    private void LateUpdate()
    {
        if (block.velocity.magnitude <= 0.2)
        {
            icePush.PlayOneShot(icePushShort);
        }
    }
}
