using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour {
	
	//References to External Unity Components
	public Game_Data data;
	public State_Handler state;
	
	//References to Units own Components
	public Animator base_animation;
	public SpriteRenderer base_renderer;
	
	public Animator color_animation;
	public SpriteRenderer color_renderer;
	
	//References to the Units own UI Displays
	public Text HP_Display;
	
	//Material Block Variable
	private MaterialPropertyBlock block;
	
	/***Unit Data for Game Purposes***/
	/**Unit Base information**/
	public UnitName Name {get; protected set;}
	public UnitType Type {get; protected set;}
	public UnitClass Class {get; protected set;}
	public UnitAttackType Attack_Type {get; protected set;}
	
	/** Stats **/
	//HP Stuff
	protected int Max_HP = 100;
	private int current_hp;
	public int Current_HP {get{return current_hp;} set{current_hp = value; if(value < 100){HP_Display.text = (value/10).ToString();} else{HP_Display.text = "";} if (value <= 0){ Destroy_Unit();}}}
	
	//Fuel Stuff
	public int Max_Fuel {get; protected set;}
	public int Current_Fuel {get; set;}
	
	//Movement Stuff
	public MovementType Movement_Type {get; protected set;}
	public Movement_Costs Movement_Costs {get; protected set;}
	public int Movement_Range {get; protected set;}
	public List<TileType> Walkable {get; protected set;}
	
	//Weapons
	//Main Weapon
	public Weapon Main_Weapon {get; set;}
	//Secondary Weapon
	public Weapon Secondary_Weapon {get; set;}
	
	//Defense Stuff
	public int Defense_Rating {get; protected set;}
	
	//Ownership Info
	public int Belongs_To_Player;
	public int Belongs_To_Team;
	
	//Internal Position
	public Vector2Int Position {get; set;}
	
	/**Unit Data for Internal Use**/
	//Animation Names
	protected string animation_name;
	protected string animation_zoom;
	
	protected bool Unit_Selected;
	protected Quaternion New_Rotation;
	
	protected bool Unit_Moved_This_Turn = false;
	
	//Unit Base Color
	protected Color Base_Color;
	protected Color Dimmed_Color;
	
	protected Color Base_Mesh;
	protected Color Dimmed_Mesh;
	
	/** Methods and what not **/
	//Move Unit to specified position.
	public void Move_To(Vector2Int pos){
		//Internal Position Set
		Position = pos;
		//Actual Worldspace Position Set
		transform.position = new Vector3 (pos.x+0.5f, transform.position.y, pos.y+0.5f);
	}

	//Adds to Map Data that a new Unit is in the game
	public void Add_Unit(){
		data.Add_Unit(gameObject);
	}
	
	//Plays the Animation passed as Parameter
	protected void Play_Animation(string animation_to_play){
		base_animation.Play (animation_name + animation_to_play + animation_zoom);
		color_animation.Play (animation_name + animation_to_play + animation_zoom + "_Color");
	}
	
	public void Set_Color_Values(){
		Base_Color = color_renderer.color;
		Dimmed_Color = new Color(Base_Color.r/4,Base_Color.g/4,Base_Color.b/4);

		Base_Mesh = base_renderer.color;
		Dimmed_Mesh = new Color(Base_Mesh.r/4,Base_Mesh.g/4,Base_Mesh.b/4);
	}
	
	//Set Color to Shader from Sprite Renderer
	public void Set_Color(SpriteRenderer renderer, Color color){
		
		block = new MaterialPropertyBlock();

		renderer.GetPropertyBlock(block);
		
		block.SetColor("_Color",color);
		
		renderer.SetPropertyBlock(block);
	}
	
	//Used when unit has no actions left for the turn.
	public void Dim_Unit(){
		Set_Color(base_renderer, Dimmed_Mesh);
		Set_Color(color_renderer, Dimmed_Color);
	}
	
	//Used when turn refreshes
	public void Undim_Unit(){
		Set_Color(base_renderer, Base_Mesh);
		Set_Color(color_renderer, Base_Color);
	}
	
	//Unit State Handler and Monobehaviour stuff
	//When Unit Selected
	void OnMouseDown(){
		
		//When its the turn of whoever this unit belongs to
		if (!Unit_Moved_This_Turn & data.Players_Turn == Belongs_To_Player){
		
			if (state.State == 0){
			
				//When Unit Clicked
				Debug.Log("Unit Clicked.");
				Play_Animation("Move_Left_");
				Unit_Selected = true;
				state.Set_Selected(gameObject);
			}	
		}
	}
	//Refreshed Unit AKA New Day
	public void New_Day(){
		Unit_Moved_This_Turn = false;
		Undim_Unit();
	}
	//Set Position Rotation based on Camera
	public void Position_Set(int position){
		
		switch (position)
		{
			case 0: 
				New_Rotation = Quaternion.Euler(0,45,0);
				break;
			case 1:
				New_Rotation = Quaternion.Euler(0,0,0);
				break;
			case 2:
				New_Rotation = Quaternion.Euler(0,-45,0);
				break;
			case 3:
				New_Rotation = Quaternion.Euler(0,-90,0);
				break;
			case 4:
				New_Rotation = Quaternion.Euler(0,-135,0);
				break;
			case 5:
				New_Rotation = Quaternion.Euler(0,-180,0);
				break;
			case 6:
				New_Rotation = Quaternion.Euler(0,-225,0);
				break;
			case 7:
				New_Rotation = Quaternion.Euler(0,-270,0);
				break;
			default:
				//You should never end up here, if you do, something went really wrong.
				break;
		}
		transform.rotation = New_Rotation;
	}
	
	//Update Zoom Level based on Camera
	public void Update_Zoom(bool zoom){
		if (zoom)
			animation_zoom = "Zoomed";
		
		else
			animation_zoom = "Default";
	}
	
	public void Destroy_Unit(){
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!Unit_Selected){
		
			Play_Animation("Idle_");

		}
		
		//Special Case for correct animation updating when zooming in and out
		if (state.State == 1 & Unit_Selected){
			Play_Animation("Move_Left_");
		}
			
		if (state.State == 3 & Unit_Selected){
			
			Play_Animation("Move_Left_");
			
			//Right Mouse button is used to deselect unit select (Back command basically)
			if (Input.GetMouseButtonDown(1)){
				
				Debug.Log("Unit Deselected");
				
				state.State = 0;
				Play_Animation("Idle_");
				Unit_Selected = false;
				state.Set_Selected(null);
			}
		}
		
		if (state.State == 4 & Unit_Selected){
			Debug.Log("Unit Finished it's action.");

			
			//Once finished moving
			state.State = 0;
			Play_Animation("Idle_");
			Unit_Selected = false;
			state.Set_Selected(null);
			Unit_Moved_This_Turn = true;
			Dim_Unit();
			
		}
	}
}

