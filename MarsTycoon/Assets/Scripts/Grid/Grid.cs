using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    float size = 1f;

    
    public Vector3 GetNearestPointOnGrid(Vector3 pos)
    {
        pos -= transform.position;

        int xCount = Mathf.RoundToInt(pos.x / size);
        int yCount = Mathf.RoundToInt(pos.y / size);
        int zCount = Mathf.RoundToInt(pos.z / size);

        Vector3 result = new Vector3((float)xCount * size, (float)yCount * size, (float)zCount * size);

        result += transform.position;
        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        for (float x = 0; x < 40; x += size)
        {
            for (float z = 0; z < 40; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawWireSphere(point, 0.1f);
            }
        }
    }
}
