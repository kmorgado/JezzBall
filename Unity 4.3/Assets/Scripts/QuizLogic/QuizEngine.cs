using System;
using System.Collections.Generic;
using QuizBoard;
using UnityEngine;

public class QuizEngine: Singleton<QuizEngine>
{

	public Category currentCategory;

	public Dictionary<string, AnswerCell> gameBoard = new Dictionary<string, AnswerCell>();

	public AnswerCell lastUserInput = null;

	//private string currentCategory = "Category_MarijuanaSlang";


	public QuizEngine ()
	{
	
	}

	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}


	public void GenerateNewQuizBoard(UILabel [] gridLabelList)
	{
		currentCategory.LoadCategory(currentCategory.m_CategoryPath);

		gameBoard.Clear();

		foreach(UILabel lbl in gridLabelList)
		{
			gameBoard.Add(lbl.name, GetUniqueAnswerCell());
		}
	}


	public bool CheckBoardForAllWrongs()
	{
		foreach(KeyValuePair<string, AnswerCell> entry in gameBoard)
		{
			if(entry.Value.m_IsCorrect == true)
				return false;
		}

		return true;
	}

	public int GetRemainingCorrectAnswers()
	{
		int counter = 0;

		foreach(KeyValuePair<string, AnswerCell> entry in gameBoard)
		{
			if(entry.Value.m_IsCorrect == true)
				counter++;
		}

		return counter;
	}


	public void SendGameBoardInput(CellButton cellBtn)
	{
		if(gameBoard.ContainsKey(cellBtn.name) && gameBoard[cellBtn.name].m_AnswerText != "")
		{
			//ResultScreen.GetComponentInChildren<ResultsScreen>().TrackNewAnswer(gameBoard[cellBtn.name]);
			StatsTracker.Instance.TrackNewAnswer(gameBoard[cellBtn.name]);

			lastUserInput = gameBoard[cellBtn.name];
			gameBoard[cellBtn.name].m_AnswerText = "";

			if(lastUserInput.m_IsCorrect)
				cellBtn.DisplayCorrectFeedback();
			else
				cellBtn.DisplayWrongFeedback();

			StartCoroutine(RerollSingleCell(cellBtn.name));
		}
	}

	public System.Collections.IEnumerator RerollSingleCell(string cellName)
	{

		yield return new UnityEngine.WaitForSeconds (2.0f);

		//Lets make sure that cell we are picking is not already being used
		if(gameBoard.ContainsKey(cellName))
		{			
			gameBoard[cellName] = GetUniqueAnswerCell();
		}
	}

	public AnswerCell GetUniqueAnswerCell()
	{
		AnswerCell tempCell = new AnswerCell();
		bool isUnique = true;
		do{
			isUnique = true;
			tempCell = currentCategory.GetRandomAnswer();
			
			foreach(KeyValuePair<string, AnswerCell> entry in gameBoard)
			{
				if(entry.Value.m_AnswerText == tempCell.m_AnswerText)
					isUnique = false;
			}
		}while(!isUnique);

		return tempCell;
	}




}