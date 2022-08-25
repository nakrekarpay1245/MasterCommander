using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUpManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> lineUpPoints;

    private int lineUpIndex;

    public bool isLineUpFull;

    public static LineUpManager lineUpManager;

    private void Awake()
    {
        if (!lineUpManager)
        {
            lineUpManager = this;
        }
    }

    public Vector3 GetLineUpPositon()
    {
        if (lineUpIndex < lineUpPoints.Count && !isLineUpFull)
        {
            lineUpIndex++;
            //Debug.Log("Line Up Point:" + lineUpPoints[lineUpIndex - 1].name);
            return lineUpPoints[lineUpIndex - 1].position;
        }
        else
        {
            isLineUpFull = true;
            return lineUpPoints[lineUpIndex - 1].position;
        }
    }

    public void ClearLineUpPositions()
    {
        lineUpIndex = 0;
        isLineUpFull = false;
    }
}
