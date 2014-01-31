using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject BeforeLoginMenu;
	public GameObject RegisterMenu;

	// Use this for initialization
	void Start () {
	
		//Screen.SetResolution(600,1240,true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region BeforeLogin Button Messages

	void CreateNew_BtnClick()
	{
		BeforeLoginMenu.SetActive(false);
		RegisterMenu.SetActive(true);
		//Application.LoadLevel(1);
	}

	void Login_BtnClick()
	{
		Application.LoadLevel(1);
	}

	#endregion

	void Back_RegisterBtn()
	{
		BeforeLoginMenu.SetActive(true);
		RegisterMenu.SetActive(false);
	}

}
