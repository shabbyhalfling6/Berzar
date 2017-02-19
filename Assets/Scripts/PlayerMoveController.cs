using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour {


    private float playerMoveSpeed = 0.03f;

    protected Vector2 move;

    private SpriteRenderer playerSpriteRenderer;

    void Start()
    {
        playerSpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update ()
    {
        move = GetInputVector(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        this.transform.Translate(move * playerMoveSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "PlayerObstacle")
        {
            Debug.Log("test");
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
