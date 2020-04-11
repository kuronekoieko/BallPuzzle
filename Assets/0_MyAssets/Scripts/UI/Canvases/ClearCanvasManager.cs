﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class ClearCanvasManager : BaseCanvasManager
{
    [SerializeField] Button nextButton;
    [SerializeField] Text coinCountText;
    [SerializeField] Image dummyRectangleImage;
    [SerializeField] CoinCountView coinCountView;
    public readonly ScreenState thisScreen = ScreenState.CLEAR;

    public override void OnStart()
    {
        base.SetScreenAction(thisScreen: thisScreen);

        nextButton.onClick.AddListener(OnClickNextButton);
        gameObject.SetActive(false);
        dummyRectangleImage.gameObject.SetActive(Debug.isDebugBuild);
        coinCountView.OnStart();
    }

    public override void OnUpdate()
    {
        if (Variables.screenState != thisScreen) { return; }

    }

    protected override void OnOpen()
    {
        gameObject.SetActive(true);
    }

    protected override void OnClose()
    {
        gameObject.SetActive(false);
    }

    void OnClickNextButton()
    {
        Variables.currentStageIndex++;
        Variables.screenState = ScreenState.INITIALIZE;
    }
}
