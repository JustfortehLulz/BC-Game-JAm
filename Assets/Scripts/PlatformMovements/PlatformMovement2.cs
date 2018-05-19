using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement2 : MonoBehaviour {

	private Transform platform;

	// Use this for initialization
	void Start () 
	{
		platform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () 
	{
		platform.transform.position = new Vector2 (platform.transform.position.x, Mathf.PingPong(Time.time,3) - 3);
	}
}
