using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageManager : MonoBehaviour
{
    [SerializeField] float goalLine;
    List<BallController> ballControllers;
    public void OnStart(bool show)
    {
        gameObject.SetActive(show);
        ballControllers = new List<BallController>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var ball = transform.GetChild(i).GetComponent<BallController>();
            if (ball == null) { continue; }
            ballControllers.Add(ball);
            ball.OnStart(goalLine);
        }
    }

    public void OnUpdate()
    {
        if (ballControllers.All(b => b.isGoaled))
        {
            Variables.screenState = ScreenState.CLEAR;
        }
    }


}
