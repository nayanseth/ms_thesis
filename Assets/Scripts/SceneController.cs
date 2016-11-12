using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	public int counter;
	private bool flag;
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

			case 0:
				flag = false;
				break;
			}
		}
	}
}
