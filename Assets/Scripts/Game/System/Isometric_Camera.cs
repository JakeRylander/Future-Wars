using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isometric_Camera : MonoBehaviour {
	
	new private Camera camera;
	
	//Refernce to Map Data
	public Game_Data data;
	
	//Mouse Movement Stuff
	private int Screen_Height;
	private int Screen_Width;
	
	private float Mouse_Top_Threshold;
	private float Mouse_Bottom_Threshold;
	private float Mouse_Left_Threshold;
	private float Mouse_Right_Threshold;
	
	//Camera Position and Rotation Information and Setting
	private Vector3 Current_Position;
	private Vector3 New_Position;
	
	private Quaternion Current_Rotation;
	private Quaternion New_Rotation;
	
	private bool Position_Changing;
	private int Position;
	
	//Camera Bounds
	private float LeftBound;
	private float RightBound;
	private float TopBound;
	private float BottomBound;
	
	private float New_LeftBound;
	private float New_RightBound;
	private float New_TopBound;
	private float New_BottomBound;
	
	private float Current_LeftBound;
	private float Current_RightBound;
	private float Current_TopBound;
	private float Current_BottomBound;
	
	//Zoom stuff
	private bool Zoom_Changing;
	private float Zoom_Change;
	private float Rotation_Change;
	
	private float Zoom_Position;
	private float Zoom_Rotation;
	
	//Camera Movement Stuff
	private float Time_Passed;
	private bool Not_Done;
	
	//Map Size Things
	private int Map_Size_X;
	private int Map_Size_Y;
	
	public State_Handler state;
	public float Speed;
	public float Move_Duration;
	
	void Calculate_Bounds(){
		
		Current_LeftBound = LeftBound;
		Current_RightBound = RightBound;
		Current_TopBound = TopBound;
		Current_BottomBound = BottomBound;
		
		switch (Position)
		{
			case 0: 
				LeftBound = -3.0f;
				RightBound = Map_Size_X - 10.0f;
				TopBound = Map_Size_Y - 10.0f;
				BottomBound = -3.0f;
				break;
			case 1:
				LeftBound = 5.0f;
				RightBound = Map_Size_X - 5.0f; 
				TopBound = Map_Size_Y - 10.0f;
				BottomBound = -5.0f;
				break;
			case 2:
				LeftBound = 10.0f;
				RightBound = Map_Size_X + 3.0f;
				TopBound = Map_Size_Y - 10.0f;
				BottomBound = -3.0f;
				break;
			case 3:
				LeftBound = 10.0f;
				RightBound = Map_Size_X + 5.0f; 
				TopBound = Map_Size_Y - 5.0f;
				BottomBound = 5.0f;
				break;
			case 4:
				LeftBound = 10.0f;
				RightBound = Map_Size_X + 3.0f;
				TopBound = Map_Size_Y + 3.0f;
				BottomBound = 10.0f;
				break;
			case 5:
				LeftBound = 5.0f;
				RightBound = Map_Size_X - 5.0f; 
				TopBound = Map_Size_Y + 5.0f;
				BottomBound = 10.0f;
				break;
			case 6:
				LeftBound = -3.0f;
				RightBound = Map_Size_X - 10.0f;
				TopBound = Map_Size_Y +3.0f;
				BottomBound = 10.0f;
				break;
			case 7:
				LeftBound = -5.0f;
				RightBound = Map_Size_X - 10.0f; 
				TopBound = Map_Size_Y - 5.0f;
				BottomBound = 5.0f;
				break;
			default:
				//You should never end up here, if you do, something went really wrong.
				break;
		}
		New_LeftBound = LeftBound;
		New_RightBound = RightBound;
		New_TopBound = TopBound;
		New_BottomBound = BottomBound;
		
	}
	
	private void Position_Set(int position){
		
		Position = position;
		Position_Changing = true;
		Current_Rotation = camera.transform.rotation;
		Calculate_Bounds();
		Camera_Movement();
	}
	
	private void Update_Zoom(bool zoom){
		
		if(zoom){
			
			Zoom_Change = -4;
			Rotation_Change = -25;
			
		}
		else{
			
			Zoom_Change = 4;
			Rotation_Change = 25;
			
		}
		
		New_Position = new Vector3 (transform.position.x, transform.position.y + Zoom_Change, transform.position.z);
		New_Rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + Rotation_Change,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z);
		
		Current_Position = camera.transform.position;
		Current_Rotation = camera.transform.rotation;
		
		Zoom_Rotation = transform.rotation.eulerAngles.x + Rotation_Change;
		
		Zoom_Changing = true;
		Time_Passed = 0f;
		Not_Done = true;
		
	}
	
	private void Camera_Movement(){
		
		switch (Position)
		{
			case 0: 
				New_Rotation = Quaternion.Euler(Zoom_Rotation,45,0);
				break;
			case 1:
				New_Rotation = Quaternion.Euler(Zoom_Rotation,0,0);
				break;
			case 2:
				New_Rotation = Quaternion.Euler(Zoom_Rotation,-45,0);
				break;
			case 3:
				New_Rotation = Quaternion.Euler(Zoom_Rotation,-90,0);
				break;
			case 4:
				New_Rotation = Quaternion.Euler(Zoom_Rotation,-135,0);
				break;
			case 5:
				New_Rotation = Quaternion.Euler(Zoom_Rotation,-180,0);
				break;
			case 6:
				New_Rotation = Quaternion.Euler(Zoom_Rotation,-225,0);
				break;
			case 7:
				New_Rotation = Quaternion.Euler(Zoom_Rotation,-270,0);
				break;
			default:
				//You should never end up here, if you do, something went really wrong.
				break;
		}
		Position_Changing = true;
		Time_Passed = 0f;
		Not_Done = true;
		
	}

	// Use this for initialization
	void Start () {	
		
		camera = GetComponent<Camera>();
	
		transform.position = new Vector3(-3.0f, 7.0f, -3.0f); //Starting Position (SW Unzoomed)
		
		Position = 0;
		
		Position_Changing = false;
		Zoom_Changing = false;
		
		Screen_Height = Screen.height;
		Screen_Width = Screen.width;
		
		Mouse_Top_Threshold = (Screen_Height/2.0f) + (Screen_Height/2.5f);
		Mouse_Bottom_Threshold = (Screen_Height/2.0f) - (Screen_Height/2.5f);
		Mouse_Left_Threshold = (Screen_Width/2.0f) - (Screen_Width/2.5f);
		Mouse_Right_Threshold = (Screen_Width/2.0f) + (Screen_Width/2.50f);
		
		Map_Size_X = data.Map_Size.x;
		Map_Size_Y = data.Map_Size.y;
		
		Current_Position = transform.position;
		Current_Rotation = transform.rotation;
		
		Zoom_Position = 7.0f;
		Zoom_Rotation = 30;
		
		Calculate_Bounds();
	}
	
	// Update is called once per frame
	void Update () {
		
		if ((state.State < 4)){
		
			if(Position_Changing){
				
				Time_Passed += Time.deltaTime / Move_Duration;

				camera.transform.rotation = Quaternion.Lerp(Current_Rotation, New_Rotation, Time_Passed);
				
				LeftBound = Mathf.Lerp(Current_LeftBound, New_LeftBound, Time_Passed);
				RightBound = Mathf.Lerp(Current_RightBound, New_RightBound, Time_Passed);
				BottomBound = Mathf.Lerp(Current_BottomBound, New_BottomBound, Time_Passed);
				TopBound = Mathf.Lerp(Current_TopBound, New_TopBound, Time_Passed);
				
				transform.position = new Vector3(Mathf.Clamp(transform.position.x, LeftBound, RightBound), 
										 transform.position.y,
										 Mathf.Clamp(transform.position.z, BottomBound, TopBound));
				
				if (Time_Passed > 1.0f) {
					Position_Changing = false;
					state.State = state.Previous_State;
				}
			}
			else if (Zoom_Changing){
				
				Time_Passed += Time.deltaTime / Move_Duration;

				camera.transform.position = Vector3.Lerp(Current_Position, New_Position, Time_Passed);
				camera.transform.rotation = Quaternion.Lerp(Current_Rotation, New_Rotation, Time_Passed);
				
				if (Time_Passed > 1.0f) {
					Zoom_Changing = false;
					state.State = state.Previous_State;
				}
			}
			
			//Outside threshold box for movement
			else if(Input.mousePosition.x > Mouse_Right_Threshold | Input.mousePosition.x < Mouse_Left_Threshold | Input.mousePosition.y > Mouse_Top_Threshold | Input.mousePosition.y < Mouse_Bottom_Threshold){
				
				//Reupdate Thresholds if screensize changed or something
				Screen_Height = Screen.height;
				Screen_Width = Screen.width;
				Mouse_Top_Threshold = (Screen_Height/2.0f) + (Screen_Height/2.5f);
				Mouse_Bottom_Threshold = (Screen_Height/2.0f) - (Screen_Height/2.5f);
				Mouse_Left_Threshold = (Screen_Width/2.0f) - (Screen_Width/2.5f);
				Mouse_Right_Threshold = (Screen_Width/2.0f) + (Screen_Width/2.50f);
				
				switch (Position)
				{
					
					case 0: //Southwest
						//Right Movement
						if(Input.mousePosition.x > Mouse_Right_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Right_Threshold)/1000;
							transform.position += new Vector3(x_transform, 0.0f, -1*x_transform);
						}
						//Left Movement
						if(Input.mousePosition.x < Mouse_Left_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Left_Threshold)/1000;
							transform.position += new Vector3(x_transform, 0.0f, -1*x_transform);
						}
						//Top Movement
						if(Input.mousePosition.y > Mouse_Top_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Top_Threshold)/1000;
							transform.position += new Vector3(y_transform, 0.0f, y_transform);
						}
						//Bottom Movement
						if(Input.mousePosition.y < Mouse_Bottom_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Bottom_Threshold)/1000;
							transform.position += new Vector3(y_transform, 0.0f, y_transform);
						}
						break;
					case 1: //South
						//Right Movement
						if(Input.mousePosition.x > Mouse_Right_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Right_Threshold)/1000;
							transform.position += new Vector3(x_transform, 0.0f, 0.0f);
						}
						//Left Movement
						if(Input.mousePosition.x < Mouse_Left_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Left_Threshold)/1000;
							transform.position += new Vector3(x_transform, 0.0f, 0.0f);
						}
						//Top Movement
						if(Input.mousePosition.y > Mouse_Top_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Top_Threshold)/1000;
							transform.position += new Vector3(0.0f, 0.0f, y_transform);
						}
						//Bottom Movement
						if(Input.mousePosition.y < Mouse_Bottom_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Bottom_Threshold)/1000;
							transform.position += new Vector3(0.0f, 0.0f, y_transform);
						}
						break;
					case 2: //Southeast
						//Right Movement
						if(Input.mousePosition.x > Mouse_Right_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Right_Threshold)/1000;
							transform.position += new Vector3(x_transform, 0.0f, x_transform);
						}
						//Left Movement
						if(Input.mousePosition.x < Mouse_Left_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Left_Threshold)/1000;
							transform.position += new Vector3(x_transform, 0.0f, x_transform);
						}
						//Top Movement
						if(Input.mousePosition.y > Mouse_Top_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Top_Threshold)/1000;
							transform.position += new Vector3(-1*y_transform, 0.0f, y_transform);
						}
						//Bottom Movement
						if(Input.mousePosition.y < Mouse_Bottom_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Bottom_Threshold)/1000;
							transform.position += new Vector3(-1*y_transform, 0.0f, y_transform);
						}
						break;
					case 3: //East
						//Right Movement
						if(Input.mousePosition.x > Mouse_Right_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Right_Threshold)/1000;
							transform.position += new Vector3(0.0f, 0.0f, x_transform);
						}
						//Left Movement
						if(Input.mousePosition.x < Mouse_Left_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Left_Threshold)/1000;
							transform.position += new Vector3(0.0f, 0.0f, x_transform);
						}
						//Top Movement
						if(Input.mousePosition.y > Mouse_Top_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Top_Threshold)/1000;
							transform.position += new Vector3(-1*y_transform, 0.0f, 0.0f);
						}
						//Bottom Movement
						if(Input.mousePosition.y < Mouse_Bottom_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Bottom_Threshold)/1000;
							transform.position += new Vector3(-1*y_transform, 0.0f, 0.0f);
						}
						break;
					case 4: //NorthEast
						//Right Movement
						if(Input.mousePosition.x > Mouse_Right_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Right_Threshold)/1000;
							transform.position += new Vector3(-1*x_transform, 0.0f, x_transform);
						}
						//Left Movement
						if(Input.mousePosition.x < Mouse_Left_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Left_Threshold)/1000;
							transform.position += new Vector3(-1*x_transform, 0.0f, x_transform);
						}
						//Top Movement
						if(Input.mousePosition.y > Mouse_Top_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Top_Threshold)/1000;
							transform.position += new Vector3(-1*y_transform, 0.0f, -1*y_transform);
						}
						//Bottom Movement
						if(Input.mousePosition.y < Mouse_Bottom_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Bottom_Threshold)/1000;
							transform.position += new Vector3(-1*y_transform, 0.0f, -1*y_transform);
						}
						break;
					case 5: //North
						//Right Movement
						if(Input.mousePosition.x > Mouse_Right_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Right_Threshold)/1000;
							transform.position += new Vector3(-1*x_transform, 0.0f, 0.0f);
						}
						//Left Movement
						if(Input.mousePosition.x < Mouse_Left_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Left_Threshold)/1000;
							transform.position += new Vector3(-1*x_transform, 0.0f, 0.0f);
						}
						//Top Movement
						if(Input.mousePosition.y > Mouse_Top_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Top_Threshold)/1000;
							transform.position += new Vector3(0.0f, 0.0f, -1*y_transform);
						}
						//Bottom Movement
						if(Input.mousePosition.y < Mouse_Bottom_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Bottom_Threshold)/1000;
							transform.position += new Vector3(0.0f, 0.0f, -1*y_transform);
						}
						break;
					case 6: //Northwest
						//Right Movement
						if(Input.mousePosition.x > Mouse_Right_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Right_Threshold)/1000;
							transform.position += new Vector3(-1*x_transform, 0.0f, -1*x_transform);
						}
						//Left Movement
						if(Input.mousePosition.x < Mouse_Left_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Left_Threshold)/1000;
							transform.position += new Vector3(-1*x_transform, 0.0f, -1*x_transform);
						}
						//Top Movement
						if(Input.mousePosition.y > Mouse_Top_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Top_Threshold)/1000;
							transform.position += new Vector3(y_transform, 0.0f, -1*y_transform);
						}
						//Bottom Movement
						if(Input.mousePosition.y < Mouse_Bottom_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Bottom_Threshold)/1000;
							transform.position += new Vector3(y_transform, 0.0f, -1*y_transform);
						}
						break;
					case 7: //West
						//Right Movement
						if(Input.mousePosition.x > Mouse_Right_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Right_Threshold)/1000;
							transform.position += new Vector3(0.0f, 0.0f, -1*x_transform);
						}
						//Left Movement
						if(Input.mousePosition.x < Mouse_Left_Threshold){
							var x_transform = (Input.mousePosition.x - Mouse_Left_Threshold)/1000;
							transform.position += new Vector3(0.0f, 0.0f, -1*x_transform);
						}
						//Top Movement
						if(Input.mousePosition.y > Mouse_Top_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Top_Threshold)/1000;
							transform.position += new Vector3(y_transform, 0.0f, 0.0f);
						}
						//Bottom Movement
						if(Input.mousePosition.y < Mouse_Bottom_Threshold){
							var y_transform = (Input.mousePosition.y - Mouse_Bottom_Threshold)/1000;
							transform.position += new Vector3(y_transform, 0.0f, 0.0f);
						}
						break;
					default:
						//You should never end up here, if you do, something went really wrong.
						break;
				}
		
			}
			
		//Set Position if out of Map Bounds
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, LeftBound, RightBound), 
										 transform.position.y,
										 Mathf.Clamp(transform.position.z, BottomBound, TopBound));	
		}
	}
}
