﻿using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour {

	PhotonView photonView;
	GameObject temp;

	void OnTriggerEnter(Collider other) {

		switch (GameObject.Find("Managers").GetComponent<SceneController>().counter) {

			case 0:
				//PhotonNetwork.Destroy (other.gameObject);
				temp = GameObject.Find ("Base");
				temp.GetComponent<PerformAction>().GotTransform = !temp.GetComponent<PerformAction>().GotTransform;
				photonView = temp.GetComponent<PhotonView> ();
				break;

			default:
				break;
		}


		if(GameObject.Find("Managers").GetComponent<SceneController>().counter%2==0) {
			photonView.RPC ("ModulePositioning", PhotonTargets.All);
	
		}
	}
}
