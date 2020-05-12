using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBreak : MonoBehaviour
{
    private Camera toolCamera;
    private RaycastHit hitInfo;
    private float interactDistance = 3.0f;
    private float delay = 0.45f;
    private LayerMask breakableLayerMask;

    public void ScheduleImpact()
    {
        breakableLayerMask = LayerMask.GetMask("Breakables");
        toolCamera = gameObject.transform.parent.gameObject.GetComponent<Camera>();
        StartCoroutine(BreakCheckAfterDelay());
    }

    IEnumerator BreakCheckAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        if (Physics.Raycast(toolCamera.transform.position, toolCamera.transform.forward, out hitInfo, interactDistance, breakableLayerMask))
        {
            hitInfo.collider.gameObject.GetComponent<Breakable>().Break();
        }
    }
}
