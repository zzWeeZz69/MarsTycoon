using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    private new Camera camera;
    public LayerMask ClickableLayer;
    Grid grid;
    public GameObject cube;
    BuildingHolder BuildingHolder;

    private List<GameObject> SelectedObjects;
    // Start is called before the first frame update
    void Start()
    {
        camera = gameObject.GetComponent<Camera>();
        grid = FindObjectOfType<Grid>();
        BuildingHolder = FindObjectOfType<BuildingHolder>();
        SelectedObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        PlaceBuilding();
        selectObject();
    }

    void PlaceBuildNear(Vector3 nearPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(nearPoint);
        Instantiate(BuildingHolder.gameObjects[0], finalPosition, Quaternion.identity);
    }
    void PlaceBuilding()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                PlaceBuildNear(hit.point);
                Debug.Log("Ray Hit: " + hit.collider.name);
            }
        }
    }
    void selectObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!Input.GetMouseButtonDown(0))
            {
                Debug.Log("Not Selecting");
            }
            else
            {
                RaycastHit raycast;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out raycast, ClickableLayer))
                {
                    ClickOn ClickOnScript = raycast.collider.GetComponent<ClickOn>();
                    if (raycast.collider.gameObject)
                    {
                        if (raycast.collider.name == "Plane")
                        {
                            Debug.Log("hit Ground");
                        }
                        else
                        {
                            ClickOnScript.CurrentlySelected = !ClickOnScript.CurrentlySelected;
                            ClickOnScript.ClickMe();
                        }
                    }
                }
                else
                {
                    Debug.Log("ehju");
                }
            }
        }
    }
}
