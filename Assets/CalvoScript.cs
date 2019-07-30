﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CalvoScript : MonoBehaviour
{
    public float velocity;
    private Vector3 target;
    private uint furiousLevel;
    private bool isPursuit;

    public BoxCollider visionCollider;
    private Collision collisionPlayer;

    public NavMeshAgent navCalvo;
    
    // Start is called before the first frame update
    void Start()
    {
        //velocity = 0.5f;
        furiousLevel = 0;
        Debug.Log(navCalvo.speed);
    }

    // Update is called once per frame
    void Update()
    { 
        if(isPursuit)
        {
            transform.LookAt(target);
            navCalvo.destination = target;
        }
        else
        {
            navCalvo.velocity = Vector3.zero;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            target = other.transform.position;
            isPursuit = true;
            Debug.Log("holi");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        target = Vector3.zero;
        isPursuit = false;
        Debug.Log("holi3");
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            target = other.transform.position;
            isPursuit = true;
            Debug.Log("holi2");
        }
        else
        {
            target = Vector3.zero;
            isPursuit = false;
            
        }
    }

    public void SetPursuit(bool change)
    {
        isPursuit = change;
    }
}
