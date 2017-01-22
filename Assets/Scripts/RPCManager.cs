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
                pRenderer.mesh = GameObject.Find("Base").GetComponent<MeshFilter>().mesh;
                break;
			case 1:
				temp = GameObject.Find ("Wheel 1");
				proposedPlacementTrigger.GetComponent<MeshCollider> ().sharedMesh = temp.GetComponent<MeshFilter>().mesh;
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
                temp.transform.position = new Vector3(0f, -0.3f, 5f);
                temp.transform.parent = chair.transform;
                break;
			case 1:
				temp = GameObject.Find ("Wheel 1");
				temp.transform.position = proposedPlacementTrigger.transform.position;
				temp.transform.parent = chair.transform;
				photonView = temp.GetComponent<PhotonView> ();
				photonView.RPC ("CounterManager", PhotonTargets.All);
				break;
		    default:
			    break;
		}

    }

    [PunRPC]
	public void CounterManager() {
		GameObject.Find ("Managers").GetComponent<SceneController> ().counter++;
		if (GameObject.Find ("Managers").GetComponent<SceneController> ().counter % 2 != 0) {
			GameObject.Find ("Managers").GetComponent<SceneController> ().flag = true;
		} else {
			GameObject.Find ("Managers").GetComponent<SceneController> ().flag = false;
		}
	}
}
