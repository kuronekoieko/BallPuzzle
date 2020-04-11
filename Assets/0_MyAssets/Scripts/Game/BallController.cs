using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionPS;
    [SerializeField] MeshRenderer meshRenderer;
    Rigidbody rb;
    public bool isGoaled { get; set; }
    float goalLine;

    public void OnStart(float goalLine)
    {
        this.goalLine = goalLine;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y < goalLine)
        {
            isGoaled = true;
            gameObject.SetActive(false);
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
