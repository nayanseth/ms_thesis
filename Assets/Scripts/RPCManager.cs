using UnityEngine;
using System.Collections;

public class RPCManager : MonoBehaviour {

	int counter;
	GameObject proposedPlacementTrigger;
	ParticleSystemRenderer pRenderer;
	GameObject chair;
	GameObject temp;
	PhotonView photonView;

	void Awake() {
		counter = GameObject.Find ("Managers").GetComponent<SceneController> ().counter;
		proposedPlacementTrigger = GameObject.Find ("Proposed Placement Trigger");
		pRenderer = proposedPlacementTrigger.GetComponent<ParticleSystemRenderer> ();
		chair = GameObject.Find ("Chair");
	}

    void FixedUpdate()
    {
        counter = GameObject.Find("Managers").GetComponent<SceneController>().counter;
    }

    [PunRPC]
	public void GameObjectNamer() {
        switch (counter) {
            case 1:
                temp = GameObject.Find("Wheel 1(Clone)");
                temp.name = "Wheel 1";
                break;
            case 3:
                temp = GameObject.Find("Seat Holder(Clone)");
                temp.name = "Seat Holder";
                break;
            case 5:
                temp = GameObject.Find("Right Hand Holder(Clone)");
                temp.name = "Right Hand Holder";
                break;
            case 7:
                temp = GameObject.Find("Right Handle(Clone)");
                temp.name = "Right Handle";
                break;
            case 9:
                temp = GameObject.Find("Back Seat Holder(Clone)");
                temp.name = "Back Seat Holder";
                break;
            default:
                break;

        }
	}

	[PunRPC]
	public void RendererSettings () {

		switch (counter) {

			case 0:
                temp = GameObject.Find("Base");
                //pRenderer.mesh = GameObject.Find ("Base").GetComponent<MeshFilter> ().mesh;
				break;

            case 1:
                temp = GameObject.Find("Wheel 1");
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
                temp = GameObject.Find("Left Hand Holder");
                proposedPlacementTrigger.transform.position = new Vector3(0f, 1.644f, 5f);
                break;
            case 5:
                temp = GameObject.Find("Right Hand Holder");
                proposedPlacementTrigger.transform.position = new Vector3(0f, 1.644f, 5f);
                break;
            case 6:
				temp = GameObject.Find ("Left Handle");
				proposedPlacementTrigger.transform.position = new Vector3 (0.019f, 2.035f, 5f);
				break;
            case 7:
                temp = GameObject.Find("Right Handle");
                proposedPlacementTrigger.transform.position = new Vector3(-2.88f, 2.04f, 5f);
                break;
            case 8:
                temp = GameObject.Find("Butt Rest");
                proposedPlacementTrigger.transform.position = new Vector3(0.23f, 1.903f, 4.821f);
                break;
            case 9:
                temp = GameObject.Find("Back Seat Holder");
                proposedPlacementTrigger.transform.position = new Vector3(0f, 1.664f, 5f);
                break;
            case 10:
                temp = GameObject.Find("Back Rest");
                proposedPlacementTrigger.transform.position = new Vector3(0f, 3.75f, 5.977f);
                break;
            default:
				break;

		}

        proposedPlacementTrigger.GetComponent<MeshCollider>().sharedMesh = temp.GetComponent<MeshFilter>().mesh;
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
                temp = GameObject.Find("Wheel 1");
                break;
            case 2:
                temp = GameObject.Find("Height Adjustment");
                break;
            case 3:
                temp = GameObject.Find("Seat Holder");
                break;
            case 4:
                temp = GameObject.Find("Left Hand Holder");
                break;
            case 5:
                temp = GameObject.Find("Right Hand Holder");
                break;
            case 6:
                temp = GameObject.Find("Left Handle");
                break;
            case 7:
                temp = GameObject.Find("Right Handle");
                break;
            case 8:
                temp = GameObject.Find("Butt Rest");
                break;
            case 9:
                temp = GameObject.Find("Back Seat Holder");
                break;
            case 10:
                temp = GameObject.Find("Back Rest");
                break;
            default:
				break;
		}

        temp.transform.position = proposedPlacementTrigger.transform.position;
        temp.transform.parent = chair.transform;
        photonView = temp.GetComponent<PhotonView>();

        if (counter%2==0) {

            photonView.RPC("CounterFlagManager", PhotonTargets.All);
            //StartCoroutine(CounterFlagTrigger(photonView));

        }


	}

    /*
    IEnumerator CounterFlagTrigger(PhotonView photonView) {
        
        
        photonView.RPC("CounterFlagManager", PhotonTargets.All);
        yield return new WaitForSeconds(2f);
        photonView.RPC("TriggerManager", PhotonTargets.All);
    }
    */


	[PunRPC]
	public void CounterFlagManager() {
		GameObject.Find ("Managers").GetComponent<SceneController> ().counter++;
        if(GameObject.Find("Managers").GetComponent<SceneController>().counter%2==0) {
            GameObject.Find("Managers").GetComponent<SceneController>().flag = true;
        } else {
			GameObject.Find ("Managers").GetComponent<SceneController> ().flag = false;
		}
    }

    [PunRPC]
	public void TriggerManager() {
		if (counter % 2 == 0) {
			proposedPlacementTrigger.AddComponent<TriggerController>();
		} else {
			Destroy(proposedPlacementTrigger.GetComponent<TriggerController> ());
		}
	}

}
