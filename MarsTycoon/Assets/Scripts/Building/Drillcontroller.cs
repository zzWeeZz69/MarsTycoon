using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drillcontroller : MonoBehaviour
{
	GameHandler gameHandler;
	BuildingPlacment building;
	public int CopperOnTick;
	public int MetalOnTick;
	public float wfd;
	float wfd_;
	// Start is called before the first frame update
	void Start()
	{
		building = FindObjectOfType<BuildingPlacment>().GetComponent<BuildingPlacment>();
		gameHandler = FindObjectOfType<GameHandler>().GetComponent<GameHandler>();
		wfd = gameHandler.waitForDrill;
	}

	// Update is called once per frame
	void Update()
	{
		if (building.hasPlaced)
		{
			if (Time.time >= wfd_)
			{
				gameHandler.copper += CopperOnTick;
				gameHandler.Metal += MetalOnTick;
				wfd_ = Time.time + wfd;
			}
		}
	}
}
