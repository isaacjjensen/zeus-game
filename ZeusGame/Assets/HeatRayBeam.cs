using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatRayBeam : MonoBehaviour
{
    private bool isFiring = false;
    private Vector3[] beamPositions = new Vector3[2];
    public Vector3 beamOffset;
    private Vector3 gunPosition;
    private float temp = 0;
    private RaycastHit hitInfo;

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            gameObject.GetComponent<LineRenderer>().enabled = true;
            gunPosition = gameObject.transform.Find("Sphere").transform.position;
            beamPositions[0] = gunPosition
                + new Vector3(
                              beamOffset.x * gameObject.transform.forward.x 
                                + beamOffset.y * gameObject.transform.right.x
                                + beamOffset.z * gameObject.transform.up.x,
                              beamOffset.x * gameObject.transform.forward.y
                                + beamOffset.y * gameObject.transform.right.y
                                + beamOffset.z * gameObject.transform.up.y,
                              beamOffset.x * gameObject.transform.forward.z
                                + beamOffset.y * gameObject.transform.right.z
                                + beamOffset.z * gameObject.transform.up.z
                );
            Transform cameraTransform = GameObject.Find("MainCamera").transform;
            Physics.Raycast(cameraTransform.position, cameraTransform.right, out hitInfo);
            beamPositions[1] = hitInfo.point;
            gameObject.transform.Find("Particle System Smoke").gameObject.transform.position = beamPositions[1];
            gameObject.GetComponent<LineRenderer>().SetPositions(beamPositions);
        } else if (gameObject.GetComponent<LineRenderer>().enabled)
        {
            gameObject.GetComponent<LineRenderer>().enabled = false;
        }
    }

    public void TurnBeamOn()
    {
        isFiring = true;
        gameObject.transform.Find("Particle System Sparks").GetComponent<ParticleSystem>().Play();
        gameObject.transform.Find("Particle System Smoke").GetComponent<ParticleSystem>().Play();
    }

    public void TurnBeamOff()
    {
        isFiring = false;
        gameObject.transform.Find("Particle System Sparks").GetComponent<ParticleSystem>().Stop();
        gameObject.transform.Find("Particle System Smoke").GetComponent<ParticleSystem>().Stop();
    }
}
