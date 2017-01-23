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
				pRenderer.mesh = GameObject.Find ("Base").GetComponent<MeshFilter> ().mesh;
				break;

            case 1:
                temp = GameObject.Find("Wheel 1");
                proposedPlacementTrigger.GetComponent<MeshCollider>().sharedMesh = temp.GetComponent<MeshFilter>().mesh;
                proposedPlacementTrigger.transform.rotation = temp.transform.rotation;
                proposedPlacementTrigger.transform.localScale = temp.transform.localScale;
                proposedPlacementTrigger.transform.position = new Vector3(1.035f, -0.393f, 5.327f);
                pRenderer.mesh = temp.GetComponent<MeshFilter>().mesh;
                break;

            default:
				break;

		}

	}

	[PunRPC]
	public void ModulePositioning() {
		switch (counter) {
			case 0:
				temp = GameObject.Find ("Base");
				temp.transform.position = new Vector3 (0f, -0.3f, 5f);
				temp.transform.parent = chair.transform;
				photonView = temp.GetComponent<PhotonView> ();
				break;
            case 1:
                temp = GameObject.Find("Wheel 1");
                temp.transform.position = proposedPlacementTrigger.transform.position;
                temp.transform.parent = chair.transform;
                break;
            default:
				break;
		}

        if(counter%2==0) {

            StartCoroutine(CounterTrigger(photonView));

        }


	}

    IEnumerator CounterTrigger(PhotonView photonView) {
		photonView.RPC ("CounterManager", PhotonTargets.All);
		yield return new WaitForSeconds (2f);
		photonView.RPC ("TriggerManager", PhotonTargets.All);
	}


	[PunRPC]
	public void CounterManager() {
		GameObject.Find ("Managers").GetComponent<SceneController> ().counter++;
        if(GameObject.Find("Managers").GetComponent<SceneController>().counter%2==0) {
            GameObject.Find("Managers").GetComponent<SceneController>().flag = true;
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
