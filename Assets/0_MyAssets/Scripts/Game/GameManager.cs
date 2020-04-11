using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 3D空間の処理の管理
/// </summary>
public class GameManager : MonoBehaviour
{
    Vector3 downPos;
    Vector3 tapPos;
    float downAngleZ;

    [SerializeField] Transform[] stages;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void RuntimeInitializeApplication()
    {
        SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
        QualitySettings.vSyncCount = 0; // VSyncをOFFにする
        Application.targetFrameRate = 30; // ターゲットフレームレートを60に設定
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            downPos = Input.mousePosition;
            downAngleZ = stages[0].eulerAngles.z;
        }

        if (Input.GetMouseButton(0))
        {
            tapPos = Input.mousePosition;
            float dragDistance = tapPos.x - downPos.x;
            Vector3 stageAngle = stages[0].eulerAngles;
            stageAngle.z = downAngleZ + dragDistance * 0.1f;
            stages[0].eulerAngles = stageAngle;
            Debug.Log(stageAngle.z);
        }
    }
}