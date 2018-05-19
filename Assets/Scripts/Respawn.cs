using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public Transform spawn;

	public void playerRespawn()
	{
		float y = -3.09F;
		transform.position = new Vector2 (spawn.position.x , y);
	}



}
