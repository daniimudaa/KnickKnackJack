using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadScript : MonoBehaviour 
{
	public Transform upperBody;



	void Start () 
	{
		GetComponent<Animation>() ["SitStill"].layer = 5;
		GetComponent<Animation>() ["SitStill"].AddMixingTransform (upperBody);
	}
	
	void Update () 
	{
		//animation. ("SitStill");
	}
}
