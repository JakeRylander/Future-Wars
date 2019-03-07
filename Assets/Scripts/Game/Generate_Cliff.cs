using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Generate_Cliff : MonoBehaviour{

	 public int size;
	 
	 private int X_Size;
	 private int Y_Size;
	
     private Texture2D texture; 
	 private SpriteRenderer sprite;
	 
	 private bool Within_Sprite(int x, int y){
		return ((x >= 0) & (x < X_Size) & (y >= 0) & (y < Y_Size));
	 }
	 
	 private bool test(int x, int y){
		 
		 if(texture.GetPixel(x-1,y).a == 0){
			 return true;
		 }
		 else{
			 return false;
		 }
		 
	 }
	 
     void Start()
		{
		
        sprite = GetComponent<SpriteRenderer>();
		
		Rect box = sprite.sprite.textureRect;
		
		texture = sprite.sprite.texture;
		
		X_Size = (int)box.width;
		Y_Size = (int)box.height;
	
		float ppu_scale = 1/sprite.sprite.pixelsPerUnit;
		
		for (int y = 0; y < Y_Size; y++)
        {
            for (int x = 0; x < X_Size; x++) //Goes through each pixel
            {
			 
               if (texture.GetPixel(x,y).a == 0) //Transparent, ignore.
                {
                    continue;
                }
               else
                {
					if (test(x,y)){
					Vector3 spawnLocation = new Vector3();

					//Magic Number Shenanigans to make it spawn underneath the sprite.
					spawnLocation.x = ((x*ppu_scale)+(ppu_scale/2))-0.5f;
					spawnLocation.y = ((y*ppu_scale)+(ppu_scale/2))-0.5f;
					spawnLocation.z = -(((ppu_scale/2)-ppu_scale)*size)+0.0001f;


					var cube  = GameObject.CreatePrimitive(PrimitiveType.Cube);
					cube.transform.position = spawnLocation;
					cube.transform.localScale = new Vector3(ppu_scale,ppu_scale,ppu_scale*size);

					var cube_renderer = cube.GetComponent<Renderer>();
					cube_renderer.material.color = texture.GetPixel(x,y);
					cube.transform.SetParent(this.transform, false);
					Destroy(cube.GetComponent<Collider>());
					cube.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
						
					}
					else{
						continue;
					}

                }
            }
        }
     }
 }
