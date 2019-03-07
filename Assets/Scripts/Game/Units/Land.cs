using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : Unit {

	//Constructor AKA Set up Data
	public Land(){
		
		Walkable = new List<TileType> {TileType.Ground, TileType.Forest};
		Type = UnitType.Land;
	}
}
