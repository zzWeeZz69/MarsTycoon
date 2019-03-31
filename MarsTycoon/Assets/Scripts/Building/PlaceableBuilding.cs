using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableBuilding : MonoBehaviour
{
	[HideInInspector]
	public List<Collider> colliders = new List<Collider>();

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
}
