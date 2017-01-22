using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour {

	PhotonView photonView;
	GameObject temp;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other) {

		switch (other.gameObject.name) {

			case "Base":
				//PhotonNetwork.Destroy (other.gameObject);
				temp = GameObject.Find ("Base");
				temp.GetComponent<PerformAction>().GotTransform = !temp.GetComponent<PerformAction>().GotTransform;
				photonView = temp.GetComponent<PhotonView> ();
				break;

			default:
				break;
		}


		photonView.RPC ("ModulePositioning", PhotonTargets.All);
	}
}
