using UnityEngine;
using System.Collections;

public class CellButton : MonoBehaviour
{
	public GameObject CorrectFeedbackIcon;
	public GameObject WrongFeedbackIcon;
	
	void OnClick()
	{
		QuizEngine.Instance.SendGameBoardInput(this);
	}

	public void DisplayCorrectFeedback()
	{
		CorrectFeedbackIcon.SetActive(true);
		
		TweenAlpha alphaScript = CorrectFeedbackIcon.GetComponent<TweenAlpha>();
		TweenScale scaleScript = CorrectFeedbackIcon.GetComponent<TweenScale>();

		alphaScript.ResetToBeginning();
		alphaScript.PlayForward();

		scaleScript.ResetToBeginning();
		scaleScript.PlayForward();
	}

	public void DisplayWrongFeedback()
	{
		WrongFeedbackIcon.SetActive(true);

		TweenAlpha alphaScript = WrongFeedbackIcon.GetComponent<TweenAlpha>();
		TweenScale scaleScript = WrongFeedbackIcon.GetComponent<TweenScale>();
		
		alphaScript.ResetToBeginning();
		alphaScript.PlayForward();

		scaleScript.ResetToBeginning();
		scaleScript.PlayForward();
	}
}
