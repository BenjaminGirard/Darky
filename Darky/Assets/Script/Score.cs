using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	private int scoreInt;

	private Text textBox;
	
	// Use this for initialization
	void Start ()
	{
		scoreInt = 0;
		textBox = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		scoreInt += (int) (Time.deltaTime * 100);

		textBox.text = scoreInt.ToString();
		
	}

	public void AddScore(int toAdd)
	{
		scoreInt += toAdd;
	}
}
