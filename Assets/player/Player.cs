using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Speed;

    private Vector3 pos;
    private Vector3 vec;
    void Start()
    {
        Application.targetFrameRate = 60;
        pos = gameObject.transform.position;
        vec = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        pos = gameObject.transform.position;

        vec.x += Speed * -Input.GetAxis("LStick_X");
        vec.z += Speed * Input.GetAxis("LStick_Y");

        Debug.Log("X" + Input.GetAxis("LStick_X"));
        Debug.Log("Z" + Input.GetAxis("LStick_Y"));

        Debug.Log(vec);
        if (vec.x > Speed)
        {
            vec.x -= Speed;
        }
        else if (vec.x < -Speed)
        {
            vec.x += Speed;
        }
        if(vec.x<Speed&&vec.x>-Speed)
        {
            vec.x = 0;
        }

        if (vec.z > Speed)
        {
            vec.z -= Speed;
        }
        else if (vec.z < -Speed)
        {
            vec.z += Speed;
        }
        if (vec.z < Speed && vec.z > -Speed)
        {
            vec.z = 0;
        }
        pos += vec;

        gameObject.transform.position = pos;
    }
}
