using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUpState : IState
{
    public LineUpStateData lineUpStateData;

    public Transform ownTransform;
    public Vector3 lineUpPoint;

    public float moveSpeed;
    public float rotateSpeed;

    public EngineSound soldierEngineSound;

    public SoldierAI soldierAI;
    public LineUpState(LineUpStateData lineUpStateData, SoldierAI soldierAI)
    {
        this.lineUpStateData = lineUpStateData;
        this.ownTransform = soldierAI.ownTransform;
        this.moveSpeed = lineUpStateData.moveSpeed;
        this.rotateSpeed = lineUpStateData.rotateSpeed;
        this.soldierAI = soldierAI;
        this.soldierEngineSound = soldierAI.soldierEngineSound;
    }
    public void OnStateEnter()
    {
        Debug.Log("Enter LineUp State");
        SetLineUpPoint();
    }

    public void OnStateExit()
    {
        Debug.Log("Exit LineUp State");
    }

    public void OnStateFixedUpdate()
    {
        Debug.Log("FixedUpdate LineUp State");
    }

    public void OnStateUpdate()
    {
        Debug.Log("Update LineUp State");
        MoveToLineUpPoint();
    }

    private void SetLineUpPoint()
    {
        lineUpPoint = LineUpManager.lineUpManager.GetLineUpPositon();
    }

    private void MoveToLineUpPoint()
    {
        if (Vector3.Distance(ownTransform.position, lineUpPoint) >= 1)
        {
            Vector3 _lineUpPoint = new Vector3(lineUpPoint.x,
                ownTransform.position.y, lineUpPoint.z);

            ownTransform.position = Vector3.MoveTowards(ownTransform.position,
                _lineUpPoint, Time.deltaTime * moveSpeed);

            LookToLineUpPoint();
            soldierEngineSound.IncreaseSpeed();
        }
        else
        {
            Debug.Log("Soldier LineUp To Idle");
            soldierAI.Idle();
        }
    }

    private void LookToLineUpPoint()
    {
        Vector3 lineUpPosition = new Vector3(lineUpPoint.x, ownTransform.position.y, lineUpPoint.z);

        Quaternion lineUpPointRotation =
            Quaternion.LookRotation(lineUpPosition - ownTransform.position);

        ownTransform.rotation = Quaternion.RotateTowards(ownTransform.rotation,
            lineUpPointRotation, rotateSpeed * 100 * Time.deltaTime);
    }
}
