﻿using UnityEngine;
using System.Collections.Generic;	// We use generic for Data Structures with <YourClass> style declarations

public class BlankTrackerCell : MonoBehaviour
{

	public Dictionary<string, int> enemyBars { get; private set; }
	public Dictionary<string, int> playerBars { get; private set; }

	private Dictionary<BUTTON, ButtonObjectAssoctiate> DisplayBarsDict;

	[SerializeField]
	private bool DeactivateOnStart;

	public SpriteRenderer spriteRenderer;

	void Start()
	{
		// Create a Dict<> struct from our serialised array:
		DisplayBarsDict = new Dictionary<BUTTON, ButtonObjectAssoctiate>();

		// Activebars and Enemybars are dicts of bars that are active, in theory!
		enemyBars = new Dictionary<string, int>();
		playerBars = new Dictionary<string, int>();

		if (DeactivateOnStart)
		{
			ResetAllBars();
		}
	}

	public void ResetAllBars()
	{
		foreach (var bar in DisplayBarsDict.Values)
		{
			bar.obj.SetActive(false);
			SetColor(bar.button, bar.startColor);
		}

		enemyBars.Clear();
		playerBars.Clear();
	}

	public void PlayerInput(BUTTON inputButton)
	{
		int used;
		if (playerBars.TryGetValue("Used", out used))
		{
			if (used != 0)
			{
				return;
			}
		}

		ButtonObjectAssoctiate result;
		if (DisplayBarsDict.TryGetValue(inputButton, out result))
		{
			int pressed;
			if (enemyBars.TryGetValue(inputButton.ToString(), out pressed))
			{
				playerBars["Used"] = 1;
				playerBars[inputButton.ToString()] = 1;
				SetColor(inputButton, Color.white);
			}
			else
			{
				playerBars["Used"] = 1;
				playerBars[inputButton.ToString()] = 1;
				result.obj.SetActive(true);
			}
		}
	}

	public void SetColor(BUTTON whichBar, Color newColor) // Oh god why am I using buttons everywhere? This needs to change.
	{
		ButtonObjectAssoctiate result;
		if (DisplayBarsDict.TryGetValue(whichBar, out result))
		{
			result.obj.GetComponent<SpriteRenderer>().color = newColor;
		}
	}

	public void EnemyInput(BUTTON inputButton)
	{
		ButtonObjectAssoctiate result;
		if (DisplayBarsDict.TryGetValue(inputButton, out result))
		{
			enemyBars[inputButton.ToString()] = 1;
			result.obj.SetActive(true);
		}
	}
}