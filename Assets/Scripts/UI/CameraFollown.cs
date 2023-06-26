using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollown : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float FollowSpeed = 2f;
    public float yOffset = 1f;

     void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 newPos = new Vector3(player.position.x, player.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }


}
