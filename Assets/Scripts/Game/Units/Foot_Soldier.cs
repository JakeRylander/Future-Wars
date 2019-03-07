using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot_Soldier : Land {
	
	//Constructor AKA Set up Data
	public Foot_Soldier(){
		
		Class = UnitClass.Foot_Soldier;
		
		TileType[] additional = {TileType.River};
		Walkable.AddRange(additional);
		
	}
}
