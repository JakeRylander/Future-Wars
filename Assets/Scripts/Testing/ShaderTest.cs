using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShaderTest : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
		GetComponent<TilemapRenderer>().receiveShadows = true;
        GetComponent<TilemapRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
