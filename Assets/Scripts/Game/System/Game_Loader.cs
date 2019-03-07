using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Game_Loader : MonoBehaviour{ //Arrays which hold the Tile sets from which we build the map. In the future we can have different arrays for the "snow" and other terrain templates :D
	
	//External Game Data Component References
	public State_Handler state;
	public Game_Data data;
	
	//Coast Shenanigans
	public Tilemap[] Coasts;
	
	public GameObject Water_Effect;
	
	//References to the Tilemaps in which to place the ctual Visual Tiles
	public Tilemap Ground;
	public Tilemap Water;
	public Tilemap Terrain;
	
	//References to the Actual Visual Tiles to place
	public Tile Ground_Tile;
	public Tile Water_Tile;
	public Tile Forest_Tile;
	
	public GameObject Cliff;

	
	void Set_Water_Effect_Size(Vector2Int size){
		
		//Water Scaling and Position Ground Layer
		Water_Effect.transform.localScale = new Vector3(size.x/10f,1f,size.y/10f);
		Water_Effect.transform.position = new Vector3(size.x/2f,-0.07f,size.y/2f);

	}
	
	public TileType testing (int x, int y){
		try {
			var test = data.Map[y,x]; 
			// Error
		}
		catch {
			return TileType.Water;	
		}
		return data.Map[y,x].Type;
	}
	
	
	void Generate_Map(Map_Tile[,] map, Vector2Int size){
		
		int x_size = size.x;
		int y_size = size.y;
		
		Map_Tile tile_to_place;
		
		//Set Sizes and Position for the Water Effect Layers
		Set_Water_Effect_Size(size);
	
		//Generate Map
		for (int y = 0; y < y_size; y++){
            for (int x = 0; x < x_size; x++){
				
                Vector3Int localPlace = (new Vector3Int(x, y, (int)Ground.transform.position.y));

				tile_to_place = map[y,x]; //Don't ask why it's inverted, 2D Array lists are a meme and I'm a baddy.
				
				if (tile_to_place.Type == TileType.Ground){
					
					//TO DO: Random Ground Tile with prefab decal on top
					Ground.SetTile(localPlace,Ground_Tile);
				}
				else if (tile_to_place.Type == TileType.Water){
					
					if (testing(x-1,y) == TileType.Ground){
					
						Water.SetTile(localPlace,Water_Tile);
						//Debug.Log("Water Tile Set at: " + x + "," + y);
						Vector3 position = new Vector3(x+0.5f, 0, y+0.5f);
						
						Vector3 rotation = new Vector3(90f, 0f, -180f);

						Instantiate(Cliff, position, Quaternion.Euler(rotation));
						
					}
					
					else if (testing(x+1,y) == TileType.Ground){
						
						Water.SetTile(localPlace,Water_Tile);
						//Debug.Log("Water Tile Set at: " + x + "," + y);
						Vector3 position = new Vector3(x+0.5f, 0, y+0.5f);
						
						Vector3 rotation = new Vector3(90f, 0f, 0f);

						Instantiate(Cliff, position, Quaternion.Euler(rotation));
						
					}
					else{
					
					//Water_Cliff.SetTile(localPlace,Water_Cliff_Tile);
					Water.SetTile(localPlace,Water_Tile);
					
					

					}
				}
				
				/**
				else if (tile_to_place == 2){
					
					
					Vector3 position = new Vector3(x+0.5f, 0, y+0.5f);

					GameObject newGameObject = Instantiate(Cliff);

					newGameObject.transform.position = position;
					
					//Debug.Log("Cliff Tile Set at: " + x + "," + y);
					
				}
				else if (tile_to_place == 3){
					
					
					Vector3 position = new Vector3(x+0.5f, 0, y+0.5f);
					
					Vector3 rotation = new Vector3(90f, 0f, -180f);

					GameObject newGameObject = Instantiate(Cliff, position, Quaternion.Euler(rotation));

					//Debug.Log("Cliff Tile Set at: " + x + "," + y);
					
				}
				*/
				else if (tile_to_place.Type == TileType.Forest){
					
					Ground.SetTile(localPlace,Ground_Tile);
					Terrain.SetTile(localPlace,Forest_Tile);
					
				}
				
            }
        }
	}
	
	void Set_Camera_Position(){
		
		Debug.Log("test");
	
	}
	
	//void Set_Sun_Parameters(int x, int y){
	
		//Sun.transform.position = new Vector3(-5f,x,-5f);
		//Sun_Data.range = x * 3;
		//Sun_Data.intensity = Sun_Data.range/10;
	
	//}
	
	void Awake(){
		//Set parameters before anything else;
		//Parse first from file before calling Generate Map.
		//TO DO
		
		//Test Colors *matches units on field right now*
		Color P1Color = new Color(0.0352941f, 0.0747778f,0.8313726f,1.0f);
		Color P2Color = new Color(1.0f,0.0f,0.8593202f,1.0f);
		
		//Add Players
		//TO DO Recieves from what would be the menu or some other stuff before the game scene and load stuff like color rpeference player name, or other junk
		data.Add_Player(P1Color, "Rylander");
		data.Add_Player(P2Color, "Not Rylader");
		
		data.Day_Number = 1;
		data.Max_Players = 2;
		data.Players_Turn = 1;
		
		//Set Active Map
		data.Set_Active_Map(Map_List.test_map_1);
		
		//Call Function to Place Tiles into Map
		Generate_Map(data.Map, data.Map_Size);
		
	}
	
	// Use this for initialization
	void Start () {
		
		Debug.Log("Map Generated and stuff");
		
		
		//Set Light and Camera Initial Position
		//Set_Sun_Parameters(x_size,y_size);
	}
}
