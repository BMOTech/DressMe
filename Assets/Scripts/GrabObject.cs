using UnityEngine;
using System.Collections;

public class GrabObject : MonoBehaviour {
	Transform chicken;
	Vector3 offSet;    
	void Update() {
		Ray ray = camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));        // Gets the mouse position in the form of a ray.
		if (Input.GetMouseButtonDown(0)) {      // If we click the mouse...
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {        // Then see if an object is beneath us using raycasting.
				chicken = hit.transform;        // If we hit an object then hold on to the object.
				offSet = chicken.position-ray.origin;       // This is so when you click on an object its center does not align with mouse position.
				if (chicken.rigidbody) {
					chicken.rigidbody.isKinematic = true;
				}
			}
		}
		else if (Input.GetMouseButtonUp(0)) {
			if (chicken.rigidbody) {
				chicken.rigidbody.isKinematic = false;
			}
			chicken = null;     // Let go of the object.
		}
		if (chicken) {
			chicken.transform.position = new Vector3(ray.origin.x+offSet.x, chicken.position.y, ray.origin.z+offSet.z);     // Only move the object on a 2D plane.
		}
	}
}
