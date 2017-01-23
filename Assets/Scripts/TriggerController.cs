using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour {

	GameObject temp;
	PhotonView photonView;

	void OnTriggerEnter(Collider other) {
		switch (GameObject.Find("Managers").GetComponent<SceneController>().counter) {

			case 1:
				print ("trigger called");
				temp = GameObject.Find ("Wheel 1");
				temp.GetComponent<PerformAction> ().GotTransform = !temp.GetComponent<PerformAction> ().GotTransform;
				photonView = temp.GetComponent<PhotonView> ();
				break;
		    default:
			    break;
		}
		if(GameObject.Find("Managers").GetComponent<SceneController>().counter%2!=0) {
			photonView.RPC ("ModulePositioning", PhotonTargets.All);
	
		}

	}

}
