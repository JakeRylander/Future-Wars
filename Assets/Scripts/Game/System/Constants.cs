using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Armor Value Constans
public static class Armor_Constants {
	public const int Standard_Outfit = 5;
	public const int Heavy_Outfit = 10;
}

//Movement Constants (-1 = null)
public static class Movement_Constants {
	
	public struct Ground {
		
		public const int Boots = 1;
		public const int Heavy_Boots = 1;
		public const int Tires = 2;
		public const int AT_Tires = 1;
		public const int Threads = 1;
		public const int Helicopter = 1;
		public const int Propeller = 1;
		public const int Jet = 1;
		public const int Boat = -1;
		public const int Submersible = -1;
		
	}
	public struct Rough {
		
		public const int Boots = 2;
		public const int Heavy_Boots = 1;
		public const int Tires = 2;
		public const int AT_Tires = 1;
		public const int Threads = 2;
		public const int Helicopter = 1;
		public const int Propeller = 1;
		public const int Jet = 1;
		public const int Boat = -1;
		public const int Submersible = -1;

	}
	public struct Forest {
		
		public const int Boots = 2;
		public const int Heavy_Boots = 2;
		public const int Tires = 3;
		public const int AT_Tires = 2;
		public const int Threads = 2;
		public const int Helicopter = 1;
		public const int Propeller = 1;
		public const int Jet = 1;
		public const int Boat = -1;
		public const int Submersible = -1;

	}
	public struct Road {
		
		public const int Boots = 1;
		public const int Heavy_Boots = 1;
		public const int Tires = 1;
		public const int AT_Tires = 1;
		public const int Threads = 1;
		public const int Helicopter = 1;
		public const int Propeller = 1;
		public const int Jet = 1;
		public const int Boat = -1;
		public const int Submersible = -1;

	}
	public struct River {
		
		public const int Boots = 3;
		public const int Heavy_Boots = 2;
		public const int Tires = -1;
		public const int AT_Tires = -1;
		public const int Threads = -1;
		public const int Helicopter = 1;
		public const int Propeller = 1;
		public const int Jet = 1;
		public const int Boat = -1;
		public const int Submersible = -1;

	}
	public struct Mountain {
		
		public const int Boots = 2;
		public const int Heavy_Boots = 1;
		public const int Tires = -1;
		public const int AT_Tires = -1;
		public const int Threads = -1;
		public const int Helicopter = 1;
		public const int Propeller = 1;
		public const int Jet = 1;
		public const int Boat = -1;
		public const int Submersible = -1;

	}
	public struct Coast {
		
		public const int Boots = 1;
		public const int Heavy_Boots = 1;
		public const int Tires = 1;
		public const int AT_Tires = 1;
		public const int Threads = 1;
		public const int Helicopter = 1;
		public const int Propeller = 1;
		public const int Jet = 1;
		public const int Boat = 1;
		public const int Submersible = 1;

	}
	public struct Ruin {
		
		public const int Boots = 2;
		public const int Heavy_Boots = 2;
		public const int Tires = 3;
		public const int AT_Tires = 2;
		public const int Threads = 1;
		public const int Helicopter = 1;
		public const int Propeller = 1;
		public const int Jet = 1;
		public const int Boat = -1;
		public const int Submersible = -1;

	}
	public struct Bridge {
		
		public const int Boots = 1;
		public const int Heavy_Boots = 1;
		public const int Tires = 1;
		public const int AT_Tires = 1;
		public const int Threads = 1;
		public const int Helicopter = 1;
		public const int Propeller = 1;
		public const int Jet = 1;
		public const int Boat = 1;
		public const int Submersible = 1;

	}
	public struct Building {//
		
		public const int Boots = 1;
		public const int Heavy_Boots = 1;
		public const int Tires = 1;
		public const int AT_Tires = 1;
		public const int Threads = 1;
		public const int Helicopter = 1;
		public const int Propeller = 1;
		public const int Jet = 1;
		public const int Boat = 1;
		public const int Submersible = 1;

	}
	public struct Water {//
		
		public const int Boots = -1;
		public const int Heavy_Boots = -1;
		public const int Tires = -1;
		public const int AT_Tires = -1;
		public const int Threads = -1;
		public const int Helicopter = 1;
		public const int Propeller = 1;
		public const int Jet = 1;
		public const int Boat = 1;
		public const int Submersible = 1;

	}
}
