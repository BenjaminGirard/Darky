using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class HandleHighScore : MonoBehaviour {

	public TextAsset highScore;
	public Text highScoreTextShowOnScreen;
	public Text playerName;
	public GameObject button;
	public GameObject input;
	public GameObject panel;
	public GameObject title;
	public GameObject gameOver;
	public GameObject backtomenu;
	public GameObject replay;
	public GameObject exit;
	private string scores;
	private string filename = "Assets/Resources/highScore.txt";
	private Dictionary<string, int> scoreMap = new Dictionary<string, int>();

	void Start() {
		scores = highScore.text;
	}
	public void handleHighScoreOnClick() {
		string[] check = scores.Split('\n');
		//Get file on Map form for work
		if (check.Count() > 0 && check[0] != ""){
			for (int i = 0; i < check.Count(); ++i) {
				string[] data;
				data = check[i].Split(':');
				if (data.Count() > 1) {
					scoreMap.Add(data[0], int.Parse(data[1]));
				}
			}
		}
		//Add new entry
		if (scoreMap.ContainsKey(playerName.text))
			scoreMap.Remove(playerName.text);
		scoreMap.Add(playerName.text, PlayerPrefs.GetInt("highScore", 0));
		//Sort Map
		var tmp = from entry in scoreMap orderby entry.Value descending select entry;
		//Construct String which contain all text file
		string toWrite = "";
		foreach (KeyValuePair<string, int> entry in tmp) {
			toWrite += entry.Key + ":" + entry.Value.ToString() + "\r\n";
		}
		//Dump string to file text
		File.WriteAllText(filename, toWrite);
		//UI shutting down buttun and inputfield and activate panel showing elements
		gameOver.SetActive(false);
		button.SetActive(false);
		input.SetActive(false);
		title.SetActive(true);
		backtomenu.SetActive(true);
		replay.SetActive(true);
		exit.SetActive(true);
		panel.SetActive(true);
		//Read the highscore text document and give im to the right Text GameObject
		string text = string.Join("\r\n", File.ReadAllLines(filename)).Replace(':', '\t');
		highScoreTextShowOnScreen.text = text;
		PlayerPrefs.SetInt("highScore", 0);
        PlayerPrefs.Save();
	}
}
