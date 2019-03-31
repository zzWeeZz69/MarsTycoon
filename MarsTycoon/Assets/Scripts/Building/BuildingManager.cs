using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
	public GameObject[] buildings;
	BuildingPlacment BuildingPlacment;
    // Start is called before the first frame update
    void Start()
    {
		BuildingPlacment = GetComponent<BuildingPlacment>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnGUI()
	{
		for (int i = 0; i < buildings.Length; i++)
		{
			if(GUI.Button(new Rect(Screen.width/20, Screen.height/15 + Screen.height/12 * i, 100, 30), buildings[i].name))
			{
				BuildingPlacment.SetItem(buildings[i]);
			}
		}
	}
}
