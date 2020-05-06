using UnityEngine;
using Photon;

public class NetworkCharacter : Photon.MonoBehaviour {
    private Vector3 correctPlayerPos;
    //private Quaternion correctPlayerRot;

    // Update is called once per frame
	void Update() {
        if (!photonView.isMine)
        {
			//print ("Photon View is not Mine!");
			//print (this.gameObject.transform.position);
			//print (this.correctPlayerPos);
			this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, this.correctPlayerPos, Time.deltaTime * 5);
			//transform.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		//print ("Method Called");
		if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(transform.position);
            //stream.SendNext(transform.rotation);

        }
        else
        {
            // Network player, receive data
            this.correctPlayerPos = (Vector3)stream.ReceiveNext();
            //this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
        }
    }

}

