using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 distance;
    [SerializeField] GameObject player;
    void Start()
    {
        distance = gameObject.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = Vector3.Lerp(player.transform.position + distance, gameObject.transform.position, 0.5f);
        gameObject.transform.position = player.transform.position + distance;
    }
}
