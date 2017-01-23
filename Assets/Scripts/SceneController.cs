using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class SceneController : Singleton<SceneController> {

	public int counter;
	public bool flag;
	//ParticleSystemManager manager;
	PhotonView photonView;
	//private bool masterFlag;


	// Use this for initialization
	void Start () {
		//manager = GameObject.Find ("Managers").GetComponent <ParticleSystemManager> ();
		counter = 0;
		flag = true;
		 
		//masterFlag = true;
	}

	// Update is called once per frame
	void Update () {

		/*
		if (PhotonNetwork.inRoom && masterFlag) {
			PhotonNetwork.SetMasterClient (PhotonNetwork.masterClient);
			masterFlag = false;
		}
		*/
		//GameObject.Find("Back Rest(Clone)").GetComponent<PhotonView> ().TransferOwnership(PhotonNetwork.player.ID);

		if (flag) {
			SceneObjective (counter);
		}


	}

	void SceneObjective(int counter) {

		if (PhotonNetwork.inRoom) {
			switch (counter) {

				case 0:
                    flag = false;
                    Quaternion rotation = Quaternion.Euler (-89.96101f, 0.0f, 0.0f);
					GameObject chairBase = PhotonNetwork.Instantiate ("Prefabs/Base", new Vector3 (5f, -0.3f, 5f), rotation, 0) as GameObject;
					chairBase.name = "Base";
					chairBase.transform.localScale = new Vector3 (45.0f, 45.0f, 13.6013f);
					photonView = chairBase.GetComponent<PhotonView> ();
					break;
				
				default:
					print("No such case");
	                break;

			}
            //photonView.RPC("GameObjectNamer", PhotonTargets.Others);
            //photonView.RPC("RendererSettings", PhotonTargets.All);
            if (GameObject.Find("Managers").GetComponent<SceneController>().counter % 2 == 0) { 
                StartCoroutine(RPCFunctions(photonView));

            }
            
		}
	}

	/*
	 * Using Awake function to avoid Co-Routines for NullReferenceException
	 * 
	 */
	IEnumerator RPCFunctions(PhotonView photonView) {
		photonView.RPC("GameObjectNamer", PhotonTargets.Others);
		yield return new WaitForSeconds (2f);
		photonView.RPC("RendererSettings", PhotonTargets.All);
	}

}
