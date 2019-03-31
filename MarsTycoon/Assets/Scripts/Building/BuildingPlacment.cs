using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacment : MonoBehaviour
{
	PlaceableBuilding PlaceableBuilding;
	private Transform currentBuilding;
	bool hasPlaced;
	public LayerMask layerMask;
	Camera Camera;
	// Start is called before the first frame update
	void Start()
	{
		Camera = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update()
	{
		if (currentBuilding != null && !hasPlaced)
		{
			Vector3 m = Input.mousePosition;
			m = new Vector3(m.x, m.y, transform.position.y);
			Vector3 p = Camera.ScreenToWorldPoint(m);
			currentBuilding.position = new Vector3(p.x, 0, p.z);
			if (Input.GetMouseButtonDown(0))
			{
				if (IsLegalPositon())
				{
					hasPlaced = true;
				}
			}
		}
		else
		{
			if (Input.GetMouseButtonDown(0))
			{

			}
		}
	}

	bool IsLegalPositon()
	{
		if(PlaceableBuilding.colliders.Count > 0)
		{
			return false;
		}
		return true;
	}

	public void SetItem(GameObject b)
	{
		hasPlaced = false;
		currentBuilding = (Instantiate(b)).transform;
		PlaceableBuilding = currentBuilding.GetComponent<PlaceableBuilding>();
	}
}
