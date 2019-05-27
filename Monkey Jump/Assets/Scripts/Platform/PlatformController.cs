using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private GameObject goBanana, goBananas;

    [SerializeField]
    private Transform tSpawnPoint;

    void Start()
    {
        GameObject newBanana = null;

        if (Random.Range(0, 10) > 2)
        {
            newBanana = Instantiate(goBanana, tSpawnPoint.position, Quaternion.identity);
        } else
        {
            newBanana = Instantiate(goBananas, tSpawnPoint.position, Quaternion.identity);
        }

        newBanana.transform.parent = transform;
    }
}
