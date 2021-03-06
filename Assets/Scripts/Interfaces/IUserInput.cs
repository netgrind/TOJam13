﻿using UnityEngine;
using System.Collections;


public interface IUserInputProxy
{
	InputModel GetInput ();
}

public interface ITakesInput
{
	void SendInput (float leftInput, float rightInput);
}

public interface IRequireUserInput
{
	IUserInputProxy InputProxy { get; set; }
}

public class InputModel
{
	public float leftInput = 0;
	public float rightInput = 0;
	public float upInput = 0;
	public float downInput = 0;
	public float boostInput = 0;

	public InputModel()
	{
		leftInput = 0;
		rightInput = 0;
		upInput = 0;
		downInput = 0;
		boostInput = 0;
	}

	public InputModel(float left, float right, float up, float down, float boost)
	{
		this.leftInput = left;
		this.rightInput = right;
		this.upInput = up;
		this.downInput = down;
		this.boostInput = boost;
	}

	public void Reset()
	{
		leftInput = 0;
		rightInput = 0;
		downInput = 0;
		upInput = 0;
		boostInput = 0;
	}
}