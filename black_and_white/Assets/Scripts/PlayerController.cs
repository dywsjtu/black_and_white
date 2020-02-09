using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject[] whitefloors;

    public GameObject[] blackfloors;

    Camera camera;
    public float moveSpeed;

    public float jumpHeight;

    private bool isBlack = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal != 0f)
        {
            rb.velocity = new Vector2(moveHorizontal*moveSpeed, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.velocity.y == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
        }
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        if (isBlack) 
        {
            whitefloors[0].GetComponent<SpriteRenderer>().material.color = Color.white;
            blackfloors[0].GetComponent<SpriteRenderer>().material.color = Color.gray;
            camera.backgroundColor = Color.black;
            GetComponent<SpriteRenderer>().material.color = Color.white;
        }
        else 
        {
            whitefloors[0].GetComponent<SpriteRenderer>().material.color = Color.gray;
            blackfloors[0].GetComponent<SpriteRenderer>().material.color = Color.black;
            camera.backgroundColor = Color.white;
            GetComponent<SpriteRenderer>().material.color = Color.black;
        }
        isBlack = !isBlack;
        
    }

    public bool GetColor()
    {
        return isBlack;
    }
}
