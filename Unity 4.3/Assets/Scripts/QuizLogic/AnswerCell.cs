using System;

public class AnswerCell
{
	//Text for the cell
	public string m_AnswerText;

	//Is answer correct for the current category?
	public bool m_IsCorrect;
	
	//1-10 On Average how difficult is it to guess this answer
	public int m_Difficulty;

	public int m_TimesAnswered = 1;

	public AnswerCell ()
	{
		//m_AnswerText = "Test";
		//m_IsCorrect = false;
		//m_Difficulty = 1;
	}

	public AnswerCell (string answerText, bool isCorrect, int difficulty)
	{
		m_AnswerText = answerText;
		m_IsCorrect = isCorrect;
		m_Difficulty = difficulty;
	}

}

