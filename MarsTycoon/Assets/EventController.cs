using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
	public Animator Anim;
	bool BMENU = false;
	bool DMENU = false;



	public void BuildingMenu()
	{
		BMENU = !BMENU;

		if (BMENU == true)
		{
			Anim.SetBool("BuildingMenu", true);
		}
		if (BMENU == false)
		{
			Anim.SetBool("BuildingMenu", false);
		}
	}

	public void DataMenu()
	{
		DMENU = !DMENU;

		if (DMENU == true)
		{
			Anim.SetBool("DataMenu", true);
		}
		if (DMENU == false)
		{
			Anim.SetBool("DataMenu", false);
		}
	}
}
