using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumMoveScript : MonoBehaviour {

    public float speed;
    private Rigidbody2D Opossum;
    private float direction;

    private void Awake()
    {
        Opossum = GetComponent<Rigidbody2D>();
        direction = -Opossum.transform.localScale.x;
        
    }

    void Update ()
    {
        Opossum.velocity = new Vector2(speed * direction, Opossum.velocity.y);// Opossum movement

        transform.localScale = new Vector3(-direction, Opossum.transform.localScale.y, Opossum.transform.localScale.z);

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
