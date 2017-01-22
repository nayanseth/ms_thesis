using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ControllerManager : MonoBehaviour {

    SteamVR_TrackedObject trackedObject;
	SteamVR_Controller.Device device;
	int counter;
	GameObject temp;
	//public bool triggerFlag;

    void Awake () {
        trackedObject = this.gameObject.GetComponent<SteamVR_TrackedObject>();
		//triggerFlag = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		device = SteamVR_Controller.Input ((int)trackedObject.index);
		counter = GameObject.Find ("Managers").GetComponent<SceneController> ().counter;


		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger) && counter%2!=0) {
			temp = this.gameObject.GetComponentInChildren<Laser> ().target;
			temp.SendMessage ("ObjectAction", temp.name);
		}
	}
}
