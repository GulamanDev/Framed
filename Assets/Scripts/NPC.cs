using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float refillAmount = 10f;
    private IsolationBarManager isolationBar;

    void Start()
    {
        isolationBar = FindObjectOfType<IsolationBarManager>();
    }

    void Update()
    {
        bool isNear = Vector3.Distance(transform.position, Camera.main.transform.position) < detectionRadius;
        isolationBar.SetNearNPC(isNear);

        if (isNear)
        {
            isolationBar.RefillIsolation(refillAmount * Time.deltaTime);
        }
    }
}
