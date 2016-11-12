using UnityEngine;
using Photon;

public class NetworkCharacter : Photon.MonoBehaviour {
    private Vector3 correctPlayerPos;
    //private Quaternion correctPlayerRot;



    // Update is called once per frame
		void Update() {
				print(this.gameObject.transform.position);
        if (!photonView.isMine)
        {
						print("Not my view!");
            transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
            //transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting)
        {
						print("My view!");
            // We own this player: send the others our data
            stream.SendNext(this.gameObject.transform.position);
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
