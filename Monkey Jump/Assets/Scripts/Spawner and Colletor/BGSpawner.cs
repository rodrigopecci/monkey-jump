using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    private GameObject[] bgs;
    private float fHeight;
    private float fHighestPosY;

    private void Awake()
    {
        bgs = GameObject.FindGameObjectsWithTag("BG");
    }

    private void Start()
    {
        fHeight = bgs[0].GetComponent<BoxCollider2D>().bounds.size.y;
        fHighestPosY = bgs[0].transform.position.y;

        for (int i = 0; i < bgs.Length; i++)
        {
            if (bgs[i].transform.position.y > fHighestPosY)
            {
                fHighestPosY = bgs[i].transform.position.y;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BG")
        {
            if (other.transform.position.y >= fHighestPosY)
            {
                Vector3 v3tmp = other.transform.position;
                        
                for (int i = 0; i < bgs.Length; i++)
                {
                    if (!bgs[i].activeInHierarchy)
                    {
                        v3tmp.y += fHeight;

                        bgs[i].transform.position = v3tmp;
                        bgs[i].gameObject.SetActive(true);

                        fHighestPosY = v3tmp.y;
                    }
                }
            }
        }
    }
}
