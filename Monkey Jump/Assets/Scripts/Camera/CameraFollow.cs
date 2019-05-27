using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform tTarget;

    private bool bFollowPlayer;

    [SerializeField]
    private float fTresholdMinY = -2.6f;

    void Awake()
    {
        tTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Follow();   
    }

    void Follow()
    {
        if (tTarget.position.y < (transform.position.y - fTresholdMinY))
        {
            bFollowPlayer = false;
        }

        if (tTarget.position.y > transform.position.y)
        {
            bFollowPlayer = true;
        }

        if (bFollowPlayer)
        {
            Vector3 v3tmp = transform.position;
            v3tmp.y = tTarget.position.y;

            transform.position = v3tmp;
        }
    }
}
