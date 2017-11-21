using System.Collections.Generic;

public class CollectableManager 
{
    public static List<string> collected = new List<string>();
    public static int totalCollectibles = 15;

	void Update()
	{
		if (totalCollectibles == 14) 
		{
			//play exrta cut scene at the end
		}
	}


}