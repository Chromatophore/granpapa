﻿using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	static private GameState _state;
	static public GameState State
	{
		get
		{
			return _state;
		}
	}

	[SerializeField]
	private PageSequence currentPageSequence;
	public PageSequence CurrentPageSequence
	{
		get
		{
			return currentPageSequence;
		}
	}


	void Awake()
	{
		_state = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z))
		{
			currentPageSequence.PlayerInput(BUTTON.A);
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			currentPageSequence.PlayerInput(BUTTON.B);
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			currentPageSequence.PlayerInput(BUTTON.X);
		}
		if (Input.GetKeyDown(KeyCode.V))
		{
			currentPageSequence.PlayerInput(BUTTON.Y);
		}
	}
}
