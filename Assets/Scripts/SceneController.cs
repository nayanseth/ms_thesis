using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class SceneController : Singleton<SceneController> {

	public int counter;
	private bool flag;
	ParticleSystemManager manager;
	PhotonView photonView;
	//private bool masterFlag;


	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("Managers").GetComponent <ParticleSystemManager> ();
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
					Quaternion rotation = Quaternion.Euler (-89.96101f, 0.0f, 0.0f);
					GameObject chairBase = PhotonNetwork.Instantiate ("Prefabs/Base", new Vector3 (5, -1, 5), rotation, 0) as GameObject;
					chairBase.name = "Base";
					chairBase.transform.localScale = new Vector3 (45.0f, 45.0f, 13.6013f);
					flag = false;
					photonView = chairBase.GetComponent<PhotonView> ();
					//StartCoroutine (RPCFunctions(photonView));
					//photonView.RPC("GameObjectNamer", PhotonTargets.Others);
					//photonView.RPC("RendererSettings", PhotonTargets.All);
					//manager.RendererSettings ();
					break;
				
				default:
					print("No such case");
	                break;

			}

			StartCoroutine (RPCFunctions(photonView));
		}
	}

	IEnumerator RPCFunctions(PhotonView photonView) {
		photonView.RPC("GameObjectNamer", PhotonTargets.Others);
		yield return new WaitForSeconds (2f);
		photonView.RPC("RendererSettings", PhotonTargets.All);
	}
}
