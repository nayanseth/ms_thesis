using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class PerformAction : Singleton<PerformAction> {


	public bool GotTransform { get; private set; }

	void Start () {
		GotTransform = false;
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
		// Put the model 2m in front of the user.
		Vector3 proposedTransformPosition = Camera.main.transform.position + Camera.main.transform.forward * 5;

		return proposedTransformPosition;
	}

	void ObjectAction(string sceneObject) {

		switch (sceneObject) {

		case "Base":
			// Note that we have a transform.
			GotTransform = !GotTransform;
			break;
		
		default:
			print ("No such object found in the scene!");
			break;
		
		}
	}
}
