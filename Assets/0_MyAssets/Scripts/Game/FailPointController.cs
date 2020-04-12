using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FailPointController : MonoBehaviour
{
    [SerializeField] Transform swords;

    void Start()
    {
        swords.transform.DOLocalRotate(new Vector3(0, 0, 360), 1).SetRelative().SetLoops(-1).SetEase(Ease.Linear);
    }


    void Update()
    {

    }
}
