using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] Text points;
    [SerializeField] Text blocks;

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

    public void Restart()
    {
        points.text = "0";
        blocks.text = "0";
        blockCount = 0;
        pointCount = 0;
    }

}
