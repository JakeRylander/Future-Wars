using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game_Data : MonoBehaviour {

	//Refernce to State Handler
	public State_Handler state;
	
	//Refernce to Displayed Day
	public Text Day_Display;
	public Text Player_Display;
	
	//Use to Reference Units
	private Unit unit_script;
	
	//List of Data of the active players in order of how they go.
	public List<Player> Player_List = new List<Player>();
	
	/**Map Data**/
	//Size
	public Vector2Int Map_Size {get; set;}
	//Tile Data
	public Map_Tile[,] Map {get; set;}
	
	//Current Turn
	//Actual Variable
	private int day_number;
	//Special Handler to also update Displayed Day.
	public int Day_Number {get{return day_number;} set{day_number = value; Day_Display.text = "Day " + value.ToString();}}
	
	//Max Players;
	public int Max_Players {get; set;}
	
	//Current Player
	private int players_turn;
	//Special Handler to also update Current Player.
	public int Players_Turn {get{return players_turn;} set{players_turn = value; Player_Display.text = "Current Player " + value.ToString(); Player_Display.color = Player_List[value-1].Color_Identity;}}
	
	//Arrays for Unit Positions
	private List<GameObject> Land_Units = new List<GameObject>();
	private List<GameObject> Air_Units = new List<GameObject>();

	//Tile Get
	public Map_Tile Get_Tile(Vector2Int position){
		return Map[position.y,position.x];
	}
	
	//Add Unit to List
	public void Add_Unit(GameObject unit){
		//Gotta do a Check if Air or Land.
		Land_Units.Add(unit);
	}
	
	//Checks if there is a Land Unit at the specified Position
	public bool IsThereLandUnitAt(Vector2Int pos){
		
		foreach (var unit in Land_Units){
			
			unit_script = unit.GetComponent<Unit> ();
			
			if(unit_script.Position == pos){
				return true;
			}
		}
		return false;
	}
	
	public int GetUnitAtPositionTeam(Vector2Int pos){
		
		foreach (var unit in Land_Units){
			unit_script = unit.GetComponent<Unit> ();
			if(unit_script.Position == pos){
				state.Set_Target(unit);
				return unit_script.Belongs_To_Team;
			}
		}
		return -1;
	}
	
	//Add a New Player with the specified Data
	public void Add_Player(Color identity, string Player_Name){
		Player NewPlayer = new Player(identity, name);
		Player_List.Add(NewPlayer);
	}
	
	public void Set_Active_Map(Map_Tile[,] map){
		
		Map = map;
		Map_Size = new Vector2Int (map.GetLength(0), map.GetLength(1));
		
	}
	
	public bool Within_Map(Vector2Int position){
		return ((position.x >= 0) & (position.x < Map_Size.x) & (position.y >= 0) & (position.y < Map_Size.y));
	}
}
