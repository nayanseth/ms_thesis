using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class PerformAction : Singleton<PerformAction> {


	public bool GotTransform;
    GameObject chair;

	void Awake () {
		GotTransform = false;
        chair = GameObject.Find("Chair");
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

        if (GameObject.Find (sceneObject).transform.parent != chair.transform) {
		    switch (sceneObject) {

		        case "Base":
                case "Height Adjustment":
                case "Left Hand Holder":
                case "Left Handle":
                case "Butt Rest":
                case "Back Rest":
                    GotTransform = !GotTransform;
                    break;

                default:
			        print ("No such object found in the scene!");
			        break;
		
		    }
        }
	}
}
