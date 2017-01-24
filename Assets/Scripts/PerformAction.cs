using UnityEngine;
using System.Collections;

public class PerformAction : MonoBehaviour {


	public bool GotTransform;
	GameObject chair;

	void Awake () {
		GotTransform = false;
		chair = GameObject.Find ("Chair");
	}

	// Update is called once per frame
	void Update () {
		if (GotTransform)
		{
			transform.position = Vector3.Lerp(transform.position, ProposeTransformPosition(), 0.2f);
		}
	}

	Vector3 ProposeTransformPosition()
	{

		Vector3 proposedTransformPosition = GameObject.Find("Controller (right)").transform.position + GameObject.Find("Controller (right)").transform.forward * 5;

		return proposedTransformPosition;
	}

	void ObjectAction(string sceneObject) {

		if (GameObject.Find (sceneObject).transform.parent != chair.transform) {

			switch (sceneObject) {

				case "Wheel 1":
				case "Seat Holder":
				case "Right Hand Holder":
				case "Right Handle":
				case "Back Seat Holder":
					GotTransform = !GotTransform;
					break;

				default:
					print ("No such object found in the scene!");
					break;

			}
		}
	}
}
