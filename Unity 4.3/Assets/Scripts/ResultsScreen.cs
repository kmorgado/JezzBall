using System.Collections;
using System.Collections.Generic;
using QuizBoard;
using UnityEngine;

namespace QuizBoard
{

public class ResultsScreen: MonoBehaviour
{
		public GameObject scoreRow_prefab;        // prefab of row to clone
		public GameObject scrollPanel;        // prefab of row to clone

		public UILabel CategoryLabel;
		public UILabel TotalLabel;

		private int totalScore;

		public ResultsScreen ()
		{
		}

		void Start ()
		{

		}

		void Update ()
		{
				
		}

		public void PopulateResults ()
		{
			GameObject.Find ("GameBoard").SetActive(false);

			//StatsTracker.Instance.currentStatList

			//myList.Sort((firstPair,nextPair) =>
			//            {
			//	return firstPair.Value.m_Difficulty.CompareTo(nextPair.Value.m_Difficulty);
			//}
			//);
			//L.orderby(a=>a.x).thenby(a=>a.y);

			CategoryLabel.text = QuizEngine.Instance.currentCategory.m_CategoryName;

		
			foreach (KeyValuePair<string, AnswerCell> entry in GetSortedList()) {
					

						GameObject go = NGUITools.AddChild (scrollPanel, scoreRow_prefab);
						UILabel[] temp = go.GetComponentsInChildren<UILabel> ();

						//While we are in here calculate the score
				
						if (entry.Value.m_IsCorrect)
						{
								temp [1].color = new Color (.18f, .8f, .44f);
								totalScore += entry.Value.m_Difficulty;
						}
						else
						{
								temp [1].color = new Color (.90f, .29f, .23f);
								totalScore -= entry.Value.m_Difficulty;
						}
					 

						temp [0].text = entry.Value.m_TimesAnswered.ToString();
						temp [1].text = entry.Value.m_AnswerText;
						temp [2].text = entry.Value.m_Difficulty.ToString();


					
				}

			//Now that the score is calculated lets set it to the label
			TotalLabel.text = totalScore.ToString();
		
		
		}


		Dictionary<string, AnswerCell> GetSortedList()
		{
			List<KeyValuePair<string, AnswerCell>> myList = new List<KeyValuePair<string, AnswerCell>>(StatsTracker.Instance.currentStatList);
			myList.Sort(
				delegate(KeyValuePair<string, AnswerCell> a,
			         KeyValuePair<string, AnswerCell> b)
				{
				return a.Value.m_Difficulty.CompareTo(b.Value.m_Difficulty);
			}
			);

			return StatsTracker.Instance.currentStatList;
		}


		/// <summary>
		///			BUTTON CODE!
		/// </summary>

		public void MainMenuBtn_Click()
		{
			Application.LoadLevel(0);
		}


		public void NewCatBtn_Click()
		{

		}
		
		public void ReplayBtn_Click()
		{
			//Reset the board and the engine
			Application.LoadLevel(1);
		}



}
}
