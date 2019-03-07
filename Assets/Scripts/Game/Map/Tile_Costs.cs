using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class 
public class Tile_Costs {
	
	/**Variable Declarations**/
	//Boots
	private int? boots;
	public int? Boots {get {return boots;} set{if (value == -1) {boots = null;} else {boots = value;}}}
	
	//Heavy Boots
	private int? heavy_boots;
    public int? Heavy_Boots {get {return heavy_boots;} set{if (value == -1) {heavy_boots = null;} else {heavy_boots = value;}}}
	
	//Tires
	private int? tires;
	public int? Tires {get {return tires;} set{if (value == -1) {tires = null;} else {tires = value;}}}
	
	//All Terrain Tires
	private int? at_tires;
	public int? AT_Tires {get {return at_tires;} set{if (value == -1) {at_tires = null;} else {at_tires = value;}}}
	
	//Threads
	private int? threads;
	public int? Threads {get {return threads;} set{if (value == -1) {threads = null;} else {threads = value;}}}
	
	//Helicopter
	private int? helicopter;
	public int? Helicopter {get {return helicopter;} set{if (value == -1) {helicopter = null;} else {helicopter = value;}}}
	
	//Propeller
	private int? propeller;
	public int? Propeller {get {return propeller;} set{if (value == -1) {propeller = null;} else {propeller = value;}}}
	
	//Jet
	private int? jet;
	public int? Jet {get {return jet;} set{if (value == -1) {jet = null;} else {jet = value;}}}
	
	//Boat
	private int? boat;
	public int? Boat {get {return boat;} set{if (value == -1) {boat = null;} else {boat = value;}}}
	
	//Submersible
	private int? submersible;
	public int? Submersible {get {return submersible;} set{if (value == -1) {submersible = null;} else {submersible = value;}}}

	/**Methods**/
	//Base Constructor
	public Tile_Costs(int? boots, int? heavy_boots, int? tires, int? at_tires, int? threads, int? helicopter, int? propeller, int? jet, int? boat, int? submersible) {
		Boots = boots;
		Heavy_Boots = heavy_boots;
		Tires = tires;
		AT_Tires = at_tires;
		Threads = threads;
		Helicopter = helicopter;
		Propeller = propeller;
		Jet = jet;
		Boat = boat;
		Submersible = submersible;
    }

	//Special Copy Constructor for Map_Tile copying
	public Tile_Costs (TileType type){
		switch (type) {
			//Ground
			case TileType.Ground:
				Boots = Ground.Boots;
				Heavy_Boots = Ground.Heavy_Boots;
				Tires = Ground.Tires;
				AT_Tires = Ground.AT_Tires;
				Threads = Ground.Threads;
				Helicopter = Ground.Helicopter;
				Propeller = Ground.Propeller;
				Jet = Ground.Jet;
				Boat = Ground.Boat;
				Submersible = Ground.Submersible;
				break;
			//Rough
			case TileType.Rough:
				Boots = Rough.Boots;
				Heavy_Boots = Rough.Heavy_Boots;
				Tires = Rough.Tires;
				AT_Tires = Rough.AT_Tires;
				Threads = Rough.Threads;
				Helicopter = Rough.Helicopter;
				Propeller = Rough.Propeller;
				Jet = Rough.Jet;
				Boat = Rough.Boat;
				Submersible = Rough.Submersible;
				break;
			//Forest
			case TileType.Forest:
				Boots = Forest.Boots;
				Heavy_Boots = Forest.Heavy_Boots;
				Tires = Forest.Tires;
				AT_Tires = Forest.AT_Tires;
				Threads = Forest.Threads;
				Helicopter = Forest.Helicopter;
				Propeller = Forest.Propeller;
				Jet = Forest.Jet;
				Boat = Forest.Boat;
				Submersible = Forest.Submersible;
				break;
			//Road
			case TileType.Road:
				Boots = Road.Boots;
				Heavy_Boots = Road.Heavy_Boots;
				Tires = Road.Tires;
				AT_Tires = Road.AT_Tires;
				Threads = Road.Threads;
				Helicopter = Road.Helicopter;
				Propeller = Road.Propeller;
				Jet = Road.Jet;
				Boat = Road.Boat;
				Submersible = Road.Submersible;
				break;
			//River
			case TileType.River:
				Boots = River.Boots;
				Heavy_Boots = River.Heavy_Boots;
				Tires = River.Tires;
				AT_Tires = River.AT_Tires;
				Threads = River.Threads;
				Helicopter = River.Helicopter;
				Propeller = River.Propeller;
				Jet = River.Jet;
				Boat = River.Boat;
				Submersible = River.Submersible;
				break;
			//Mountain
			case TileType.Mountain:
				Boots = Mountain.Boots;
				Heavy_Boots = Mountain.Heavy_Boots;
				Tires = Mountain.Tires;
				AT_Tires = Mountain.AT_Tires;
				Threads = Mountain.Threads;
				Helicopter = Mountain.Helicopter;
				Propeller = Mountain.Propeller;
				Jet = Mountain.Jet;
				Boat = Mountain.Boat;
				Submersible = Mountain.Submersible;
				break;
			//Coast
			case TileType.Coast:
				Boots = Coast.Boots;
				Heavy_Boots = Coast.Heavy_Boots;
				Tires = Coast.Tires;
				AT_Tires = Coast.AT_Tires;
				Threads = Coast.Threads;
				Helicopter = Coast.Helicopter;
				Propeller = Coast.Propeller;
				Jet = Coast.Jet;
				Boat = Coast.Boat;
				Submersible = Coast.Submersible;
				break;
			//Ruin
			case TileType.Ruin:
				Boots = Ruin.Boots;
				Heavy_Boots = Ruin.Heavy_Boots;
				Tires = Ruin.Tires;
				AT_Tires = Ruin.AT_Tires;
				Threads = Ruin.Threads;
				Helicopter = Ruin.Helicopter;
				Propeller = Ruin.Propeller;
				Jet = Ruin.Jet;
				Boat = Ruin.Boat;
				Submersible = Ruin.Submersible;
				break;
			//Bridge
			case TileType.Bridge:
				Boots = Bridge.Boots;
				Heavy_Boots = Bridge.Heavy_Boots;
				Tires = Bridge.Tires;
				AT_Tires = Bridge.AT_Tires;
				Threads = Bridge.Threads;
				Helicopter = Bridge.Helicopter;
				Propeller = Bridge.Propeller;
				Jet = Bridge.Jet;
				Boat = Bridge.Boat;
				Submersible = Bridge.Submersible;
				break;
			//Building
			case TileType.Building:
				Boots = Building.Boots;
				Heavy_Boots = Building.Heavy_Boots;
				Tires = Building.Tires;
				AT_Tires = Building.AT_Tires;
				Threads = Building.Threads;
				Helicopter = Building.Helicopter;
				Propeller = Building.Propeller;
				Jet = Building.Jet;
				Boat = Building.Boat;
				Submersible = Building.Submersible;
				break;
			//Water
			case TileType.Water:
				Boots = Water.Boots;
				Heavy_Boots = Water.Heavy_Boots;
				Tires = Water.Tires;
				AT_Tires = Water.AT_Tires;
				Threads = Water.Threads;
				Helicopter = Water.Helicopter;
				Propeller = Water.Propeller;
				Jet = Water.Jet;
				Boat = Water.Boat;
				Submersible = Water.Submersible;
				break;
			default:
				break;
		}
	}

	//Get Cost of specific Movement Type
	public int? Get_Cost(MovementType type){
		switch (type) {
			case MovementType.Boots:
				return Boots;
			case MovementType.Heavy_Boots:
				return Heavy_Boots;
			case MovementType.Tires:
				return Tires;
			case MovementType.AT_Tires:
				return AT_Tires;
			case MovementType.Threads:
				return Threads;
			case MovementType.Helicopter:
				return Helicopter;
			case MovementType.Propeller:
				return Propeller;
			case MovementType.Jet:
				return Jet;
			case MovementType.Boat:
				return Boat;
			case MovementType.Submersible:
				return Submersible;
			default:
				return 0;
		}
	}
	
	/**Static Declarations for Global Game usage and copying.**/	
	//Ground
	public static Tile_Costs Ground = new Tile_Costs(Movement_Constants.Ground.Boots,
													 Movement_Constants.Ground.Heavy_Boots,
													 Movement_Constants.Ground.Tires,
													 Movement_Constants.Ground.AT_Tires,
													 Movement_Constants.Ground.Threads,
													 Movement_Constants.Ground.Helicopter,
													 Movement_Constants.Ground.Propeller,
													 Movement_Constants.Ground.Jet,
													 Movement_Constants.Ground.Boat,
													 Movement_Constants.Ground.Submersible);
	//Rough
	public static Tile_Costs Rough = new Tile_Costs(Movement_Constants.Rough.Boots,
													Movement_Constants.Rough.Heavy_Boots,
													Movement_Constants.Rough.Tires,
													Movement_Constants.Rough.AT_Tires,
													Movement_Constants.Rough.Threads,
													Movement_Constants.Rough.Helicopter,
													Movement_Constants.Rough.Propeller,
													Movement_Constants.Rough.Jet,
													Movement_Constants.Rough.Boat,
													Movement_Constants.Rough.Submersible);

	//Forest
	public static Tile_Costs Forest = new Tile_Costs(Movement_Constants.Forest.Boots,
													 Movement_Constants.Forest.Heavy_Boots,
													 Movement_Constants.Forest.Tires,
													 Movement_Constants.Forest.AT_Tires,
													 Movement_Constants.Forest.Threads,
													 Movement_Constants.Forest.Helicopter,
													 Movement_Constants.Forest.Propeller,
													 Movement_Constants.Forest.Jet,
													 Movement_Constants.Forest.Boat,
													 Movement_Constants.Forest.Submersible);
	//Road
	public static Tile_Costs Road = new Tile_Costs(Movement_Constants.Road.Boots,
												    Movement_Constants.Road.Heavy_Boots,
													Movement_Constants.Road.Tires,
													Movement_Constants.Road.AT_Tires,
													Movement_Constants.Road.Threads,
													Movement_Constants.Road.Helicopter,
													Movement_Constants.Road.Propeller,
													Movement_Constants.Road.Jet,
													Movement_Constants.Road.Boat,
													Movement_Constants.Road.Submersible);
	//River
	public static Tile_Costs River = new Tile_Costs(Movement_Constants.River.Boots,
													Movement_Constants.River.Heavy_Boots,
													Movement_Constants.River.Tires,
													Movement_Constants.River.AT_Tires,
													Movement_Constants.River.Threads,
													Movement_Constants.River.Helicopter,
													Movement_Constants.River.Propeller,
													Movement_Constants.River.Jet,
													Movement_Constants.River.Boat,
													Movement_Constants.River.Submersible);
	//Mountain
	public static Tile_Costs Mountain = new Tile_Costs(Movement_Constants.Mountain.Boots,
													Movement_Constants.Mountain.Heavy_Boots,
													Movement_Constants.Mountain.Tires,
													Movement_Constants.Mountain.AT_Tires,
													Movement_Constants.Mountain.Threads,
													Movement_Constants.Mountain.Helicopter,
													Movement_Constants.Mountain.Propeller,
													Movement_Constants.Mountain.Jet,
													Movement_Constants.Mountain.Boat,
													Movement_Constants.Mountain.Submersible);
	//Coast
	public static Tile_Costs Coast = new Tile_Costs(Movement_Constants.Coast.Boots,
													Movement_Constants.Coast.Heavy_Boots,
													Movement_Constants.Coast.Tires,
													Movement_Constants.Coast.AT_Tires,
													Movement_Constants.Coast.Threads,
													Movement_Constants.Coast.Helicopter,
													Movement_Constants.Coast.Propeller,
													Movement_Constants.Coast.Jet,
													Movement_Constants.Coast.Boat,
													Movement_Constants.Coast.Submersible);
	//Ruin
	public static Tile_Costs Ruin = new Tile_Costs(Movement_Constants.Ruin.Boots,
													Movement_Constants.Ruin.Heavy_Boots,
													Movement_Constants.Ruin.Tires,
													Movement_Constants.Ruin.AT_Tires,
													Movement_Constants.Ruin.Threads,
													Movement_Constants.Ruin.Helicopter,
													Movement_Constants.Ruin.Propeller,
													Movement_Constants.Ruin.Jet,
													Movement_Constants.Ruin.Boat,
													Movement_Constants.Ruin.Submersible);
	//Bridge
	public static Tile_Costs Bridge = new Tile_Costs(Movement_Constants.Bridge.Boots,
													Movement_Constants.Bridge.Heavy_Boots,
													Movement_Constants.Bridge.Tires,
													Movement_Constants.Bridge.AT_Tires,
													Movement_Constants.Bridge.Threads,
													Movement_Constants.Bridge.Helicopter,
													Movement_Constants.Bridge.Propeller,
													Movement_Constants.Bridge.Jet,
													Movement_Constants.Bridge.Boat,
													Movement_Constants.Bridge.Submersible);
	//Building
	public static Tile_Costs Building = new Tile_Costs(Movement_Constants.Building.Boots,
													Movement_Constants.Building.Heavy_Boots,
													Movement_Constants.Building.Tires,
													Movement_Constants.Building.AT_Tires,
													Movement_Constants.Building.Threads,
													Movement_Constants.Building.Helicopter,
													Movement_Constants.Building.Propeller,
													Movement_Constants.Building.Jet,
													Movement_Constants.Building.Boat,
													Movement_Constants.Building.Submersible);
	
	//Water
	public static Tile_Costs Water = new Tile_Costs(Movement_Constants.Water.Boots,
													Movement_Constants.Water.Heavy_Boots,
													Movement_Constants.Water.Tires,
													Movement_Constants.Water.AT_Tires,
													Movement_Constants.Water.Threads,
													Movement_Constants.Water.Helicopter,
													Movement_Constants.Water.Propeller,
													Movement_Constants.Water.Jet,
													Movement_Constants.Water.Boat,
													Movement_Constants.Water.Submersible);
}