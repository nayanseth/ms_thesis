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
            case 4:
                temp = GameObject.Find("Left Hand Holder");
                break;
            case 6:
                temp = GameObject.Find("Left Handle");
                break;
            case 8:
                temp = GameObject.Find("Butt Rest");
                break;
            case 10:
                temp = GameObject.Find("Back Rest");
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
