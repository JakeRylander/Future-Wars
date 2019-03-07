using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class State_Handler : MonoBehaviour {
	
	//Reference to Map Data Script
	public Game_Data data;
	
	//Reference to Grid
	public Grid World_Grid;
	
	//State Value
	public int State {set; get;}
	public int Previous_State {set; get;}
	
	//Camera Values
	private int Camera_Position;
	private bool Zoomed;
	
	//Selected Overlay Data
	public Tilemap Overlay;
	public Tile[] Overlay_Tile;
	
	//Unit Handler Stuff
	private GameObject Selected_Unit;
	private Unit Selected_Unit_Script;
	
	private GameObject Target_Unit;
	private Unit Target_Unit_Script;
	
	/**UI References**/ 
	//Terrain UI Box
	public Text Terrain_Name;
	public Text Terrain_Description;
	
	//Lists for Moveable and Attackable Spaces on Selected Unit
	private List<Vector2Int> Walkable_Spaces = new List<Vector2Int>();
	private List<Vector2Int> Attackable_Spaces = new List<Vector2Int>();
	
	//Previous Position for backpedalling.
	private Vector2Int Previous_Position;
	
	//Global Accesible Variable used by the various PathFinding and Range Calculator algorithms
	private Vector3Int place;
	private Vector2Int to_position;
	
	//Check if Unit can Walk on this Tile
	private bool CanWalk(Vector2Int position){
		foreach(var item in Selected_Unit_Script.Walkable){
			Map_Tile tile_to_check = data.Get_Tile(position);
			if (item == tile_to_check.Type){
				return true;
			}
		}
		return false;
	}
	
	//Calculate Attack Range
	private void GetAttackRange(Vector2Int position, int Range){
		
		if (Range < 2){
			for (int i = 0; i < 4; i++){
				
				switch (i){ 
					case 0:
						to_position = position + Vector2Int.up;
						place = new Vector3Int(position.x, position.y+1, (int)Overlay.transform.position.y);
						break;
					case 1:
						to_position = position + Vector2Int.left;
						place = new Vector3Int(position.x-1,position.y, (int)Overlay.transform.position.y);
						break;
					case 2:
						to_position = position + Vector2Int.right;
						place = new Vector3Int(position.x+1,position.y, (int)Overlay.transform.position.y);
						break;
					case 3:
						to_position = position + Vector2Int.down;
						place = new Vector3Int(position.x,position.y-1, (int)Overlay.transform.position.y);
						break;
					default: //Never should end up here
						break;
				}
				//Checks if The Tile within the map.	
				if (data.Within_Map(to_position)){
				
					if(!(Attackable_Spaces.Contains(to_position))){
						Attackable_Spaces.Add(to_position);
						Overlay.SetTile(place,Overlay_Tile[1]);
					}
				}
			}
		}
	}
	
	//Calculate Path Possible and Displays the Overlay for walkable area
	//Function to call and Base case
	private void GetValidMoves(Vector2Int position, float? Movement){
		//add the tile unit curently on.
		place = new Vector3Int(position.x, position.y, (int)Overlay.transform.position.y);
		Overlay.SetTile(place,Overlay_Tile[0]);
		Walkable_Spaces.Add(position);
		
		GetValidMoves_Rec(position, Movement);
	}
	//Recursive Part
	private void GetValidMoves_Rec(Vector2Int position, float? Movement){
		
		if (!(Movement < 0)){			
			for (int i = 0; i < 4; i++){
				
				switch (i){ 
					case 0: //Checks Top Tile from Base
						to_position = position + Vector2Int.up;
						place = new Vector3Int(position.x, position.y+1, (int)Overlay.transform.position.y);
						break;
					case 1: //Checks Left Tile from Base
						to_position = position + Vector2Int.left;
						place = new Vector3Int(position.x-1,position.y, (int)Overlay.transform.position.y);
						break;
					case 2: //Checks Right Tile from Base
						to_position = position + Vector2Int.right;
						place = new Vector3Int(position.x+1,position.y, (int)Overlay.transform.position.y);
						break;
					case 3: //Checks Bottom Tile from Base
						to_position = position + Vector2Int.down;
						place = new Vector3Int(position.x,position.y-1, (int)Overlay.transform.position.y);
						break;
					default: //Never should end up here
						break;
				}
				//Checks if The Tile within the map. As too not show movement outside the game confines
				if (data.Within_Map(to_position)){
					var Movement_Cost = Selected_Unit_Script.Movement_Costs.Get_Cost(data.Get_Tile(to_position).Type); //Calcuate Movement Cost based on the Unit Movement Type
					if(CanWalk(to_position) & (Movement >= Movement_Cost)){ //Check if unit can legally walk into the tile and if it has enough movement left to do so
						
						if(!(Walkable_Spaces.Contains(to_position))){
							
							//If friendly unit on space
							if(data.IsThereLandUnitAt(to_position) & (data.GetUnitAtPositionTeam(to_position) == Selected_Unit_Script.Belongs_To_Team)){
								Overlay.SetTile(place,Overlay_Tile[0]);
								GetValidMoves_Rec(to_position, Movement - Movement_Cost);
							}
							//enemy unit (block movement)
							else if (data.IsThereLandUnitAt(to_position) & !(data.GetUnitAtPositionTeam(to_position) == Selected_Unit_Script.Belongs_To_Team)){
								
								//Does nothing~
							}
							//free space
							else{
								Walkable_Spaces.Add(to_position);
								Overlay.SetTile(place,Overlay_Tile[0]);
								GetValidMoves_Rec(to_position, Movement - Movement_Cost);
							}
						}
					}
				}
			}
		}
	}
	
	//Selected Unit Handler
	public void Set_Selected(GameObject Unit){
		
		if (Unit == null){
			Selected_Unit = Unit;
			Overlay.ClearAllTiles();
			Walkable_Spaces.Clear();
		}
		else{
			
			Selected_Unit = Unit;
			Selected_Unit_Script = Unit.GetComponent<Unit> ();

			//Take Unit Movement and create the moveable area and the list with the coordinated it can move into.
			GetValidMoves(Selected_Unit_Script.Position, Selected_Unit_Script.Movement_Range);
	
			State = 2;
		}
	}
	
	//Set Target
	public void Set_Target(GameObject Unit){
		Target_Unit = Unit;
		Target_Unit_Script = Unit.GetComponent<Unit> ();
	}
	
	//Zoom Setters and Getters
	public void Set_Zoomed(bool boolean){
		Zoomed = boolean;
	}
	
	public bool Get_Zoomed(){
		return Zoomed;
	}
	
	private void Check_Menu(){
		if (Input.GetKeyDown(KeyCode.Escape) & State == 0){
			State = 6;
		}
		else if (Input.GetKeyDown(KeyCode.Escape)){
			State = 0;
		}
	}
	
	private void Check_Unit_Menu(){
		if (Input.GetMouseButtonDown(1) & State == 8){
			State = 3;
			Selected_Unit_Script.Move_To(Previous_Position);
			print("unit deselected");
			print(Selected_Unit_Script);
		}
	}
	
	private void Check_Change_Camera_Position(int state){
		if(Input.GetKeyDown("a")){
			Change_Camera_Position("right");
			Previous_State = state;
		}
		else if (Input.GetKeyDown("d")){
			Change_Camera_Position("left");
			Previous_State = state;
		}
		else if (Input.GetKeyDown("s") & Zoomed){
			Change_Camera_Zoom("unzoom");
			Previous_State = state;
		}
		else if (Input.GetKeyDown("w") & !Zoomed){
			Change_Camera_Zoom("zoom");
			Previous_State = state;
		}
	}
	
	private void Change_Camera_Zoom(string zoom_value){
		
		if (zoom_value == "unzoom"){
			Zoomed = false;
		}
		else{
			Zoomed = true;
		}
		State = 1;
		BroadcastMessage("Update_Zoom", Zoomed);
	}
	
	private void Change_Camera_Position(string side){
		
		if (side == "left"){
			if (Camera_Position == 0){
				Camera_Position = 7;
			}
			else{
				Camera_Position = Camera_Position - 1;
			}
		}
		else if(side == "right"){
			if (Camera_Position == 7){
				Camera_Position = 0;
			}
			else{
				Camera_Position = Camera_Position + 1;
			}
		}
		State = 1;
		BroadcastMessage("Position_Set", Camera_Position);
		//Do the same for units, buildings, etc so they know to update
	}

	private bool Set_Current_Player_Turn(){
		if (data.Players_Turn + 1 <= data.Max_Players){
			data.Players_Turn = data.Players_Turn + 1;
			return false; //No new Day
		}
		else{
			data.Players_Turn =  1;
			return true; //New Day Player 1 goes again	
		}
	}
	
	private void Update_MouseOver_Window_Terrain(){
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 worldPoint = ray.GetPoint(-ray.origin.y / ray.direction.y);

		Vector2Int position = new Vector2Int((int)worldPoint.x, (int)worldPoint.z);
		
		if (data.Within_Map(position)){
			Terrain_Name.text = data.Get_Tile(position).Name;
			Terrain_Description.text = data.Get_Tile(position).Description;
		}
	}
	
	// Use this for initialization
	void Start () {
		
		State = 0;
		Camera_Position = 0;
		Zoomed = false;
		//State = 0 | Idle (AKA Moving through the Map, no Unit clicked, nothing, base state that goes to very other.)
		//State = 1 | Camera either changing orientation or changing zoom level.
		//State = 2 | Unit Clicked/Selected (Prevent Selection of any other unit, buildings, menu, etc.)
		//State = 3 | Unit Selected and Waiting for Target.
		//State = 4 | Unit Ended Turn on Space.
		//State = 5 | Target Selected (Get whats at the tile I.E. if Unit (Enemy or Friendly), Building, Etc.
		//State = 6 | Main Menu Open
		//State = 7 | Turn Over (Also checks if a full cycle done to refresh fuel, units, etc.)
		//State = 8 | Unit moved and opens menu to select action.
		//State = 9 | Selected to Attack something (Displays attack range and hide unit menu) And move to state 10
		//State = 10 | Waits to select attack target or backpedal to 8.
	}
	
	// Update is called once per frame
	void Update () {
		
		if (State == 0){
			Check_Change_Camera_Position(State);
			Check_Menu();
			Update_MouseOver_Window_Terrain();
		}
		
		else if (State == 6){
			Check_Menu();
		}
		
		else if (State == 2){
			//Unit has been Selected Waiting to Select Target
			State = 3;
		}
		else if (State == 3){
			Check_Change_Camera_Position(State);
			if (Input.GetMouseButtonDown(0)){
				
				//Shenanigans to see what spot on the map we clicked with the mouse
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				Vector3 worldPoint = ray.GetPoint(-ray.origin.y / ray.direction.y);
				
				Vector2Int position = new Vector2Int((int)worldPoint.x, (int)worldPoint.z);
				//Check if where clicked is the same unit already selected (Special abilities I.E. Rig build temp airport)
				//Check if within movement Range.
				if (Walkable_Spaces.Contains(position)){
					
					//If no other unit
					if (!data.IsThereLandUnitAt(position) | position == Selected_Unit_Script.Position){ //If there is no unit nor Special Tile (I.E. Missile Silo) (Unit simply moves to the spot)
						
						//Move Unit to that position
						//var tile = data.Get_Tile(position.x, position.y);
						Previous_Position = Selected_Unit_Script.Position;
						Selected_Unit_Script.Move_To(position);
						State = 8;
					}
				}
			}
		}
		else if (State == 7){
			//Refresh units being able to move and update Day.
			if (Set_Current_Player_Turn()){
				data.Day_Number = data.Day_Number + 1;
				BroadcastMessage("New_Day");
				State = 0;
			}
			else {
				State = 0;
			}
		}
		else if (State == 8){
			Check_Unit_Menu();
		}
		else if (State == 9){
			GetAttackRange(Selected_Unit_Script.Position, 1);
			State = 10;
		}
		
		else if (State == 10){
			
			if (Input.GetMouseButtonDown(0)){
				
				//Shenanigans to see what spot on the map we clicked with the mouse
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				Vector3 worldPoint = ray.GetPoint(-ray.origin.y / ray.direction.y);
				
				Vector2Int position = new Vector2Int((int)worldPoint.x, (int)worldPoint.z);
				//Check if enemy unit at clicked space with attack range
				if (Attackable_Spaces.Contains(position)){
					//If there is another unit and not allied (on the same team) (AKA An enemy)
					if (data.IsThereLandUnitAt(position) & !(data.GetUnitAtPositionTeam(position) == Selected_Unit_Script.Belongs_To_Team)){ 

						//Do the whole attack animation and calcutae damage and what not.
						print("attacked an enemy");
						
						/** DAMAGE CALCULATION FORMULA SHENANIGANS START HERE**/
						
						float weapon_damage = (float)Selected_Unit_Script.Main_Weapon.Base_Strength;
						float attackerhp_modifier = ((float)Selected_Unit_Script.Current_HP/100);  //deals less damage the more damaged the unit is I.E. 40HP = 40% Modifier or 60% less damage.
						float Defender_value = (float)Target_Unit_Script.Defense_Rating + (data.Get_Tile(position).Defense_Rating * 10);
						float defenderhp_modifier = ((float)Target_Unit_Script.Current_HP/100);
						
						int damage_dealt = (int)((weapon_damage * attackerhp_modifier) - (Defender_value * defenderhp_modifier));
						
						
						Target_Unit_Script.Current_HP = Target_Unit_Script.Current_HP - damage_dealt;
						
						//Counter attack shenaigans (TO DO: conditions if unit can counter attack or not);
						
						weapon_damage = (float)Target_Unit_Script.Main_Weapon.Base_Strength;
						attackerhp_modifier = ((float)Target_Unit_Script.Current_HP/100);  //deals less damage the more damaged the unit is I.E. 40HP = 40% Modifier or 60% less damage.
						Defender_value = (float)Selected_Unit_Script.Defense_Rating + (data.Get_Tile(Selected_Unit_Script.Position).Defense_Rating * 10);
						defenderhp_modifier = ((float)Selected_Unit_Script.Current_HP/100);
						
						damage_dealt = (int)((weapon_damage * attackerhp_modifier) - (Defender_value * defenderhp_modifier));
						
						
						Selected_Unit_Script.Current_HP = Selected_Unit_Script.Current_HP - damage_dealt;
						/**
						
						This entire part here needs to call a new scene which will carry out the fight animation based on the units carrying it out.
						
						Unit initiating attack damges first using  formula like this:
						
						% Damage Dealt = (Weapon Base Damage * CO Modifier/100) * Unit HP/100 * (Enemy Defense Value * CO Modifier * Terrain Modifier * Enemy HP/100)
						
						The enemy that got attacked can counter attack if:
						
							a). The attack was direct (Can't counter attack indirect unless in specific scenarios)
							b). The unit that got attacked survived and can legally attack the unit that attacked it if it was initiating.
							c). Counter Attack Damage uses same formula as above, but using the HP of the Unit AFTER it got attacked.
						
						**/
						
						//Clears Target Unit (Selected Unit done from inside the selected unit when switched to state 4)
						Target_Unit = null;
						Target_Unit_Script = null;
						State = 4;
						Attackable_Spaces.Clear();
					}
				}
			}
			if (Input.GetMouseButtonDown(1)){
				
				//Backpedal to State 8, Clear overlay and put move range again.
				Overlay.ClearAllTiles();
				Attackable_Spaces.Clear();
				
				//BUG here, fix, cause not counting where friendly units are to walk through them
				foreach (var position in Walkable_Spaces){
					var localPlace = (new Vector3Int(position.x, position.y, (int)Overlay.transform.position.y));
					Overlay.SetTile(localPlace,Overlay_Tile[0]);
				}
				State = 8;
			}
		}
	}
}
