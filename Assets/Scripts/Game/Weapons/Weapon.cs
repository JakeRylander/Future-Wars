using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon {

	public string Name {get; private set;}
	public int Base_Strength {get; private set;}
    public int? Max_Ammo {get; private set;}
    public int? Current_Ammo {get; set;}

	//Base Constructor
	public Weapon (string name, int strength, int? max){
		Name = name;
		Base_Strength = strength;
		Max_Ammo = max;
		Current_Ammo = max;
	}
	
	//Copy Constructor
	public Weapon (Weapon other){
		Name = other.Name;
		Base_Strength = other.Base_Strength;
		Max_Ammo = other.Max_Ammo;
		Current_Ammo = other.Max_Ammo;
	}
	
	/**Static Declarations for Global Game usage and copying.**/
	//FootSoldiers
	public static Weapon Assault_Rifle = new Weapon ("Assault Rifle",50,null);
	public static Weapon Rocket_Launcher = new Weapon ("Rocket Launcher", 100, 3);
}