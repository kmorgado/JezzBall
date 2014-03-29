using UnityEngine;
using System.Collections;

namespace QuizBoard
{
	public class QuizBoard : MonoBehaviour {

		public GameObject quizGrid;
		public GameObject ResultScreen;
		
		public UILabel CategoryNameLbl;
		public UILabel CorrectNumLbl;
		public UILabel WrongNumLbl;
		public UILabel TimerLbl;

		public UILabel CorrectLeftNumLbl;
		public GameObject ResetGridMsg;
		

		private int numCorrectCounter;
		private int numWrongCounter;

		private int numCorrectLeftCounter;
		


		private UILabel[] gridLabels;

		//Timer
		private float timeLeft = 70.0f;

		void Awake()
		{
		}
			
		void Start()
		{

			ResultScreen.SetActive(false);

			gridLabels = quizGrid.GetComponentsInChildren<UILabel>();

			QuizEngine.Instance.GenerateNewQuizBoard(gridLabels);

			if(QuizEngine.Instance.currentCategory != null)
			{
				CategoryNameLbl.text = QuizEngine.Instance.currentCategory.m_CategoryName;
			}
			
		}

		public void Update()
		{
			timeLeft -= Time.deltaTime;

			if(Input.GetKeyDown(KeyCode.Escape))
				Application.LoadLevel(0);

			if (timeLeft <= 0.0f)
			{
				// End the level here.

				///Social.ReportScore(numCorrectCounter - numWrongCounter, "CgkIzKra178EEAIQAg", (bool success) => {
					// handle success or failure
				//});


				ResultScreen.SetActive(true);

				ResultScreen.GetComponent<ResultsScreen>().PopulateResults();

				//Application.LoadLevel(0);

			}
			else
			{

				if(QuizEngine.Instance.lastUserInput != null)
				{
					if(QuizEngine.Instance.lastUserInput.m_IsCorrect)
					{
						numCorrectCounter++;
					}
					else
					{
						numWrongCounter++;
					}

					QuizEngine.Instance.lastUserInput = null;
				}

				if(QuizEngine.Instance.CheckBoardForAllWrongs())
				{
					//We have nothing but wrong answers we need to reset the board
					QuizEngine.Instance.GenerateNewQuizBoard(gridLabels);
				}

					numCorrectLeftCounter = QuizEngine.Instance.GetRemainingCorrectAnswers();

			}
		}

		public void OnGUI()
		{

			//Redraw grid
			foreach(UILabel lbl in gridLabels)
			{
				if(QuizEngine.Instance.gameBoard.ContainsKey(lbl.name))
				{
					lbl.text = QuizEngine.Instance.gameBoard[lbl.name].m_AnswerText;

					/*
					if(lbl.text.Contains(" "))
					{
						//lbl.text = lbl.text.Replace(" ","\n");

						lbl.maxLineCount = 2;
					
						//lbl.width = 160;
						//lbl.height = 128;
					}
					else
					{
						lbl.maxLineCount = 1;
						//lbl.width = 80;
						//lbl.height = 64;
					}
					*/
				}
			}

			//Redraw Stats
			CorrectNumLbl.text = numCorrectCounter.ToString();
			WrongNumLbl.text = numWrongCounter.ToString();

			CorrectLeftNumLbl.text = numCorrectLeftCounter.ToString();


			//Redraw Timer
			System.TimeSpan ts = System.TimeSpan.FromSeconds(timeLeft);
			TimerLbl.text = string.Format("{0:0}:{1:00}.{2:000}", ts.Minutes, ts.Seconds, ts.Milliseconds);


		}


		void RefreshGrid()
		{
			QuizEngine.Instance.GenerateNewQuizBoard(gridLabels);

			//Show Reset Message
			ResetGridMsg.SetActive(true);
			
			TweenAlpha alphaScript = ResetGridMsg.GetComponent<TweenAlpha>();
			TweenScale scaleScript = ResetGridMsg.GetComponent<TweenScale>();
			
			alphaScript.ResetToBeginning();
			alphaScript.PlayForward();
			
			scaleScript.ResetToBeginning();
			scaleScript.PlayForward();

			timeLeft  -= 10;
		}



			//String.Format ("{0:00}:{1:00}", displayMinutes, displaySeconds); 

  }
}
