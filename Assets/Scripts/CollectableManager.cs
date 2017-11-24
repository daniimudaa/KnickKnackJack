using System.Collections.Generic;
using UnityEngine;

public class CollectableManager 
{
	public enum Level { L_Bedroom, L_Lounge, L_Kitchen }

	public static List<string> collectedBedroom = new List<string>();
	public static List<string> collectedLounge = new List<string>();
	public static List<string> collectedKitchen = new List<string>();
    
	public static int totalCollectibles = 15;


	public static int Count {
		get {
			return collectedBedroom.Count + collectedLounge.Count + collectedKitchen.Count;
		}
	}

	public static List<string> GetCollectable(Level level)
	{
		switch (level)
		{
		case Level.L_Bedroom:
			return CollectableManager.collectedBedroom;
		case Level.L_Lounge:
			return CollectableManager.collectedLounge;
		case Level.L_Kitchen:
			return CollectableManager.collectedKitchen;
		default:
			Debug.LogError ("Something bad has happened");
			return CollectableManager.collectedBedroom;
		}
	}

}