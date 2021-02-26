using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] Text points;
    [SerializeField] Text blocks;

    [Header("Counts")]
    private int blockCount;
    private int pointCount;

    public int BlockCount
    {
        get { return blockCount; } 
        set { blockCount = value; }
    }

    public int PointCount
    {
        get { return pointCount; }
        set { pointCount = value; }
    }

    public void UpdateTextPointPanel()
    {
        PointCount += 5;
        BlockCount += 1;
        points.text = pointCount.ToString();
        blocks.text = blockCount.ToString();
    }

    public void UpdateText()
    {
        points.text = pointCount.ToString();
        blocks.text = blockCount.ToString();
    }
}
