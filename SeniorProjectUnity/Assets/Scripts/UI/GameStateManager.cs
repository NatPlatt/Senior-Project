﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//This class manages what state the game is in (ie preparing to start a match, currently in a match, or after the match has ended).
public class GameStateManager : MonoBehaviour {

	public static GameStateManager instance;

	private Animator gameStateMachine;
	//Animator must be set to unscaled time

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(this);
		}
		
		gameStateMachine = GetComponent<Animator>();
		DontDestroyOnLoad(gameObject);
	}

	//call this method to reset the game to its initial boot state (ie before the player started their match).
	//this should be used rather than PostGameState() in most cases.
	public void PregameState()
	{
		gameStateMachine.SetTrigger("ExitToStart");
		print("pregame");
	}

	public void LoadSceneState()
	{
		gameStateMachine.SetTrigger("LoadLevel");
		print("loadgame");
	}

	//call this method to start playing the game once the player has chosen their character and rules and whatever
	public void IngameState()
	{
		gameStateMachine.SetTrigger("StartGame");
		print("ingame");
	}

	//call this method when the player has lost the game to initiate scoring, achievements, etc.
	//DO NOT use this method to return the player to the start menu from the pause menu, for example.
	//it is only for when the player has lost/ended a game.
	public void PostgameState()
	{
		gameStateMachine.SetTrigger("EndGame");
		print("endgame");
	}

}
