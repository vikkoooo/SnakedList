using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public void Menu()
	{
		SceneManager.LoadScene("Menu");
	}
	
	public void Play()
	{
		SceneManager.LoadScene("Game");
	}
}
