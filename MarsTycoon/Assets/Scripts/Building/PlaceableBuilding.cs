using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableBuilding : MonoBehaviour
{
	[HideInInspector]
	public List<Collider> colliders = new List<Collider>();
	bool isSelected;

	private void OnGUI()
	{
		if (isSelected)
		{
			GUI.Button(new Rect(100, 200, 100, 30), name);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Building")
		{
			colliders.Add(other);
			Debug.Log("has added: " + colliders.Count);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Building")
		{
			colliders.Remove(other);
		}
	}

	public void setSelected(bool s)
	{
		isSelected = s;
	}
}
