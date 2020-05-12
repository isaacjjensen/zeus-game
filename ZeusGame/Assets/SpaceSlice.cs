using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSlice : MonoBehaviour
{
    private Camera toolCamera;
    private RaycastHit hitInfo;
    private float interactDistance = 3.25f;
    private float openDelay = 0.66f;
    private float closeDelay = 5.0f;
    private LayerMask portalLayerMask;

    public void ScheduleSlice()
    {
        portalLayerMask = LayerMask.GetMask("Portal");
        toolCamera = gameObject.transform.parent.gameObject.GetComponent<Camera>();
        StartCoroutine(OpenAfterDelay());
    }

    IEnumerator OpenAfterDelay()
    {
        yield return new WaitForSeconds(openDelay);

        GameObject portalObject;
        if (Physics.Raycast(toolCamera.transform.position, toolCamera.transform.forward, out hitInfo, interactDistance, portalLayerMask))
        {
            portalObject = hitInfo.collider.gameObject;
            portalObject.GetComponent<Teleport>().OpenPortal();
            portalObject.GetComponent<BoxCollider>().isTrigger = true;

            yield return new WaitForSeconds(closeDelay);
            portalObject.GetComponent<Teleport>().ClosePortal();
            portalObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
