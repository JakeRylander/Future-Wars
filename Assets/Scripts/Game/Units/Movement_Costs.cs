using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class
public class Movement_Costs {
	
	/**Variable Declarations**/
	//Ground
	private int? ground;
    public int? Ground {get {return ground;} set{if (value == -1) {ground = null;} else {ground = value;}}}
	
	//Rough
	private int? rough;
	public int? Rough {get {return rough;} set{if (value == -1) {rough = null;} else {rough = value;}}}
	
	//Forest
	private int? forest;
    public int? Forest {get {return forest;} set{if (value == -1) {forest = null;} else {forest = value;}}}
	
	//Road
	private int? road;
	public int? Road {get {return road;} set{if (value == -1) {road = null;} else {road = value;}}}
	
	//River
	private int? river;
	public int? River {get {return river;} set{if (value == -1) {river = null;} else {river = value;}}}
	
	//Mountain
	private int? mountain;
	public int? Mountain {get {return mountain;} set{if (value == -1) {mountain = null;} else {mountain = value;}}}
	
	//Coast
	private int? coast;
	public int? Coast {get {return coast;} set{if (value == -1) {coast = null;} else {coast = value;}}}
	
	//Ruin
	private int? ruin;
	public int? Ruin {get {return ruin;} set{if (value == -1) {ruin = null;} else {ruin = value;}}}
	
	//Bridge
	private int? bridge;
	public int? Bridge {get {return bridge;} set{if (value == -1) {bridge = null;} else {bridge = value;}}}
	
	//Building
	private int? building;
	public int? Building {get {return building;} set{if (value == -1) {building = null;} else {building = value;}}}
	
	//Water
	private int? water;
    public int? Water {get {return water;} set{if (value == -1) {water = null;} else {water = value;}}}
	
	/**Methods**/
	//Base Constructor
	public Movement_Costs (int? ground, int? rough, int? forest, int? road, int? river, int? mountain, int? coast, int? ruin, int? bridge, int? building, int? water){
		
		Ground = ground;
		Rough = rough;
		Forest = forest;
		Road = road;
		River = river;
		Mountain = mountain;
		Coast = coast;
		Ruin = ruin;
		Bridge = bridge;
		Building = building;
		Water = water;
	}
	
	//Copy Constructor
	public Movement_Costs (Movement_Costs other){
		
		Ground = other.Ground;
		Rough = other.Rough;
		Forest = other.Forest;
		Road =  other.Road;
		River = other.River;
		Mountain = other.Mountain;
		Coast = other.Coast;
		Ruin = other.Ruin;
		Bridge = other.Bridge;
		Building = other.Building;
		Water = other.Water;
	}

	//Cost Getter
	public int? Get_Cost(TileType type){
		switch (type) {
			case TileType.Ground:
				return Ground;
			case TileType.Rough:
				return Rough;
			case TileType.Forest:
				return Forest;
			case TileType.Road:
				return Road;
			case TileType.River:
				return River;
			case TileType.Mountain:
				return Mountain;
			case TileType.Coast:
				return Coast;
			case TileType.Ruin:
				return Ruin;
			case TileType.Bridge:
				return Bridge;
			case TileType.Building:
				return Building;
			case TileType.Water:
				return Water;
			default:
				return 0;
		}
	}
	
	/**Static Declarations for Global Game usage and copying.**/
	//FootSoldiers
	//Boots
	public static Movement_Costs Boots = new Movement_Costs(Movement_Constants.Ground.Boots,
																Movement_Constants.Rough.Boots,
																Movement_Constants.Forest.Boots,
																Movement_Constants.Road.Boots,
																Movement_Constants.River.Boots,
																Movement_Constants.Mountain.Boots,
																Movement_Constants.Coast.Boots,
																Movement_Constants.Ruin.Boots,
																Movement_Constants.Bridge.Boots,
																Movement_Constants.Building.Boots,
																Movement_Constants.Water.Boots);
	//Heavy Boots
	public static Movement_Costs Heavy_Boots = new Movement_Costs(Movement_Constants.Ground.Heavy_Boots,
																Movement_Constants.Rough.Heavy_Boots,
																Movement_Constants.Forest.Heavy_Boots,
																Movement_Constants.Road.Heavy_Boots,
																Movement_Constants.River.Heavy_Boots,
																Movement_Constants.Mountain.Heavy_Boots,
																Movement_Constants.Coast.Heavy_Boots,
																Movement_Constants.Ruin.Heavy_Boots,
																Movement_Constants.Bridge.Heavy_Boots,
																Movement_Constants.Building.Heavy_Boots,
																Movement_Constants.Water.Heavy_Boots);
	//Vehicles
	//Tires
	public static Movement_Costs Tires = new Movement_Costs(Movement_Constants.Ground.Tires,
																Movement_Constants.Rough.Tires,
																Movement_Constants.Forest.Tires,
																Movement_Constants.Road.Tires,
																Movement_Constants.River.Tires,
																Movement_Constants.Mountain.Tires,
																Movement_Constants.Coast.Tires,
																Movement_Constants.Ruin.Tires,
																Movement_Constants.Bridge.Tires,
																Movement_Constants.Building.Tires,
																Movement_Constants.Water.Tires);
	//AT Tires
	public static Movement_Costs AT_Tires = new Movement_Costs(Movement_Constants.Ground.AT_Tires,
																Movement_Constants.Rough.AT_Tires,
																Movement_Constants.Forest.AT_Tires,
																Movement_Constants.Road.AT_Tires,
																Movement_Constants.River.AT_Tires,
																Movement_Constants.Mountain.AT_Tires,
																Movement_Constants.Coast.AT_Tires,
																Movement_Constants.Ruin.AT_Tires,
																Movement_Constants.Bridge.AT_Tires,
																Movement_Constants.Building.AT_Tires,
																Movement_Constants.Water.AT_Tires);
	//Threads
	public static Movement_Costs Threads = new Movement_Costs(Movement_Constants.Ground.Threads,
																Movement_Constants.Rough.Threads,
																Movement_Constants.Forest.Threads,
																Movement_Constants.Road.Threads,
																Movement_Constants.River.Threads,
																Movement_Constants.Mountain.Threads,
																Movement_Constants.Coast.Threads,
																Movement_Constants.Ruin.Threads,
																Movement_Constants.Bridge.Threads,
																Movement_Constants.Building.Threads,
																Movement_Constants.Water.Threads);
	//Aerial
	//Helicopter
	public static Movement_Costs Helicopter = new Movement_Costs(Movement_Constants.Ground.Helicopter,
																Movement_Constants.Rough.Helicopter,
																Movement_Constants.Forest.Helicopter,
																Movement_Constants.Road.Helicopter,
																Movement_Constants.River.Helicopter,
																Movement_Constants.Mountain.Helicopter,
																Movement_Constants.Coast.Helicopter,
																Movement_Constants.Ruin.Helicopter,
																Movement_Constants.Bridge.Helicopter,
																Movement_Constants.Building.Helicopter,
																Movement_Constants.Water.Helicopter);
	//Propeller
	public static Movement_Costs Propeller = new Movement_Costs(Movement_Constants.Ground.Propeller,
																Movement_Constants.Rough.Propeller,
																Movement_Constants.Forest.Propeller,
																Movement_Constants.Road.Propeller,
																Movement_Constants.River.Propeller,
																Movement_Constants.Mountain.Propeller,
																Movement_Constants.Coast.Propeller,
																Movement_Constants.Ruin.Propeller,
																Movement_Constants.Bridge.Propeller,
																Movement_Constants.Building.Propeller,
																Movement_Constants.Water.Propeller);
	//Jet
	public static Movement_Costs Jet = new Movement_Costs(Movement_Constants.Ground.Jet,
																Movement_Constants.Rough.Jet,
																Movement_Constants.Forest.Jet,
																Movement_Constants.Road.Jet,
																Movement_Constants.River.Jet,
																Movement_Constants.Mountain.Jet,
																Movement_Constants.Coast.Jet,
																Movement_Constants.Ruin.Jet,
																Movement_Constants.Bridge.Jet,
																Movement_Constants.Building.Jet,
																Movement_Constants.Water.Jet);
	//Naval
	//Boat
	public static Movement_Costs Boat = new Movement_Costs(Movement_Constants.Ground.Boat,
																Movement_Constants.Rough.Boat,
																Movement_Constants.Forest.Boat,
																Movement_Constants.Road.Boat,
																Movement_Constants.River.Boat,
																Movement_Constants.Mountain.Boat,
																Movement_Constants.Coast.Boat,
																Movement_Constants.Ruin.Boat,
																Movement_Constants.Bridge.Boat,
																Movement_Constants.Building.Boat,
																Movement_Constants.Water.Boat);
	//Submersible
	public static Movement_Costs Submersible = new Movement_Costs(Movement_Constants.Ground.Submersible,
																Movement_Constants.Rough.Submersible,
																Movement_Constants.Forest.Submersible,
																Movement_Constants.Road.Submersible,
																Movement_Constants.River.Submersible,
																Movement_Constants.Mountain.Submersible,
																Movement_Constants.Coast.Submersible,
																Movement_Constants.Ruin.Submersible,
																Movement_Constants.Bridge.Submersible,
																Movement_Constants.Building.Submersible,
																Movement_Constants.Water.Submersible);																
}