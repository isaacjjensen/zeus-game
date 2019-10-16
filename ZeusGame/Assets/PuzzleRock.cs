//Created by Jordan Hoffman to reset the position of the Puzzle Rocks in Level 1.
using UnityEngine;
using System.Collections;

public class PuzzleRock : AbstractResetable {
	private Vector3 origLoc;
	// Use this for initialization
	void Start ()
	{
		origLoc = this.transform.position;
	}
	
	public override void Reset()
	{
		this.transform.position = origLoc;
	}
}

