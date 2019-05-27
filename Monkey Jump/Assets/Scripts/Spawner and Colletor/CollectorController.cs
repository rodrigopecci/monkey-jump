using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BG" || other.tag == "Platform" || other.tag == "NormalPush" || other.tag == "ExtraPush" || other.tag == "Bird")
        {
            other.gameObject.SetActive(false);
        }
    }
}
