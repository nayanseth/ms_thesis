using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour {

	GameObject temp;
	PhotonView photonView;

	void OnTriggerEnter(Collider other) {
		Debug.Log ("OnTriggerEnter");
		switch (GameObject.Find("Managers").GetComponent<SceneController>().counter) {

			case 1:
				temp = GameObject.Find ("Wheel 1");
				print (temp);
				temp.GetComponent<PerformAction> ().GotTransform = !temp.GetComponent<PerformAction> ().GotTransform;
				//temp.SendMessage ("ObjectAction", temp.name);
				photonView = temp.GetComponent<PhotonView> ();
				break;
		    default:
			    break;
		}
		Debug.Log ("OnTriggerEnter");
		photonView.RPC ("ModulePositioning", PhotonTargets.All);
	}
}
