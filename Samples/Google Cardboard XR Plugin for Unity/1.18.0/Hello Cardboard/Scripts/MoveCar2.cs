using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveCar2 : MonoBehaviour
{

    public GameObject[] waypoint;
    public int index = 0;
    private float speed = 50;
    private float amg = 1;
    bool isPressed = false;
    bool isFinished = false;
    public bool canStart = false;
    public GameObject camera1;
    public GameObject camera2;
    public float startX;
    public float startY;
    public float startZ;

    

    // Start is called before the first frame update
    public void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        startZ = transform.position.z;
        //enabled = false;

    }
    public void Reset()
    {
        index = 0;
        speed = 50;
        amg = 1;
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = new Vector3(startX, startY, startZ);
        isPressed = false;
        isFinished = false;

    }
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey("up"))
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            isPressed = true;
            // enabled = true;
        }
        if(!isPressed)
        {
            return;
        }*/
        var distance = Vector3.Distance(transform.position, waypoint[index].transform.position);
        var targetRotation = Quaternion.LookRotation(waypoint[index].transform.position - transform.position);
        //Debug.Log(distance);
        if (distance < 0.05f)
        {
            index++;
        }
        Debug.Log("index: " + index);
        //Debug.Log("siz: " + waypoint.Length);

        if (index == waypoint.Length)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position = new Vector3(startX, startY, startZ);
            isFinished = true;
            index = 0;
            speed = 50;
            amg = 1;
            enabled = false;
            isPressed = false;
            camera1.SetActive(true);
            camera2.SetActive(false);
            // enabled = false;
            return;
        }
            
        float angle = transform.rotation.x;
        float another_angle = transform.rotation.eulerAngles.x;
        //speed = 100;
        
        //Debug.Log("index: " + index);
        if (another_angle > 180)
            another_angle -= 360;
        
        if (index != 0 && index != 1 && index != 2 && (another_angle >= 25 || another_angle <= -25))
        {
            //Debug.Log("another_angle: " + another_angle);
            double radians = (System.Math.PI / 180) * another_angle;
            //Debug.Log("another_angle: " + System.Math.Sin(another_angle));
            //Debug.Log("inside: " + (float)(System.Math.Sin(another_angle)));
            float addSpeed = amg * (float)System.Math.Sin(radians);
            //Debug.Log("addSpeed: " + addSpeed);
            //Debug.Log(addSpeed);
            speed += addSpeed;
        }
        else
        {
            if(speed <= 50)
            {
                if(another_angle >= 25)
                {
                    speed += 2;
                }
            }
            if(speed >= 50)
            {
                if(another_angle <= 25)
                {
                    //Debug.Log("minus");
                    speed -= 2;
                }
            }
        }
        
        /*if (angle < 0.1 && angle >= 0)
        {
            speed = 40;
        }
        else if (angle < 0 && angle > -0.1)
        {
            speed = 40;
        }
        else if (angle <= -0.1)
        {
            speed = 35;
        }
        else if (angle >= 0.1)
        {
            speed += 10;
        }*/
        if (speed >= 150)
        {
            speed = 150;
        }
        if(speed <= 30)
        {
            speed = 30;
        }
        
        float step = speed * Time.deltaTime;


        //Debug.Log(targetRotation[0]);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        if (index == 11 || index == 12)
        {
            transform.eulerAngles = new Vector3(-90, 180, 0);
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoint[index].transform.position, step);
    }
    public void test()
    {
        Debug.Log(index);
    }
}
