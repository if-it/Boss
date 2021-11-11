using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorningStar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    [SerializeField] float Speed;
    [SerializeField] float Distane;
    [SerializeField] float MaxSpeed;
    private Vector3 pos;
    private Vector3 vec;
    private Vector3 playerPos;

    void Start()
    {
        playerPos = player.GetComponent<Player>().gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = gameObject.transform.position;
        playerPos = player.GetComponent<Player>().gameObject.transform.position;
        float distance = Vector3.Distance(pos, playerPos);
        // Debug.Log(distance);
        if (distance > Distane)
        {
            Vector3 ang = playerPos - pos;

            ang.Normalize();

            vec += Speed * ang;
        }
        else
        {
            if (vec.x > Speed)
            {
                vec.x -= Speed;
            }
            else if (vec.x < -Speed)
            {
                vec.x += Speed;
            }
            if (vec.x == Speed || vec.x < Speed && vec.x > -Speed)
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
            if (vec.z == Speed || vec.z < Speed && vec.z > -Speed)
            {
                vec.z = 0;
            }
        }
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
        gameObject.transform.position = pos;

    }
}
