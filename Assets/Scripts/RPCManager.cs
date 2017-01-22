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

	[PunRPC]
	public void GameObjectNamer() {
	}

	[PunRPC]
	public void RendererSettings () {

		switch (counter) {

			case 0:
				pRenderer.mesh = GameObject.Find ("Base").GetComponent<MeshFilter> ().mesh;
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
				photonView = GameObject.Find ("Base").GetComponent<PhotonView> ();
				photonView.RPC ("CounterManager", PhotonTargets.All);
				break;
			default:
				break;
		}


	}

	[PunRPC]
	public void CounterManager() {
		GameObject.Find ("Managers").GetComponent<SceneController> ().counter++;
	}

}
