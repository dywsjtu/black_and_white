using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 start;

    public AudioClip jump;

    public AudioClip color;

    
    Camera camera;
    public float moveSpeed;

    public float jumpHeight;

    private bool isBlack = false;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("test space");
            if (rb.velocity.y == 0)
            {
                Debug.Log("test y velocity");
                AudioSource.PlayClipAtPoint(jump, Camera.main.transform.position);
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            AudioSource.PlayClipAtPoint(color, Camera.main.transform.position);
            ChangeColor();
        }
        if (Input.GetKey ("escape")) 
        {
            SceneManager.LoadScene(0);
        }
        if (transform.position.y < -12) 
        {
            rb.velocity = Vector2.zero;
            transform.position = start;
        }
    }

    public void ChangeColor()
    {
        if (isBlack) 
        {
            EventBus.Publish<ChangeColorEvent>(new ChangeColorEvent(false));
            camera.backgroundColor = Color.black;
            GetComponent<SpriteRenderer>().material.color = Color.white;
        }
        else 
        {
            EventBus.Publish<ChangeColorEvent>(new ChangeColorEvent(true));
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


public class ChangeColorEvent
{
    public bool white2Black = false;

    public bool black2White = false;
    public ChangeColorEvent(bool input) 
    {
        white2Black = input;
        black2White = !white2Black;
    }
    public override string ToString()
    {
        return "white2Black: " +  white2Black;
    }
}