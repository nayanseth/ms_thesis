using UnityEngine;
using System.Collections;

public class RPCManager : MonoBehaviour {

	int counter;
	GameObject proposedPlacementTrigger;
	ParticleSystemRenderer pRenderer;
	GameObject chair;
	GameObject temp;

	void Start() {
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
				temp.transform.position = new Vector3 (0f, -1f, 5f);
				temp.transform.parent = chair.transform;
				break;
			default:
				break;
		}
	}

}
