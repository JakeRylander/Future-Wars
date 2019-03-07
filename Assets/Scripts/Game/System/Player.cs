using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	//CommandingOfficer CO;	
	public Color Color_Identity;
	public string Player_Name;
	public int Funds;
	
	public Player(Color identity, string name){
		
		Color_Identity = identity;
		Player_Name = name;
		Funds = 0;
		
	}
}