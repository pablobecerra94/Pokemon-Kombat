﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndThrow : MonoBehaviour {

    bool dragging = false;
    float distance;
    public float ThrowSpeed;
    public float ArchSpeed;
    public float Speed;
    public bool isDragable;
  

    void OnMouseDown()
    {
        if (!isDragable)
            return;

            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;
          
    }

    public void OnMouseUp()
    {
        if (!isDragable)
            return;
      
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().velocity += this.transform.forward * ThrowSpeed;
        this.GetComponent<Rigidbody>().velocity += this.transform.up * ArchSpeed;
        dragging = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDragable)
            return;
        if (dragging)
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = Vector3.Lerp(this.transform.position, rayPoint, Speed * Time.deltaTime);
          
        }
    }
}
