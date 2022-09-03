using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCam : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;

    private void OnEnable()
    {
        FindPlayer();
    }

    void Update()
    {
        CamFollow();
    }

    public void FindPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void CamFollow()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -6.5f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
