using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public GameObject[] waypoint;
    private int index = 0;
    private float speed = 50;
    private float amg = 1;
    bool isPressed = false;
    bool isFinished = false;
    public bool canStart = false;
    public GameObject camera1;
    public GameObject camera3;
    public float startX;
    public float startY;
    public float startZ;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        /*var angle = transform.rotation.x;
        
        if (angle < 0.1 && angle >= 0)
        {
            speed = 40;
        }
        else if(angle < 0 && angle > -0.1)
        {
            speed = 40;
        }
        else if (angle <= -0.1)
        {
            speed = 35;
        }
        else if(angle >= 0.1)
        {
            speed += 10;
        }
        if(speed >= 150)
        {
            speed = 150;
        }
        speed = 100;*/
        
        var distance = Vector3.Distance(transform.position, waypoint[index].transform.position);
        if(distance < 0.05f)
        {
            index++;
        }

        if (index == waypoint.Length)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position = new Vector3(startX, startY, startZ);
            isFinished = true;
            index = 0;
            speed = 50;
            //amg = 1;
            enabled = false;
            isPressed = false;
            camera1.SetActive(true);
            camera3.SetActive(false);
            // enabled = false;
            return;
        }
        Debug.Log(index);


        float angle = transform.rotation.x;
        float another_angle = transform.rotation.eulerAngles.x;
        if (another_angle > 180)
            another_angle -= 360;

        if (index != 0 && index != 1 && (another_angle >= 25 || another_angle <= -25))
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
            if (speed <= 50)
            {
                if (another_angle >= 25)
                {
                    speed += 2;
                }
            }
            if (speed >= 50)
            {
                if (another_angle <= 25)
                {
                    //Debug.Log("minus");
                    speed -= 2;
                }
            }
        }
        if (speed >= 150)
        {
            speed = 150;
        }
        if (speed <= 30)
        {
            speed = 30;
        }
        float step = speed * Time.deltaTime;
        
        var targetRotation = Quaternion.LookRotation(waypoint[index].transform.position - transform.position);
        Debug.Log(index);

            


        //Debug.Log(targetRotation[0]);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        if (index == 49)
        {
            transform.eulerAngles = new Vector3((float)-90, (float)0, (float)120);
        }
        if (index == 50)
        {
            transform.eulerAngles = new Vector3((float)-33.054, (float)-54.579, (float)-180);
        }
        if (index == 51)
        {
            transform.eulerAngles = new Vector3((float)-0.543, (float)-65.952, (float)-180);
        }
        if (index == 52)
        {
            transform.eulerAngles = new Vector3((float)27.768, (float)-58.934, (float)-180);
        }
        if (index == 53)
        {
            transform.eulerAngles = new Vector3((float)90, (float)0, (float)-120);
        }
        /*if (index == 54)
        {
            transform.eulerAngles = new Vector3(-180, 210, 0);
        }
        if (index == 55)
        {
            transform.eulerAngles = new Vector3(-210, 210, 0);
        }
        if (index == 56)
        {
            transform.eulerAngles = new Vector3(-240, 210, 0);
        }
        if (index == 57)
        {
            transform.eulerAngles = new Vector3(-270, 210, 0);
        }*/
        transform.position = Vector3.MoveTowards(transform.position, waypoint[index].transform.position, step);
    }
}
