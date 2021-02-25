using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [Header("Food")]
    public GameObject foodPrefab;

    [Header("Borders")]
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    public void Spawn(List<Transform> tail)
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        bool inSnakeBody = false;
        if (tail != null)
        {
            foreach (var t in tail)
            {
                if (t.localPosition == new Vector3(x, y, 0))
                {
                    inSnakeBody = true;
                }
            }
            if (inSnakeBody == false) 
                Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
            else 
                Spawn(tail);
        }
        else
            Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }

}
