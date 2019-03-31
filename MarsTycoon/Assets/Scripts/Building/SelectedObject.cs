using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObject : MonoBehaviour
{
    public enum selectedObject
	{
		None,
		Factory,
		Drill
	}
	public selectedObject selected;

	private void Start()
	{
		selected = selectedObject.None;
	}

	private void FixedUpdate()
	{
		if (Input.GetMouseButtonDown(0))
		{

		}
	}

	public void FactorySelected()
	{
		selected = selectedObject.Factory;
	}

	public void DrillSelected()
	{
		selected = selectedObject.Drill;
	}
}
