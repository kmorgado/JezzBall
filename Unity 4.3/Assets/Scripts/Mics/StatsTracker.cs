using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace QuizBoard
{

	public class StatsTracker: MonoBehaviour
	{
		// Static singleton property
		public static StatsTracker Instance { get; private set; }
		
		void Awake()
		{
			// Save a reference to the StatsTracker component as our singleton instance
			Instance = this;
		}

		public Dictionary<string, AnswerCell> currentStatList;

		public List<string> lol = new List<string>();

		public StatsTracker ()
		{
			currentStatList = new Dictionary<string, AnswerCell>();

			/*
			AnswerCell lol = new AnswerCell("rofl", true, 10);
			AnswerCell lol1 = new AnswerCell("lol", false, 10);
			AnswerCell lol2 = new AnswerCell("rofewwel", true, 10);
			currentStatList.Add("lol", lol);
			currentStatList.Add("lol1", lol1);
			currentStatList.Add("lol2", lol2);
			*/
		}


		public void TrackNewAnswer(AnswerCell answer)
		{
			lol.Add(answer.m_AnswerText);

			if(currentStatList.ContainsKey(answer.m_AnswerText))
			{
				//if the answer is already in the dictionary lets just increment the m_TimesAnswered variable
				currentStatList[answer.m_AnswerText].m_TimesAnswered++;
			}
			else
			{
				//Perform a Deep Copy so we dont lose the reference once it falls out of scope!
				AnswerCell newAnswer = new AnswerCell();
				newAnswer.m_AnswerText = answer.m_AnswerText;
				newAnswer.m_Difficulty = answer.m_Difficulty;
				newAnswer.m_IsCorrect = answer.m_IsCorrect;

				currentStatList.Add(newAnswer.m_AnswerText, newAnswer);
			}

		}


	}
}

