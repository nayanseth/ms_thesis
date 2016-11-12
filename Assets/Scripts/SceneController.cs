using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class SceneController : Singleton<SceneController> {

	public int counter;
	private bool flag;
	//private bool masterFlag;


	// Use this for initialization
	void Start () {

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
				GameObject chairBase = PhotonNetwork.Instantiate ("Prefabs/Base", new Vector3 (0, -1, 5), rotation, 0) as GameObject;
				chairBase.name = "Base";
				chairBase.transform.localScale = new Vector3 (45.0f, 45.0f, 13.6013f);
				flag = false;
				break;
			}
		}
	}
}
