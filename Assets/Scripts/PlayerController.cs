using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float playerMoveSpeed = 2.0f;

    protected Vector2 move;

    private SpriteRenderer playerSpriteRenderer;
    public GameObject bulletPrefab;

    void Start()
    {
        playerSpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update ()
    {
        move = GetInputVector(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        this.transform.Translate(move * playerMoveSpeed);

        if (Input.GetKeyDown("space"))
        {
            GameObject bulletInstance = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletInstance.tag = "PlayerBullet";
            bulletInstance.transform.Rotate(0, 0, Input.mousePosition.z);
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
