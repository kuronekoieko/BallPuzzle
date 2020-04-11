using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionPS;
    [SerializeField] MeshRenderer meshRenderer;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y < -5)
        {
            Variables.screenState = ScreenState.CLEAR;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        var failPoint = other.GetComponent<FailPointController>();
        if (failPoint == null) { return; }
        Variables.screenState = ScreenState.FAILED;
        explosionPS.Play();
        meshRenderer.gameObject.SetActive(false);
        rb.isKinematic = true;
    }
}
