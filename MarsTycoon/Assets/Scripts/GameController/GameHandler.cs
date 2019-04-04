using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
	[Header("resorces")]
	public int Metal;
	public int oil;
	public int copper;
	[Header("Energy")]
	public int Energy;
	public int MaxEnergy;
	[Header("Tick Stuff")]
	public float waitForDrill;

	void Start()
	{
		
	}
	void FixedUpdate()
	{
		if(Energy >= MaxEnergy)
		{
			Energy = MaxEnergy;
		}
	}
}
