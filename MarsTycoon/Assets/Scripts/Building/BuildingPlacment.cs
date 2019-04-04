using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacment : MonoBehaviour
{
	PlaceableBuilding PlaceableBuilding;
	private Transform currentBuilding;
	public LayerMask buildingMask;
	[HideInInspector]
	public bool hasPlaced;
	
	Camera Camera;

	PlaceableBuilding PlaceableBuildingOLD;

	float RotationY()
	{
		return currentBuilding.localRotation.y;
	}
	float ScaleY()
	{
		float ZeroY = 0f;
		float TrueY = currentBuilding.localScale.y;
		if(currentBuilding.localScale.y < 1)
		{
			return ZeroY;
		}
		else
		{
			return TrueY / 2;
		}
	}
	// Start is called before the first frame update
	void Start()
	{
		Camera = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 m = Input.mousePosition;
		m = new Vector3(m.x, m.y, transform.position.y);
		Vector3 p = Camera.ScreenToWorldPoint(m);

		if (currentBuilding != null && !hasPlaced)
		{
			RaycastHit hit;
			Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
			var raycast = Physics.Raycast(ray, out hit);
			currentBuilding.position = new Vector3(hit.point.x, ScaleY(), hit.point.z);
			if (Input.GetKeyDown(KeyCode.R))
			{
				currentBuilding.Rotate(0, RotationY() + 45, 0);
			}
			if (Input.GetMouseButtonDown(0))
			{
				
				if (raycast)
				{
					if (IsLegalPositon())
					{
						hasPlaced = true;
					}
				}
			}
		}
		else
		{
			// shoot a raycast to see what object it hits
			if (Input.GetMouseButtonDown(0))
			{
				RaycastHit hit = new RaycastHit();
				Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit, Mathf.Infinity, buildingMask))
				{

					hit.collider.gameObject.GetComponent<PlaceableBuilding>().setSelected(true);
					PlaceableBuildingOLD = hit.collider.gameObject.GetComponent<PlaceableBuilding>();
				}
				else
				{
					if (PlaceableBuildingOLD != null)
					{
						PlaceableBuildingOLD.setSelected(false);
					}
				}
			}
		}
	}

	bool IsLegalPositon()
	{
		if (PlaceableBuilding.colliders.Count > 0)
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
