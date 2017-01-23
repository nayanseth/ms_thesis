using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour {

	PhotonView photonView;
	GameObject temp;

	void OnTriggerEnter(Collider other) {

		switch (GameObject.Find("Managers").GetComponent<SceneController>().counter) {

			case 0:
				temp = GameObject.Find ("Base");
				break;
            case 2:
                temp = GameObject.Find("Height Adjustment");
                break;


            default:
				break;
		}

        if(temp && temp.GetComponent<PerformAction>().GotTransform) { 
            temp.GetComponent<PerformAction>().GotTransform = !temp.GetComponent<PerformAction>().GotTransform;
            photonView = temp.GetComponent<PhotonView>();


            if (GameObject.Find("Managers").GetComponent<SceneController>().counter%2==0) {
			    photonView.RPC ("ModulePositioning", PhotonTargets.All);
	
		    }
        }
	}
}
