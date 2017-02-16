using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour {


    private float playerMoveSpeed = 0.03f;
    private float audioTimer = 0.8f;

    protected Vector2 move;

    private SpriteRenderer playerSpriteRenderer;


    //private AudioSource audio;

    void Start()
    {
        playerSpriteRenderer = this.GetComponent<SpriteRenderer>();
        //audio = GetComponent<AudioSource>();
    }

    void Update ()
    {
        move = GetInputVector(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        this.transform.Translate(move * playerMoveSpeed);
/*
        audioTimer -= Time.deltaTime;

        if (audioTimer <= 0)
        {
            audio.Play();
            audioTimer = 0.7f;
        }*/
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "playerObstacle")
        {
            Destroy(this.gameObject);
        }
    }

    public Vector2 GetInputVector(float horizontalMove, float verticalMove)
    {
        FlipSprite(horizontalMove, verticalMove);

        return new Vector2(horizontalMove, verticalMove);
    }

    private void FlipSprite(float horizontalMove, float veticalMove)
    {
        if (horizontalMove < 0)
        {
            playerSpriteRenderer.flipX = true;
        }
        else if (horizontalMove > 0)
        {
            playerSpriteRenderer.flipX = false;
        }
    }
}
