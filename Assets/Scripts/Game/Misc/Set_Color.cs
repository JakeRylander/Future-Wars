using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Color : MonoBehaviour {
	
	new private SpriteRenderer renderer;
	private MaterialPropertyBlock block;

	// Use this for initialization
	void Start () {
		
		block = new MaterialPropertyBlock();
		renderer = GetComponent<SpriteRenderer>();
		
		renderer.GetPropertyBlock(block);
		
		block.SetColor("_Color",renderer.color);
		
		renderer.SetPropertyBlock(block);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
