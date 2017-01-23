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
