using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 3D空間の処理の管理
/// </summary>
public class GameManager : MonoBehaviour
{
    Vector3 downPos;
    Vector3 tapPos;
    float downAngleZ;

    [SerializeField] Transform stage;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            downPos = Input.mousePosition;
            downAngleZ = stage.eulerAngles.z;
        }

        if (Input.GetMouseButton(0))
        {
            tapPos = Input.mousePosition;
            float dragDistance = tapPos.x - downPos.x;
            Vector3 stageAngle = stage.eulerAngles;
            stageAngle.z = downAngleZ + dragDistance * 0.1f;
            stage.eulerAngles = stageAngle;
            Debug.Log(stageAngle.z);
        }
    }
}