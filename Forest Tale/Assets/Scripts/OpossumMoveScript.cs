using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumMoveScript : MonoBehaviour {

    public float speed = 2f;
    private float direction = -1;
    private Rigidbody2D Opossum;
    

    private void Awake()
    {
        Opossum = GetComponent<Rigidbody2D>();
        
    }

    void Update ()
    {
        Opossum.velocity = new Vector2(speed * direction, Opossum.velocity.y);// Opossum movement

        transform.localScale = new Vector3(-direction, 1, 1);

        //Saving Opossum position
        if (Input.GetKeyDown(KeyCode.R))
        {
            SaveLoadScript.Save(this.gameObject, "Opossum");
        }

        //Loading Opossum position
        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveLoadScript.Load(this.gameObject, "Opossum");
        }
    }
    
    // Flip Opossum sprite when it collide with invisible wall
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "InvisibleEnemieWall")
        {
            direction *= -1; 
            
        }
    }
    
}
