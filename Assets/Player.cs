using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Speed;
    [SerializeField] float SubSpeed;
    [SerializeField] float MaxSpeed;
    [SerializeField] float AddPower;
    public Vector3 Vec { get { return vec; } }
    public float Power { get { return power; } }
    public int Skill { get { return skill; } set { skill = value; } }
    private Vector3 pos;
    private Vector3 vec;
    private Vector3 ang;
    private Vector2 key;
    private bool up, down, left, right;
    private Vector3 latestPos;
    private int skill;
    private float power;
    void Start()
    {
        Application.targetFrameRate = 60;
        pos = gameObject.transform.position;
        vec = new Vector3();
        ang = new Vector3();
        key = new Vector2();
        up = false;
        down = false;
        left = false;
        right = false;
        skill = 0;
        latestPos = pos;
    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();
        pos = gameObject.transform.position;
        ang = new Vector3();


        if (right)
        {
            ang.x = 1;

        }
        else if (left)
        {
            ang.x = -1;
        }
        else
        {
            if (vec.x > SubSpeed)
            {
                vec.x -= SubSpeed;
            }
            else if (vec.x < -SubSpeed)
            {
                vec.x += SubSpeed;
            }
            if (vec.x == SubSpeed || vec.x < SubSpeed && vec.x > -SubSpeed)
            {
                vec.x = 0;
            }
        }

        if (up)
        {

            ang.z = 1;
        }
        else if (down)
        {

            ang.z = -1;
        }
        else
        {
            if (vec.z > SubSpeed)
            {
                vec.z -= SubSpeed;
            }
            else if (vec.z < -SubSpeed)
            {
                vec.z += SubSpeed;
            }
            if (vec.z == SubSpeed || vec.z < SubSpeed && vec.z > -SubSpeed)
            {
                vec.z = 0;
            }
        }
        ang.Normalize();
        vec += Speed * ang;
        if (vec.x >= MaxSpeed)
        {
            vec.x = MaxSpeed;
        }
        else if (vec.x <= -MaxSpeed)
        {
            vec.x = -MaxSpeed;
        }

        if (vec.z >= MaxSpeed)
        {
            vec.z = MaxSpeed;
        }
        else if (vec.z <= -MaxSpeed)
        {
            vec.z = -MaxSpeed;
        }


        pos += vec;
        Vector3 diff = pos - latestPos;
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }
        gameObject.transform.position = pos;
        latestPos = pos;
    }

    private void KeyInput()
    {
        key = new Vector2();
        up = false;
        down = false;
        left = false;
        right = false;
        float LStickX = Input.GetAxis("LStick_X");
        float LStickY = Input.GetAxis("LStick_Y");
        if (Input.GetKey(KeyCode.D))
        {
            key.x = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            key.x = -1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            key.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            key.y = -1;
        }
        if (LStickX < 0 || key.x == 1)
        {
            right = true;
        }
        if (LStickX > 0 || key.x == -1)
        {
            left = true;
        }
        if (LStickY > 0 || key.y == 1)
        {
            up = true;
        }
        if (LStickY < 0 || key.y == -1)
        {
            down = true;
        }
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey("joystick button 0")))
        {
            if(skill==0)power += AddPower;
            if (skill == 3) skill = 4;
        }
        if (skill == 0 && (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp("joystick button 0")))
        {
            skill = 1;
        }
    }
}
