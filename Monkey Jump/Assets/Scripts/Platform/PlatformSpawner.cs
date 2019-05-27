using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;

    [SerializeField]
    private GameObject goPlatformLeft, goPlatformRight;

    private float fLeftMinX = -4.4f, fLeftMaxX = -2.8f, fRightMinX = 4.4f, fRightMaxX = 2.8f;
    private float fTresholdY = 2.6f;
    private float fLastY;

    [SerializeField]
    private int iSpawnCount = 8;

    private int iPlatformSpawned;

    [SerializeField]
    private Transform tPlatformParent;

    [SerializeField]
    private GameObject goBird;

    [SerializeField]
    private float fBirdY = 5f;

    private float fBirdMinX = -2.3f, fBirdMaxX = 2.3f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        fLastY = transform.position.y;

        SpawnPlatforms();
    }

    public void SpawnPlatforms()
    {
        Vector2 v2tmp = transform.position;
        GameObject newPlatform = null;

        for (int i = 0; i < iSpawnCount; i++)
        {
            v2tmp.y = fLastY;

            if ((iPlatformSpawned % 2) == 0)
            {
                v2tmp.x = Random.Range(fLeftMinX, fLeftMaxX);
                newPlatform = Instantiate(goPlatformRight, v2tmp, Quaternion.identity);
            } else
            {
                v2tmp.x = Random.Range(fRightMinX, fRightMaxX);
                newPlatform = Instantiate(goPlatformLeft, v2tmp, Quaternion.identity);
            }

            newPlatform.transform.parent = tPlatformParent;

            fLastY += fTresholdY;
            iPlatformSpawned++;
        }

        if (Random.Range(0, 2) > 0)
        {
            SpawnBird();
        }
    }

    void SpawnBird()
    {
        Vector2 v2tmp = transform.position;

        v2tmp.x = Random.Range(fBirdMinX, fBirdMaxX);
        v2tmp.y += fBirdY;

        GameObject newBird = Instantiate(goBird, v2tmp, Quaternion.identity);
        newBird.transform.parent = tPlatformParent;
    }
}
