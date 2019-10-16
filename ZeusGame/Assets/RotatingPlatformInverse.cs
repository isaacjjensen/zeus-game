//Written by Jordan Hoffman
//Made to make two of the three cylinders rotate the opposite direction
using UnityEngine;
using System.Collections;

public class RotatingPlatformInverse : MonoBehaviour {

	void Update()
	{
		transform.Rotate(Vector3.down * 1.2f);
	}	
}

