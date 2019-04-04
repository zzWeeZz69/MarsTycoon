using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drillcontroller : MonoBehaviour
{
	GameHandler gameHandler;
	BuildingPlacment building;
	public int CopperOnTick;
	public int MetalOnTick;
	// Start is called before the first frame update
	void Start()
	{
		building = FindObjectOfType<BuildingPlacment>().GetComponent<BuildingPlacment>();
		gameHandler = FindObjectOfType<GameHandler>().GetComponent<GameHandler>();
	}

	// Update is called once per frame
	void Update()
	{
		if (building.hasPlaced)
		{
			if (Time.time >= gameHandler.waitForDrill)
			{
				gameHandler.copper += CopperOnTick;
				gameHandler.Metal += MetalOnTick;
				gameHandler.waitForDrill = Time.time + gameHandler.waitForDrill;
			}
		}
	}
}
