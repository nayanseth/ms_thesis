using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class SceneController : Singleton<SceneController> {

	public int counter;
	private bool flag;

	private GameObject[] sceneObjects;

	// Use this for initialization
	void Start () {

		counter = 0;
		flag = true;
	}

	// Update is called once per frame
	void Update () {

		SceneObjective (counter);

	}

	void SceneObjective(int counter) {

		if (flag) {
			switch (counter) {

			case 0:
				Quaternion rotation = Quaternion.Euler (-89.96101f, 0.0f, 0.0f);
				GameObject chairBase = Instantiate (Resources.Load ("Prefabs/Base"), new Vector3 (0, -1, 5), rotation) as GameObject;
				chairBase.name = "Base";
				chairBase.transform.localScale = new Vector3 (45.0f, 45.0f, 13.6013f);
				flag = false;
				break;
			}
		}
	}
}
