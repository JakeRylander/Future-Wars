using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {
	
	//Reference to Menu
	public GameObject Menu;
	
	public GameObject Unit_Menu;
	
	public State_Handler state;
	
	private bool Menu_Open;
	private bool Unit_Menu_Open;

	// Use this for initialization
	void Start () {
		
		Menu_Open = false;
		Menu.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (state.State == 6 & !Menu_Open){
			Menu.SetActive(true);
			Menu_Open = true;
		}
		
		else if (!(state.State == 6) & Menu_Open){
			Menu.SetActive(false);
			Menu_Open = false;
		}
		
		else if (state.State == 8 & !Unit_Menu_Open){
			Unit_Menu.SetActive(true);
			Unit_Menu_Open = true;
		}
		
		else if (!(state.State == 8) & Unit_Menu_Open){
			Unit_Menu.SetActive(false);
			Unit_Menu_Open = false;
		}
	}
}

