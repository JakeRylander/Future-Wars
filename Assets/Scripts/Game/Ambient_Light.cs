using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambient_Light : MonoBehaviour {
	
	private Quaternion Rotation;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void LateUpdate(){
		Rotation = Quaternion.Euler(30,transform.eulerAngles.y,transform.eulerAngles.z);
		transform.rotation = Rotation;
		
	}
}
