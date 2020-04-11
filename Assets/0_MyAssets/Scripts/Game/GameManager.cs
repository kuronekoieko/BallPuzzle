using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

/// <summary>
/// 3D空間の処理の管理
/// </summary>
public class GameManager : MonoBehaviour
{
    Vector3 downPos;
    Vector3 tapPos;
    float downAngleZ;

    List<StageManager> stages;

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
        Variables.screenState = ScreenState.INITIALIZE;
        Variables.lastStageIndex = transform.childCount - 1; ;
        stages = new List<StageManager>();
        for (int i = 0; i < transform.childCount; i++)
        {
            stages.Add(transform.GetChild(i).GetComponent<StageManager>());
            stages[i].OnStart(Variables.currentStageIndex == i);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            downPos = Input.mousePosition;
            downAngleZ = stages[Variables.currentStageIndex].transform.eulerAngles.z;
        }

        if (Input.GetMouseButton(0))
        {
            tapPos = Input.mousePosition;
            float dragDistance = tapPos.x - downPos.x;
            Vector3 stageAngle = stages[Variables.currentStageIndex].transform.eulerAngles;
            stageAngle.z = downAngleZ + dragDistance * 0.2f;
            stages[Variables.currentStageIndex].transform.eulerAngles = stageAngle;
        }

        for (int i = 0; i < stages.Count; i++)
        {
            stages[i].OnUpdate();
        }
    }
}