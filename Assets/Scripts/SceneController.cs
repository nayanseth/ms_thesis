using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	public int counter;
	public bool flag;
	GameObject temp;
	Quaternion rotation;
	PhotonView photonView;
	//private bool masterFlag;

	// Use this for initialization
	void Start () {

		counter = 0;
		flag = false;
		//masterFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		/*
		if (PhotonNetwork.inRoom && masterFlag) {
			PhotonNetwork.SetMasterClient (PhotonNetwork.masterClient);
			masterFlag = false;
		}
		*/

		if (flag) {
			SceneObjective (counter);
		}

	}

	void SceneObjective(int counter) {

		if (PhotonNetwork.inRoom) {
			switch (counter) {

				case 1:
					flag = false;
					rotation = Quaternion.Euler (-89.96101f, 0.0f, 0.0f);
					temp = PhotonNetwork.Instantiate ("Prefabs/Wheel 1", new Vector3 (5.035f, -0.393f, 5.327f), rotation, 0) as GameObject;
					temp.name = "Wheel 1";
					temp.transform.localScale = new Vector3 (2.088205f, 2.088205f, 3.972193f);
					break;

			}

			photonView = temp.GetComponent<PhotonView> ();
			StartCoroutine (RPCFunctions(photonView));
		}
	}

	IEnumerator RPCFunctions(PhotonView photonView) {
		photonView.RPC("GameObjectNamer", PhotonTargets.Others);
		yield return new WaitForSeconds (2f);
		photonView.RPC("RendererSettings", PhotonTargets.All);
	}
}
