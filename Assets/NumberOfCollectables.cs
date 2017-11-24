﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfCollectables : MonoBehaviour
{
	Text text;

	void Awake ()
	{
		text = GetComponent<Text> ();	
	}
	
	void Update ()
	{
		text.text = CollectableManager.Count.ToString();
	}
}
