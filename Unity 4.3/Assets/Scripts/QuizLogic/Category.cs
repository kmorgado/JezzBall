using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System;
using UnityEngine;

public class Category
{
		public enum MainCategory
		{
				Sports = 0,
				Nature,
				Science,
				Music,
				TV_Movies,
				History,
				Geography,
				Games,
				Culture,
				Literature,
				Education,
				Drugs
		}

		public MainCategory m_ParentCategory;

		//Name of the Subcategory
		public string m_CategoryName;

		// Where is the XML file?
		public string m_CategoryPath;

		//1-10 On Average how difficult is this category
		public int m_Difficulty;
		public List<AnswerCell> m_AnswerList = new List<AnswerCell> ();

		public Category ()
		{
		}
	
		public Category (string xmlFilename)
		{
				LoadCategory (xmlFilename);
		}
	
		public Category (MainCategory parentCategory, string categoryName, int difficulty)
		{
				m_ParentCategory = parentCategory;
				m_CategoryName = categoryName;
				m_Difficulty = difficulty;
		}


	public AnswerCell GetRandomAnswer()
	{
		//if(m_AnswerList.Count > 0)
		int randomCell = UnityEngine.Random.Range( 0, m_AnswerList.Count );

		//We need to do a deep copy here to prevent pointer confusion
		AnswerCell newCell = new AnswerCell();
		newCell.m_AnswerText = m_AnswerList[randomCell].m_AnswerText;
		newCell.m_Difficulty = m_AnswerList[randomCell].m_Difficulty;
		newCell.m_IsCorrect = m_AnswerList[randomCell].m_IsCorrect;

		return newCell;
	}

	/// <summary>
	/// XML LOADER
	/// </summary>
	/// <param name="filename">Filename of the xml file</param>

		public void LoadCategory (string filename)
		{
				TextAsset textAsset = new TextAsset ();
				textAsset = (TextAsset)Resources.Load (filename, typeof(TextAsset));

				if (textAsset != null) {

						XmlDocument xmlDoc = new XmlDocument (); // xmlDoc is the new xml document.
						xmlDoc.LoadXml (GetTextWithoutBOM (textAsset)); // load the file.

						XmlElement root = xmlDoc.DocumentElement;
						XmlNode catName = root.SelectSingleNode ("name");
						XmlNode catParent = root.SelectSingleNode ("parent");

						m_CategoryName = catName.InnerText;
						m_ParentCategory = (MainCategory)Enum.Parse (typeof(MainCategory), catParent.InnerText);

						XmlNodeList correctList = xmlDoc.GetElementsByTagName ("correct");
						XmlNodeList wrongList = xmlDoc.GetElementsByTagName ("wrong");


						m_AnswerList = new List<AnswerCell> ();


						foreach (XmlNode chldNode in correctList) {

								AnswerCell tempcell = new AnswerCell ();

								tempcell.m_AnswerText = chldNode.Attributes ["Text"].Value;
								tempcell.m_Difficulty = Convert.ToInt32(chldNode.Attributes ["Difficulty"].Value);
								tempcell.m_IsCorrect = true;

								m_AnswerList.Add (tempcell);
						}

						foreach (XmlNode chldNode in wrongList) {
				
								AnswerCell tempcell = new AnswerCell ();
				
								tempcell.m_AnswerText = chldNode.Attributes ["Text"].Value;
								tempcell.m_Difficulty = Convert.ToInt32(chldNode.Attributes ["Difficulty"].Value);
								tempcell.m_IsCorrect = false;
				
								m_AnswerList.Add (tempcell);
						}


						
				}
		}

		public static string GetTextWithoutBOM (TextAsset textAsset)
		{
				MemoryStream memoryStream = new MemoryStream (textAsset.bytes);
				StreamReader streamReader = new StreamReader (memoryStream, true);
		
				string result = streamReader.ReadToEnd ();
		
				streamReader.Close ();
				memoryStream.Close ();
		
				return result;
		}
	
}

