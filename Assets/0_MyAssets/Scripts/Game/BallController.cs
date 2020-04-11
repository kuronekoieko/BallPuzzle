using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if (transform.position.y < -5)
        {
            Variables.screenState = ScreenState.CLEAR;
        }
    }
}
