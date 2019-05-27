using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField]
    private float fMoveSpeed = 4f;

    [SerializeField]
    private float fNormalPush = 10f;

    [SerializeField]
    private float fExtraPush = 14f;

    private bool bInitialPush;

    private int iPushCount;

    private bool bPlayerDied;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (bPlayerDied)
        {
            return;
        }

        float fMovement = Input.GetAxisRaw("Horizontal");

        if (fMovement > 0)
        {
            rb.velocity = new Vector2(fMoveSpeed, rb.velocity.y);
        } else if (fMovement < 0)
        {
            rb.velocity = new Vector2(-fMoveSpeed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (bPlayerDied)
        {
            return;
        }

        if (other.tag == "ExtraPush" && !bInitialPush)
        {
            bInitialPush = true;

            rb.velocity = new Vector2(rb.velocity.x, 18f);
            other.gameObject.SetActive(false);

            SoundManager.instance.JumpSoundFX();

            return;
        }

        if (other.tag == "NormalPush")
        {
            rb.velocity = new Vector2(rb.velocity.x, fNormalPush);
            other.gameObject.SetActive(false);

            iPushCount++;

            SoundManager.instance.JumpSoundFX();
        }

        if (other.tag == "ExtraPush")
        {
            rb.velocity = new Vector2(rb.velocity.x, fExtraPush);
            other.gameObject.SetActive(false);

            iPushCount++;

            SoundManager.instance.JumpSoundFX();

            return;
        }

        if (iPushCount == 2)
        {
            iPushCount = 0;
            PlatformSpawner.instance.SpawnPlatforms();
        }

        if (other.tag == "FallDown" || other.tag == "Bird")
        {
            bPlayerDied = true;

            SoundManager.instance.GameOverSoundFX();

            GameManager.instance.RestartGame();
        }
    }
}
