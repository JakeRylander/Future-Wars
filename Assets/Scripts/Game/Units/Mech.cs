using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : Foot_Soldier {
	
	//Initial Constructor
	public Mech(){
		
		
	}
	
	// Use this for initialization
	void Start () {
		
		//Starting Unit Information
		Name = UnitName.AT_Infantry;
		Movement_Type = MovementType.Heavy_Boots;
		Attack_Type = UnitAttackType.Direct;
		Movement_Range = 2;
		Movement_Costs = new Movement_Costs(Movement_Costs.Heavy_Boots); //Move to a Set and Get built into Movement_Type since they go hand in hand.
		
		Current_HP = Max_HP;
		
		//Weapon
		Main_Weapon = new Weapon(Weapon.Assault_Rifle);
		//Secondary_Weapon = new Weapon(Weapon.Rocket_Launcher);
		
		//Defensive Rating
		Defense_Rating = Armor_Constants.Heavy_Outfit;
		
		//Position Set based on where it was placed.
		Position = new Vector2Int((int)(transform.position.x - 0.5),(int)(transform.position.z - 0.5));
		
		//Stores Color Values
		Set_Color_Values();
		
		//Sets the Color to the Material
		Set_Color(color_renderer, Base_Color);
		
		//Animation Stuff
		animation_name = "Mech_";
		animation_zoom = "Default";
	
		//PLay Idle Animation
		Play_Animation("Idle_");
		
		//Add Unit to Map Data
		Add_Unit();
	}
}