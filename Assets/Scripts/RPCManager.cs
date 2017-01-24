using UnityEngine;
using System.Collections;

public class RPCManager : MonoBehaviour {

    int counter;
	GameObject proposedPlacementTrigger;
    ParticleSystemRenderer pRenderer;
    GameObject chair;
    GameObject temp;
    PhotonView photonView;

    // Use this for initialization
    void Awake () {
        counter = GameObject.Find("Managers").GetComponent<SceneController>().counter;
		proposedPlacementTrigger = GameObject.Find ("Proposed Placement Trigger");
		pRenderer = proposedPlacementTrigger.GetComponent<ParticleSystemRenderer>();
        chair = GameObject.Find("Chair");
    }

	void FixedUpdate() {
		counter = GameObject.Find("Managers").GetComponent<SceneController>().counter;
	}

    [PunRPC]
    public void GameObjectNamer() {
		//print ("GameObject Namer");
		switch (counter) {
            case 0:
                temp = GameObject.Find("Base(Clone)");
                temp.name = "Base";
                break;
			case 2:
				temp = GameObject.Find("Height Adjustment(Clone)");
				temp.name = "Height Adjustment";
				break;
			case 4:
				temp = GameObject.Find ("Left Hand Holder(Clone)");
				temp.name = "Left Hand Holder";
				break;
			case 6:
				temp = GameObject.Find ("Left Handle(Clone)");
				temp.name = "Left Handle";
				break;
			case 8:
				temp = GameObject.Find ("Butt Rest(Clone)");
				temp.name = "Butt Rest";
				break;
			case 10:
				temp = GameObject.Find ("Back Rest(Clone)");
				temp.name = "Back Rest";
				break;
			default:
                break;

        }
    }

    [PunRPC]
    public void RendererSettings()
    {
        //print("Renderer Settings");
        switch (counter)
        {

			case 0:
				temp = GameObject.Find ("Base");
				//pRenderer.mesh = GameObject.Find("Base").GetComponent<MeshFilter>().mesh;
                break;
			case 1:
				temp = GameObject.Find ("Wheel 1");
				proposedPlacementTrigger.transform.position = new Vector3(1.035f, -0.393f, 5.327f);
				break;
			case 2:
				temp = GameObject.Find("Height Adjustment");
				proposedPlacementTrigger.transform.position = new Vector3(7.8688e-07f, -0.418f, 4.997f);
				break;

			case 3:
				temp = GameObject.Find("Seat Holder");
				proposedPlacementTrigger.transform.position = new Vector3(0f, 1.644f, 5f);
				break;
			case 4:
				temp = GameObject.Find ("Left Hand Holder");
				proposedPlacementTrigger.transform.position = new Vector3 (0f, 1.644f, 5f);
				break;
			case 5:
				temp = GameObject.Find ("Right Hand Holder");
				proposedPlacementTrigger.transform.position = new Vector3 (0f, 1.644f, 5f);
				break;
			case 6:
				temp = GameObject.Find ("Left Handle");
				proposedPlacementTrigger.transform.position = new Vector3 (0.019f, 2.035f, 5f);
				break;
			case 7:
				temp = GameObject.Find ("Right Handle");
				proposedPlacementTrigger.transform.position = new Vector3 (-2.88f, 2.04f, 5f);
				break;
			case 8:
				temp = GameObject.Find ("Butt Rest");
				proposedPlacementTrigger.transform.position = new Vector3 (0.23f, 1.903f, 4.821f);
				break;
			case 9:
				temp = GameObject.Find ("Back Seat Holder");
				proposedPlacementTrigger.transform.position = new Vector3 (0f, 1.664f, 5f);
				break;
			case 10:
				temp = GameObject.Find ("Back Rest");
				proposedPlacementTrigger.transform.position = new Vector3 (0f, 3.75f, 5.977f);
				break;
			default:
                break;
        }

		proposedPlacementTrigger.GetComponent<MeshCollider> ().sharedMesh = temp.GetComponent<MeshFilter>().mesh;
		proposedPlacementTrigger.transform.rotation = temp.transform.rotation;
		proposedPlacementTrigger.transform.localScale = temp.transform.localScale;
		pRenderer.mesh = temp.GetComponent<MeshFilter>().mesh;
    }
    
    [PunRPC]
	public void ModulePositioning() {
		switch (counter) {
		    case 0:
			    temp = GameObject.Find ("Base");
                break;
			case 1:
				
				/* All other wheels */
				Quaternion rotation = Quaternion.Euler (-89.96101f, 77.1f, 0.0f);
				GameObject wheel = PhotonNetwork.Instantiate ("Prefabs/Wheel 2", new Vector3 (0.663f, -0.395f, 4.078f), rotation, 0) as GameObject;
				wheel.transform.localScale = new Vector3 (2.088205f, 2.088205f, 3.972193f);
				wheel.transform.parent = chair.transform;
				rotation = Quaternion.Euler (-89.96101f, 0.0f, 0.0f);
				wheel = PhotonNetwork.Instantiate ("Prefabs/Wheel 3", new Vector3 (-1.077f, -0.386f, 5.35f), rotation, 0) as GameObject;
				wheel.transform.parent = chair.transform;
				wheel.transform.localScale = new Vector3 (2.088205f, 2.088205f, 3.972193f);
				rotation = Quaternion.Euler (-89.96101f, 0.0f, 0.0f);
				wheel = PhotonNetwork.Instantiate ("Prefabs/Wheel 4", new Vector3 (0.009f, -0.381f, 6.163f), rotation, 0) as GameObject;
				wheel.transform.parent = chair.transform;
				wheel.transform.localScale = new Vector3 (2.088205f, 2.088205f, 3.972193f);
				rotation = Quaternion.Euler (-89.96101f, 0.0f, 0.0f);
				wheel = PhotonNetwork.Instantiate ("Prefabs/Wheel 5", new Vector3 (-0.634f, -0.393f, 4.12f), rotation, 0) as GameObject;
				wheel.transform.parent = chair.transform;
				wheel.transform.localScale = new Vector3 (2.088205f, 2.088205f, 3.972193f);
				/* All other wheels */
				temp = GameObject.Find ("Wheel 1");
				break;
			case 2:
				temp = GameObject.Find ("Height Adjustment");
				break;
			case 3:
				temp = GameObject.Find ("Seat Holder");
				break;
			case 4:
				temp = GameObject.Find ("Left Hand Holder");
				break;
			case 5:
				temp = GameObject.Find ("Right Hand Holder");
				break;
			case 6:
				temp = GameObject.Find ("Left Handle");
				break;
			case 7:
				temp = GameObject.Find ("Right Handle");
				break;
			case 8:
				temp = GameObject.Find ("Butt Rest");
				break;
			case 9:
				temp = GameObject.Find ("Back Seat Holder");
				break;
			case 10:
				temp = GameObject.Find ("Back Rest");
				break;
			default:
			    break;
		}
		temp.transform.position = proposedPlacementTrigger.transform.position;
		temp.transform.parent = chair.transform;
		photonView = temp.GetComponent<PhotonView> ();
		if (counter % 2 != 0) {
			photonView.RPC ("CounterFlagManager", PhotonTargets.All);
			//StartCoroutine (CounterFlagTrigger(photonView));
		}

    }

	/*
	IEnumerator CounterFlagTrigger(PhotonView photonView) {

		photonView.RPC ("CounterFlagManager", PhotonTargets.All);
		yield return new WaitForSeconds (0f);
		photonView.RPC ("TriggerManager", PhotonTargets.All);
	}
	*/

    [PunRPC]
	public void CounterFlagManager() {
		GameObject.Find ("Managers").GetComponent<SceneController> ().counter++;
		if (GameObject.Find ("Managers").GetComponent<SceneController> ().counter % 2 != 0) {
			GameObject.Find ("Managers").GetComponent<SceneController> ().flag = true;
		} else {
			GameObject.Find ("Managers").GetComponent<SceneController> ().flag = false;
		}
	}

	[PunRPC]
	public void TriggerManager() {
		print ("Trigger Manager");
		if (counter % 2 != 0) {
			proposedPlacementTrigger.AddComponent<TriggerController> ();
		} else {
			Destroy(proposedPlacementTrigger.GetComponent<TriggerController> ());
		}
	}
}
