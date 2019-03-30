using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOn : MonoBehaviour
{
    
    public Color red;
   
    public Color green;

    private MeshRenderer myRend;

    
    public bool CurrentlySelected = false;
    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<MeshRenderer>();
        ClickMe();
    }

    public void ClickMe()
    {
        if(CurrentlySelected == true)
        {
            myRend.material.color = red;
        }
        else if(CurrentlySelected == false)
        {
            myRend.material.color = green;
        }
            
    }
    
    
}
