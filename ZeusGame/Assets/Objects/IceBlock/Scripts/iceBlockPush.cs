using UnityEngine;
using System.Collections;

public class iceBlockPush : MonoBehaviour {
		public float pushPower = 10.0F;
		void OnControllerColliderHit(ControllerColliderHit hit) {
			Rigidbody body = hit.collider.attachedRigidbody;
			if (body == null || body.isKinematic)
				return;
			
			if (hit.moveDirection.y < -0.3F)
				return;
			
			Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
			if ((hit.moveLength / Time.deltaTime) >= 3)
				body.velocity = pushDir * pushPower * pushPower * pushPower;
			else if ((hit.moveLength / Time.deltaTime) <= 3 && (hit.moveLength / Time.deltaTime) >= 2)
				body.velocity = pushDir * pushPower;
			else if ((hit.moveLength / Time.deltaTime) < 2)
				body.velocity = pushDir * 0;
	}
}
