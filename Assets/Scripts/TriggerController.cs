using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {

		switch (other.gameObject.name) {

		    case "Base":
			    //PhotonNetwork.Destroy (other.gameObject);
			    break;

		    default:
			    break;
		}
	}
}
