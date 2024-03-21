using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ObosanMoveSystem : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    private GameObject[] points;
    private GameObject point;

    private int pointNumber;
    // Start is called before the first frame update
    void Start()
    {
        GetPoint();
        SetPoint();
    }

    // Update is called once per frame
    void Update()
    {
        MovePoint();
    }

    void MovePoint()
    {
        navMeshAgent.SetDestination(point.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ObosanPoint")
        {
         SetPoint();   
        }
    }

    private void GetPoint()
    {
        points = GameObject.FindGameObjectsWithTag("ObosanPoint");
    }
    private void SetPoint()
    {
        int i = pointNumber;
        while (i == pointNumber) 
        {
            pointNumber = Random.Range(0, points.Length);
        }
     
    }
}
