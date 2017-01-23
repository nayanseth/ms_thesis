using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour {

	GameObject temp;
	PhotonView photonView;
	GameObject chair;

	void Awake() {
		chair = GameObject.Find ("Chair");
	}

	void OnTriggerEnter(Collider other) {
		switch (GameObject.Find("Managers").GetComponent<SceneController>().counter) {

			case 1:
				temp = GameObject.Find ("Wheel 1");
				break;
			case 3:
				temp = GameObject.Find ("Seat Holder");
				break;

			default:
			    break;
		}

		if (temp && temp.GetComponent<PerformAction> ().GotTransform) {

			temp.GetComponent<PerformAction> ().GotTransform = !temp.GetComponent<PerformAction> ().GotTransform;
			photonView = temp.GetComponent<PhotonView> ();

			if (GameObject.Find ("Managers").GetComponent<SceneController> ().counter % 2 != 0) {
				photonView.RPC ("ModulePositioning", PhotonTargets.All);
	
			}
		}

	}

}
