using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayTrailEmission : MonoBehaviour
{
    public void DelayedTrailEmission(Animator animator, bool emit, float delay)
    {
        StartCoroutine(SetTrailEmissionAfterDelay(animator, emit, delay));
    }

    IEnumerator SetTrailEmissionAfterDelay(Animator animator, bool emit, float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.gameObject.transform.Find("Cube.001").transform.Find("Trail").GetComponent<TrailRenderer>().emitting = emit;
    }
}
