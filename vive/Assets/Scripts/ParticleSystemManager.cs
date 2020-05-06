using UnityEngine;
using System.Collections;

public class ParticleSystemManager : MonoBehaviour {

	GameObject proposedPlacementTrigger;
	ParticleSystem pSystem;
	ParticleSystemRenderer pRenderer;
	public Material defaultDiffuse;
	int counter;

	// Use this for initialization
	void Start () {
		counter = GameObject.Find ("Managers").GetComponent<SceneController> ().counter;

		proposedPlacementTrigger = GameObject.Find ("Proposed Placement Trigger");
		pSystem = proposedPlacementTrigger.GetComponent<ParticleSystem> ();
		pRenderer = proposedPlacementTrigger.GetComponent<ParticleSystemRenderer> ();

		// Emission Attributes
		pSystem.startSpeed = 0f;
		var emission = pSystem.emission;
		emission.rate = 1f;
		emission.type = ParticleSystemEmissionType.Time;

		// Shape Attributes
		var shape = pSystem.shape;
		shape.shapeType = ParticleSystemShapeType.Mesh;
		shape.meshShapeType = ParticleSystemMeshShapeType.Vertex;

		// Renderer Common Attributes 
		pRenderer.renderMode = ParticleSystemRenderMode.Mesh;
		pRenderer.material = defaultDiffuse;

	}
}
