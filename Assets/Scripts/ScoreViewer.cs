using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
	public Text text;
	
	void Start()
    {
	    text.text = "Score: " + Player.score;
    }
}
