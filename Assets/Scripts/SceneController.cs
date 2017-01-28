using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;
using UnityEngine.UI;

public class SceneController : Singleton<SceneController>
{

    public int counter;
    public bool flag;
    Quaternion rotation;
    GameObject temp;
    PhotonView photonView;
    //private bool masterFlag;


    // Use this for initialization
    void Start()
    {
        //manager = GameObject.Find ("Managers").GetComponent <ParticleSystemManager> ();
        counter = 0;
        flag = true;

        //masterFlag = true;
    }

    // Update is called once per frame
    void Update()
    {

        /*
		if (PhotonNetwork.inRoom && masterFlag) {
			PhotonNetwork.SetMasterClient (PhotonNetwork.masterClient);
			masterFlag = false;
		}
		*/
        //GameObject.Find("Back Rest(Clone)").GetComponent<PhotonView> ().TransferOwnership(PhotonNetwork.player.ID);
        if (counter % 2 == 0) {
			GameObject.Find ("Current Controller").GetComponent<Text> ().text = "Your Turn";
		} else {
			GameObject.Find ("Current Controller").GetComponent<Text>().text = "Vive's Turn";
		}

        if (counter == 11) {
			Destroy (GameObject.Find ("Proposed Placement Trigger"));
		}

        if (flag && counter<11)
        {
            SceneObjective(counter);
        }


    }

    void SceneObjective(int counter)
    {

        if (PhotonNetwork.inRoom)
        {
            switch (counter)
            {

                case 0:
                    flag = false;
                    rotation = Quaternion.Euler(-89.96101f, 0.0f, 0.0f);
                    temp = PhotonNetwork.Instantiate("Prefabs/Base", new Vector3(5f, -0.3f, 5f), rotation, 0) as GameObject;
                    temp.name = "Base";
                    temp.transform.localScale = new Vector3(45.0f, 45.0f, 13.6013f);
                    break;

                case 2:
                    flag = false;
                    rotation = Quaternion.Euler(-89.96101f, 0.0f, 0.0f);
                    temp = PhotonNetwork.Instantiate("Prefabs/Height Adjustment", new Vector3(5f, -0.418f, 4.997f), rotation, 0) as GameObject;
                    temp.name = "Height Adjustment";
                    temp.transform.localScale = new Vector3(61.17155f, 61.17165f, 18.48919f);
                    break;

                case 4:
                    flag = false;
                    rotation = Quaternion.Euler(-89.96101f, 90.0f, 0.0f);
                    temp = PhotonNetwork.Instantiate("Prefabs/Left Hand Holder", new Vector3(5f, 1.644f, 5f), rotation, 0) as GameObject;
                    temp.name = "Left Hand Holder";
                    temp.transform.localScale = new Vector3(50.66978f, 53.12695f, 4.560347f);
                    break;
                case 6:
                    flag = false;
                    rotation = Quaternion.Euler(-89.96101f, 90.0f, 0.0f);
                    temp = PhotonNetwork.Instantiate("Prefabs/Left Handle", new Vector3(5.019f, 2.035f, 5f), rotation, 0) as GameObject;
                    temp.name = "Left Handle";
                    temp.transform.localScale = new Vector3(100f, 100f, 18.84852f);
                    break;
                case 8:
                    flag = false;
                    rotation = Quaternion.Euler(-89.96101f, 90.0f, 0.0f);
                    temp = PhotonNetwork.Instantiate("Prefabs/Butt Rest", new Vector3(5.023f, 1.903f, 4.821f), rotation, 0) as GameObject;
                    temp.name = "Butt Rest";
                    temp.transform.localScale = new Vector3(100f, 100f, 18.84852f);
                    break;
                case 10:
                    flag = false;
                    rotation = Quaternion.Euler(0f, 180f, -90.00001f);
                    temp = PhotonNetwork.Instantiate("Prefabs/Back Rest", new Vector3(5f, 3.75f, 5.977f), rotation, 0) as GameObject;
                    temp.name = "Back Rest";
                    temp.transform.localScale = new Vector3(100f, 100f, 18.84852f);
                    break;
                default:
                    print("No such case");
                    break;

            }
            photonView = temp.GetComponent<PhotonView>();
            //photonView.RPC("GameObjectNamer", PhotonTargets.Others);
            //photonView.RPC("RendererSettings", PhotonTargets.All);
            if (GameObject.Find("Managers").GetComponent<SceneController>().counter % 2 == 0)
            {
                StartCoroutine(RPCFunctions(photonView));

            }

        }
    }

    /*
	 * Using Awake function to avoid Co-Routines for NullReferenceException
	 * 
	 */
    IEnumerator RPCFunctions(PhotonView photonView)
    {
        photonView.RPC("GameObjectNamer", PhotonTargets.Others);
        yield return new WaitForSeconds(2f);
        photonView.RPC("RendererSettings", PhotonTargets.All);
    }

}