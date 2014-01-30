using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		//Screen.SetResolution(600,1240,true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Login_BtnClick()
	{
		Application.LoadLevel(1);
	}
}
