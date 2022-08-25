using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderBarracks : MonoBehaviour
{
    public GameObject soldierPrefab;

    public float generateTime;
    private float nextTimeToGenerate;

    public Transform generatePoint;

    public Bar produceBar;

    private void Awake()
    {
        produceBar.SetMaxValue(generateTime);
    }

    private void Update()
    {
        if (Time.time > nextTimeToGenerate)
        {
            if (!Commander.commander.isAttack)
            {
                if (!Manager.manager.isLevelCompleted && !LineUpManager.lineUpManager.isLineUpFull)
                {
                    nextTimeToGenerate = Time.time + generateTime;
                    Generate();
                }
            }
        }

        produceBar.SetCurrentValue(generateTime - (nextTimeToGenerate - Time.time));
    }

    public void Generate()
    {
        GameObject currentSolider = Instantiate(soldierPrefab,
            generatePoint.position, Quaternion.identity);
    }
    public void LevelUp()
    {
        generateTime -= 0.5f;
        produceBar.SetMaxValue(generateTime);
    }
}
