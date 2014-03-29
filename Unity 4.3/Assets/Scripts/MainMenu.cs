using UnityEngine;
using System.Collections;

using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MainMenu : MonoBehaviour {

	public GameObject AdManager;

	public GameObject HomeMenu;
	public GameObject CategoryMenu;

	public GameObject SubCategory_DrugsMenu;
	public GameObject SubCategory_SportsMenu;
	public GameObject SubCategory_EroticMenu;
	public GameObject SubCategory_NatureMenu;
	
	private enum CurrentScreen {
	
		MainMenu = 0,
		Settings,
		Categories,
		Category_Drug,
		Category_Sports,
		Category_Erotic,
		Category_Nature

	}

	private CurrentScreen _currentScreen = CurrentScreen.MainMenu;
	


	/*
	//Before Login Items
	private GameObject LoginBtn;

	//Register Items
	private GameObject UsernameField;
	private GameObject EmailField;
	private GameObject PasswordField;
	private GameObject PasswordConfirmField;
	private GameObject RegisterBtn;
	
	*/

	// Use this for initialization
	void Start () {
	
		//Screen.SetResolution(600,1240,true);

		/*
		//Setup Before Login Screen
		LoginBtn = GameObject.Find("LoginBtn");

		Tween_BeforeLoginScreen();

		UsernameField = GameObject.Find("UserName_Field");
		EmailField = GameObject.Find("EmailAddr_Field");
		PasswordField = GameObject.Find("Password_Field");
		PasswordConfirmField = GameObject.Find("PasswordConfirm_Field");
		RegisterBtn = GameObject.Find("RegisterBtn");

		RegisterMenu.SetActive(false);
		HomeMenu.SetActive(false);
		*/

		#if UNITY_ANDROID && !UNITY_EDITOR
		AdManager.SetActive(true);
		
		
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		
		// sign out
		//((PlayGamesPlatform) Social.Active).SignOut();
		
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();
		
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
			
			//If we loaded an ID we can log in
			//BeforeLoginMenu.SetActive(false);
			//HomeMenu.SetActive(true);
			
		});
		
		#endif

	}

// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Escape))
		   CategoryBack_BtnClick();

	}

	#region BeforeLogin Button Messages

	void CreateNew_BtnClick()
	{
//		BeforeLoginMenu.SetActive(false);
		//RegisterMenu.SetActive(true);

		//Tween_RegisterScreen();

		//Application.LoadLevel(1);
	}

	void Login_BtnClick()
	{
		//BeforeLoginMenu.SetActive(false);
		//HomeMenu.SetActive(true);
	}

	#endregion

	void Back_RegisterBtn()
	{
//		BeforeLoginMenu.SetActive(true);
	//	RegisterMenu.SetActive(false);

		//Tween_BeforeLoginScreen();

	}

	void Play_BtnClick()
	{
		CategoryMenu.SetActive(true);
		HomeMenu.SetActive(false);

		CategoryMenu.GetComponentInChildren<TweenPosition>().ResetToBeginning();
		CategoryMenu.GetComponentInChildren<TweenPosition>().PlayForward();

		_currentScreen = CurrentScreen.Categories;
	}


	void Random_BtnClick()
	{
		QuizEngine.Instance.currentCategory = new Category();
		QuizEngine.Instance.currentCategory.m_CategoryName = "Marijuana Slang";
		QuizEngine.Instance.currentCategory.m_CategoryPath = "Category_MarijuanaSlang";
		
		Application.LoadLevel(1);
	}
	
	void Scores_BtnClick()
	{
		// show leaderboard UI
		Social.ShowLeaderboardUI();
	}

	void Settings_BtnClick()
	{
	}

	void Rate_BtnClick()
	{

	}



	/////////////////////
	/// CATEGORY BUTTONS
	//////////////////

	void CategoryBack_BtnClick()
	{
		if(_currentScreen == CurrentScreen.Categories)
		{
			HomeMenu.SetActive(true);
			CategoryMenu.SetActive(false);

			_currentScreen = CurrentScreen.MainMenu;
		}
		else if(_currentScreen != CurrentScreen.Categories)
		{
			if(_currentScreen == CurrentScreen.Category_Drug)
				SubCategory_DrugsMenu.SetActive(false);
			if(_currentScreen == CurrentScreen.Category_Sports)
				SubCategory_SportsMenu.SetActive(false);
			if(_currentScreen == CurrentScreen.Category_Erotic)
				SubCategory_EroticMenu.SetActive(false);
			if(_currentScreen == CurrentScreen.Category_Nature)
				SubCategory_NatureMenu.SetActive(false);
				
			CategoryMenu.SetActive(true);

			CategoryMenu.GetComponentInChildren<TweenPosition>().ResetToBeginning();
			CategoryMenu.GetComponentInChildren<TweenPosition>().PlayForward();

			_currentScreen = CurrentScreen.Categories;
		}
		
	}

	/////////////////////
	/// DRUG CATEGORY BUTTONS
	//////////////////

	void CategoryDrugs_BtnClick()
	{
		CategoryMenu.SetActive(false);
		SubCategory_DrugsMenu.SetActive(true);

		SubCategory_DrugsMenu.GetComponentInChildren<TweenPosition>().ResetToBeginning();
		SubCategory_DrugsMenu.GetComponentInChildren<TweenPosition>().PlayForward();


		_currentScreen = CurrentScreen.Category_Drug;
	}


	void CategoryDrug_BeerBrands_BtnClick()
	{
		QuizEngine.Instance.currentCategory = new Category();
		QuizEngine.Instance.currentCategory.m_CategoryName = "Brands of Beer";
		QuizEngine.Instance.currentCategory.m_CategoryPath = "Category_BrandsOfBeer";

		Application.LoadLevel(1);
	}

	void CategoryDrug_PotSlang_BtnClick()
	{
		QuizEngine.Instance.currentCategory = new Category();
		QuizEngine.Instance.currentCategory.m_CategoryName = "Marijuana Slang";
		QuizEngine.Instance.currentCategory.m_CategoryPath = "Category_MarijuanaSlang";

		Application.LoadLevel(1);
	}



	/////////////////////
	/// Sports CATEGORY BUTTONS
	//////////////////
	
	void CategorySports_BtnClick()
	{
		CategoryMenu.SetActive(false);
		SubCategory_SportsMenu.SetActive(true);
		
		SubCategory_SportsMenu.GetComponentInChildren<TweenPosition>().ResetToBeginning();
		SubCategory_SportsMenu.GetComponentInChildren<TweenPosition>().PlayForward();
		
		
		_currentScreen = CurrentScreen.Category_Sports;
	}
	
	
	void CategorySports_BeerBrands_BtnClick()
	{
		QuizEngine.Instance.currentCategory = new Category();
		QuizEngine.Instance.currentCategory.m_CategoryName = "Superbowl Champions";
		QuizEngine.Instance.currentCategory.m_CategoryPath = "Category_Superbowl";
		
		Application.LoadLevel(1);
	}

	/////////////////////
	/// Nature CATEGORY BUTTONS
	//////////////////
	
	void CategoryNature_BtnClick()
	{
		CategoryMenu.SetActive(false);
		SubCategory_NatureMenu.SetActive(true);
		
		SubCategory_NatureMenu.GetComponentInChildren<TweenPosition>().ResetToBeginning();
		SubCategory_NatureMenu.GetComponentInChildren<TweenPosition>().PlayForward();
		
		
		_currentScreen = CurrentScreen.Category_Nature;
	}

	/////////////////////
	/// Erotic CATEGORY BUTTONS
	//////////////////
	
	void CategoryErotic_BtnClick()
	{
		CategoryMenu.SetActive(false);
		SubCategory_EroticMenu.SetActive(true);
		
		SubCategory_EroticMenu.GetComponentInChildren<TweenPosition>().ResetToBeginning();
		SubCategory_EroticMenu.GetComponentInChildren<TweenPosition>().PlayForward();
		
		
		_currentScreen = CurrentScreen.Category_Erotic;
	}
	

	/*

	void Tween_BeforeLoginScreen()
	{
		LoginBtn.transform.localPosition = new Vector3(0,-740,0);
		SpringPosition.Begin(LoginBtn, new Vector3(0,-225.5184f,0), 10);
	}

	void Tween_RegisterScreen()
	{
		UsernameField.transform.localPosition = new Vector3(-658,121,0);
		SpringPosition.Begin(UsernameField, new Vector3(0,121,0), 10);

		EmailField.transform.localPosition = new Vector3(-658,24.51586f,0);
		SpringPosition.Begin(EmailField, new Vector3(0,24.51586f,0), 10);


		PasswordField.transform.localPosition = new Vector3(658,-95.79557f,0);
		SpringPosition.Begin(PasswordField, new Vector3(0,-95.79557f,0), 10);

		PasswordConfirmField.transform.localPosition = new Vector3(658,-178.5095f,0);
		SpringPosition.Begin(PasswordConfirmField, new Vector3(0,-178.5095f,0), 10);


		RegisterBtn.transform.localPosition = new Vector3(0,-582.0433f,0);
		SpringPosition.Begin(RegisterBtn, new Vector3(0,-329,0), 10);
	}
*/
}
