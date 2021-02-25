using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{
    [SerializeField] private int startTailCount = 2;
    [SerializeField] Vector2 dir = Vector2.right;
    [SerializeField] SpawnFood spawnFood;
    [SerializeField] Points pointsPanel;
    [SerializeField] GameObject losePanel;

    List<Transform> tail = new List<Transform>();

    bool ate = false;
    bool isMoved = false;
    public GameObject tailPrefab;
    


    void Start()
    {
        Vector2 v = transform.position;
        pointsPanel.BlockCount = startTailCount + 1;
        pointsPanel.UpdateText();
        while (startTailCount != 0)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab, new Vector2(v.x - startTailCount, v.y), Quaternion.identity);
            tail.Insert(0, g.transform);

            startTailCount--;
        }

        InvokeRepeating("Move", 0.3f, 0.5f);
        spawnFood.Spawn(tail);
    }

    void Update()
    {
        if (isMoved)
        {
            if (Input.GetKey(KeyCode.RightArrow) && dir != -Vector2.right)
            {
                dir = Vector2.right;
                isMoved = false;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && dir != Vector2.up)
            {
                dir = -Vector2.up;
                isMoved = false;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && dir != Vector2.right)
            {
                dir = -Vector2.right;
                isMoved = false;
            }
            else if (Input.GetKey(KeyCode.UpArrow) && dir != -Vector2.up)
            {
                dir = Vector2.up;
                isMoved = false;
            }
        }
    }

    void Move()
    {
        isMoved = true;
        Vector2 v = transform.position;

        transform.Translate(dir);

        if (ate)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;
        }
        else if (tail.Count > 0)
        {
            tail.Last().position = v;

            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {       
        if (coll.gameObject.tag == "Food")
        {
            ate = true;
            Destroy(coll.gameObject);
            spawnFood.Spawn(tail);

            pointsPanel.UpdateTextPointPanel();
        }
        else
        {
            pointsPanel.BlockCount = startTailCount + 1;
            pointsPanel.PointCount = 0;
            CancelInvoke("Move");
            Instantiate(losePanel, new Vector2(0, 0), Quaternion.identity);
        }
    }
}
