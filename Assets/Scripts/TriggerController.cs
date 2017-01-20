using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour {

	PhotonView photonView;
	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other) {

		switch (other.gameObject.name) {

			case "Base":
				//PhotonNetwork.Destroy (other.gameObject);
				photonView = GameObject.Find ("Base").GetComponent<PhotonView> ();
				break;

			default:
				break;
		}

		photonView.RPC ("ModulePositioning", PhotonTargets.All);
	}
}
