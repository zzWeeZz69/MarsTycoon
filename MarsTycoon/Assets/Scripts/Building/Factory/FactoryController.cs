using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryController : MonoBehaviour
{
	GameHandler gameHandler;
    // Start is called before the first frame update
    void Start()
    {
		gameHandler = FindObjectOfType<GameHandler>().GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
