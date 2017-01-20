using UnityEngine;
using System.Collections;

public class RPCManager : MonoBehaviour {

    int counter;
    ParticleSystemRenderer pRenderer;
    GameObject chair;
    GameObject temp;

    // Use this for initialization
    void Start () {
        counter = GameObject.Find("Managers").GetComponent<SceneController>().counter;
        pRenderer = GameObject.Find("Proposed Placement Trigger").GetComponent<ParticleSystemRenderer>();
        chair = GameObject.Find("Chair");
    }

    [PunRPC]
    public void GameObjectNamer() {
		print ("GameObject Namer");
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
        print("Renderer Settings");
        switch (counter)
        {

            case 0:
                pRenderer.mesh = GameObject.Find("Base").GetComponent<MeshFilter>().mesh;
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
                temp.transform.position = new Vector3(0f, -1f, 5f);
                temp.transform.parent = chair.transform;
			    break;
		    default:
			    break;
		}
	}
}
