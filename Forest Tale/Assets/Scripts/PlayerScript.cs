using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    //PUBLIC Variables(need to see in inspector)
    
    public float speed;
    public Transform GroundCheck;
    public LayerMask WhatIsGround;
    public float GroundRadius = 0.2f;
    public UnityEvent OnLandEvent;

    //PRIVATE Variables(hide from other eyes)

    private float jumpForce = 280f;
    private bool grounded;
    private bool FacingRight = true;
    public static int Gems;
    public static int Lives = 3;
    private float move;
    private Vector3 playerPosition;
    private Rigidbody2D Hero;
    private Animator animator;
    private SaveLoadScript SaveLoad;
    private GameObject HeroGO;


    // Variables get components here, when the game is start
    private void Awake()
    {
        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
        playerPosition = gameObject.transform.position;

        Hero = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        HeroGO = GetComponent<GameObject>();
        
    }

    private void FixedUpdate()
    {
        // checking grounded parameter and invoking OnLandEvent
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundRadius, WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }

        //movement

        move = Input.GetAxis("Horizontal");
        Hero.velocity = new Vector2(move * speed, Hero.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(move)); // Runing animation

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && grounded)
        {
            Hero.AddForce(new Vector2(0, jumpForce));
            animator.SetBool("IsJumping", true); // Jumping animation

        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("IsCrouching", true);
        }

        if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("IsCrouching", false);
        }

        // Flipping sprite left or right

        if (move < 0 && FacingRight)
        {
            Flip();
        }
        else if (move > 0 && !FacingRight)
        {
            Flip();
        }
        //Quit from the game when Lives = 0
        if (Lives == 0)
        {
            Application.Quit();
        }

        // Saving
        if (Input.GetKeyDown(KeyCode.R))
        {
            SaveLoadScript.Save(this.gameObject, "Hero");
            PlayerPrefs.SetInt("Lives", Lives);
            PlayerPrefs.SetInt("Gems", Gems);
        }

        // Loading
        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveLoadScript.Load(this.gameObject, "Hero");
            Gems = PlayerPrefs.GetInt("Gems");
            Lives = PlayerPrefs.GetInt("Lives");
        }
    }

    //Dieing from...
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //... enemie
        if (collision.gameObject.tag == "enemie")
        {
            Hero.position = playerPosition;
            Lives-=1;
            Debug.Log("Lives--");
        }

        //... falling
        if (collision.gameObject.tag == "falling")
        {
            Hero.position = playerPosition;
            Lives-=1;
            Debug.Log("Lives--");
        }
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 TheScale = transform.localScale;
        TheScale.x *= -1;
        transform.localScale = TheScale;
    }
    
    // Canceling jump animation when Hero is on land
    public void OnLand()
    {
        animator.SetBool("IsJumping", false);
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), new GUIContent("Gems: " + Gems + "\nLives: " + Lives));
    }
    
}
