using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ControllerManager : MonoBehaviour {

    SteamVR_TrackedObject trackedObject;
	SteamVR_Controller.Device device;
	int counter;

    void Awake () {
        trackedObject = this.gameObject.GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		device = SteamVR_Controller.Input ((int)trackedObject.index);
		counter = GameObject.Find ("Managers").GetComponent<SceneController> ().counter;

		if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger) && counter%2!=0) {
			print ("Trigger");
		}
	}
}
