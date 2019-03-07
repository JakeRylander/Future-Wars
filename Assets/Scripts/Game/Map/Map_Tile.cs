using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Tile {
	
	//Flavor Text
	public string Name;
	public string Description;
	
	//Type
	public TileType Type;
	
	//Building if any;
	public bool Has_Building;
	public BuildingType Building;
	public int Building_Belongs_To;
	
	//Stats
	public int Defense_Rating;

	//Movement Cost Values for the Tile Type;
	public Tile_Costs Cost;

	//Constructor when no Building
	public Map_Tile(string name, string description, TileType type, int defense){
		Name = name;
		Description = description;
		Type = type;
		Defense_Rating = defense;
		Has_Building = false;
		Cost = new Tile_Costs(Type); 
	}
	
	//Constructor when a Building is on the Tile
	public Map_Tile(string name, string description, TileType type, BuildingType buildtype, int defense, int belongs_to){
		Name = name;
		Description = description;
		Type = type;
		Building = buildtype;
		Defense_Rating = defense;
		Has_Building = true;
		Building_Belongs_To = belongs_to;
		
	}
	
	/**Static Declarations for Global Game usage and copying.**/
	//Enviroment Tiles		
	//Temperate Climate
	public static Map_Tile Grassland = new Map_Tile("Grassland", "Clear cut grass that offers normal mobility to all Land Units.", TileType.Ground, 0);
	public static Map_Tile Marsh = new Map_Tile("Marsh", "Dense Marsh that inhibits movement for almost all Land Units.", TileType.Rough, 0);
	public static Map_Tile Deciduous_Forest = new Map_Tile("Forest", "Dense Canopy Provides Moderate Defense Bonus at the cost of reduced Movement.", TileType.Forest, 2);
	public static Map_Tile Sea = new Map_Tile("Sea", "Clear Blue Ocean Sea through which all Sea Units can move through.", TileType.Water, 0);
	
	//Wet Climate
	
	//Dry Climate (Desert)
	
	//Snow Climate
	
	//All Climatesw
	public static Map_Tile River = new Map_Tile("River", "Stream of flowing water, blocks movement for all Land Units, except Foot Soldiers.", TileType.River, 0);
	public static Map_Tile Mountain = new Map_Tile("Mountain", "Rocky Terrain Piercing into the Heavens, only Foot Soldiers can move through here, but gives High Defense and Vision.", TileType.Mountain, 4);
	public static Map_Tile Coast = new Map_Tile("Coast", "Area Connecting Land and Sea that allows Land Units to be loaded and unloaded from Naval Units.", TileType.Coast, 0);
	public static Map_Tile Ruin = new Map_Tile("Ruin", "Remains of what was once a functional Building, provides moderate cover at the cost of movement.", TileType.Ruin, 2);
	
	//ManMade
	//Roads
	public static Map_Tile Road = new Map_Tile("Road", "Manmade pavement allows for even faster travel than normal ground.", TileType.Road, 0);
	public static Map_Tile Bridge = new Map_Tile("Bridge", "Manmade elevated platform that allows for even faster travel, while also permitting Naval movement.", TileType.Bridge, 0);
	
	//Buildings [0 = neutral, 1 = Player1, 2 = Player2, 3 = Player3, 4 = Player4]
	//HQ
	public static Map_Tile HQ1 = new Map_Tile("HQ", "Base of Operations, losing this building means losing the match.", TileType.Building, BuildingType.HQ, 4, 1);
	public static Map_Tile HQ2 = new Map_Tile("HQ", "Base of Operations, losing this building means losing the match.", TileType.Building, BuildingType.HQ, 4, 2);
	public static Map_Tile HQ3 = new Map_Tile("HQ", "Base of Operations, losing this building means losing the match.", TileType.Building, BuildingType.HQ, 4, 3);
	public static Map_Tile HQ4 = new Map_Tile("HQ", "Base of Operations, losing this building means losing the match.", TileType.Building, BuildingType.HQ, 4, 4);
	
	//Camp
	public static Map_Tile Camp0 = new Map_Tile("Camp", "Training Camp that allows for deployment of Foot Solier Class Units.", TileType.Building, BuildingType.Camp, 3, 0);
	public static Map_Tile Camp1 = new Map_Tile("Camp", "Training Camp that allows for deployment of Foot Solier Class Units.", TileType.Building, BuildingType.Camp, 3, 1);
	public static Map_Tile Camp2 = new Map_Tile("Camp", "Training Camp that allows for deployment of Foot Solier Class Units.", TileType.Building, BuildingType.Camp, 3, 2);
	public static Map_Tile Camp3 = new Map_Tile("Camp", "Training Camp that allows for deployment of Foot Solier Class Units.", TileType.Building, BuildingType.Camp, 3, 3);
	public static Map_Tile Camp4 = new Map_Tile("Camp", "Training Camp that allows for deployment of Foot Solier Class Units.", TileType.Building, BuildingType.Camp, 3, 4);
}
