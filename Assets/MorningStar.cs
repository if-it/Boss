using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorningStar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    [SerializeField] float SubSpeed;
    [SerializeField] float Distane;
    [SerializeField] float MaxSpeed;
    private Vector3 pos;
    private Vector3 vec;
    private float speed;
    private Vector3 playerPos;
    Player player_Component;

    void Start()
    {
        playerPos = player.gameObject.transform.position;
        player_Component = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = gameObject.transform.position;
        playerPos = player.gameObject.transform.position;
        switch (player_Component.Skill)
        {
            case 0:
               if(player.transform.rotation.y>=0) pos = Vector3.Lerp(pos, new Vector3(playerPos.x + 5, playerPos.y, playerPos.z - 5), 0.5f);
               else if(player.transform.rotation.y < 0) pos = Vector3.Lerp(pos, new Vector3(playerPos.x + 5, playerPos.y, playerPos.z - 5), 0.5f);
                break;
            case 1:
                transform.rotation = player.gameObject.transform.rotation;
                player_Component.Skill = 2;
                break;
            case 2:
                speed = player_Component.Power;
                if (speed > MaxSpeed)
                {
                    speed = MaxSpeed;
                }
                vec = transform.forward * speed;
                player_Component.Skill = 3;
                break;
            case 4:
                vec *= -1;
                player_Component.Skill = 5;
                break;
            default:
                break;
        };

        pos += vec;
        gameObject.transform.position = pos;

    }
}
