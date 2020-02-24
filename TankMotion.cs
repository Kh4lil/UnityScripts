using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMotion : MonoBehaviour
{
    public GameObject tankBody;
    public GameObject turret;

    private float m_Speed; //Sets the speed.
    private char m_driveMode; //Used to decide if drive or reverse gears are used. 


    // Use this for initialization
    void Start()
    {
        m_Speed = 2.0f; //Set the speed of the GameObject
        m_driveMode = 'D'; //Set the drivemode to forward. 
    }

    // Update is called once per frame
    void Update()
    {

        // Change gears
        if (Input.GetAxis("Mouse ScrollWheel") != 0f) //Checks if we scrolled up or down.
        {
            if (m_driveMode == 'D') //If drive mode is 'D' we want to switch it to 'R'
            {
                m_driveMode = 'R';
            }
            else    //If it is 'R' we want to switch it to 'D'
            {
                m_driveMode = 'D';
            }
            Debug.Log(m_driveMode);
        }

        //Get user input to move.
        if (Input.GetKey(KeyCode.Mouse2)) //If user clicks on the middle mouse button
        {
            Drive(m_driveMode); //Call the Drive function with either 'D' or 'R' as its parameter. Drive() is defined below. 
        }

        //Turn Right.
        if (Input.GetKey(KeyCode.Mouse1)) //If user right mouse click
        {
            //Rotate our Tank about the Y axis in the positive direction
            transform.Rotate(new Vector3(0, 40, 0) * Time.deltaTime * m_Speed, Space.World);
        }

        //Turn Left.
        if (Input.GetKey(KeyCode.Mouse0)) //If user left mouse click
        {
            //Rotate our Tank about the Y axis in the negative direction
            transform.Rotate(new Vector3(0, -40, 0) * Time.deltaTime * m_Speed, Space.World);
        }

        //TURRET:

        //Turn Right.
        if (Input.GetKey("d")) //If user right mouse click
        {
            //Rotate our Tank about the Y axis in the positive direction
            turret.transform.Rotate(new Vector3(0, 40, 0) * Time.deltaTime * m_Speed, Space.World);
        }

        //Turn Left.
        if (Input.GetKey("a")) //If user left mouse click
        {
            //Rotate our Tank about the Y axis in the negative direction
            turret.transform.Rotate(new Vector3(0, -40, 0) * Time.deltaTime * m_Speed, Space.World);
        }
    }

    /***************************************\
    |                METHODS:               |
    \***************************************/

    /*
    Drive() takes care of moving the Tank. It takes 1 parameter: driveMode that can either be 'D' or 'R' 
    It then checks if it is 'D' it adds transform.forward * Time.deltaTime * m_Speed to our transform.position.
    If it is 'R' it subtract transform.forward * Time.deltaTime * m_Speed from it.
    */
    void Drive(char driveMode)
    {
        if (driveMode == 'D')
        {
            this.transform.position += transform.forward * Time.deltaTime * m_Speed;
        }
        if (driveMode == 'R')
        {
            this.transform.position -= transform.forward * Time.deltaTime * m_Speed;
        }
    }
}
