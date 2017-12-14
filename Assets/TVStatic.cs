using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TVStatic : MonoBehaviour 
{
	public int width = 256;
	public int height = 256;

	public float scale = 150f;

	public float offsetX = 100f;
	public float offsetY = 100f; 

	void Start ()
	{
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = GenerateTexture ();
	}

	void Update () 
	{
//		offsetX = Random.Range (0, 99999f);
//		offsetY = Random.Range (0, 99999f);
	}

	Texture2D GenerateTexture()
	{
		Texture2D texture = new Texture2D (width, height);

		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++) 
			{
				Color color = CalculateColor (x, y);
				texture.SetPixel (x, y, color);
			}
		}

		texture.Apply();
		return texture;
	}

	Color CalculateColor (int x, int y)
	{
		float xCoord = (float)x / width * scale;
		float yCoord = (float)y / height * scale;

		float sample = Mathf.PerlinNoise (xCoord, yCoord);
		return new Color (sample, sample, sample);
	}

}
