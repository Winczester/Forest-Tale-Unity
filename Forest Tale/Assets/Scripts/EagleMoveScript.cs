using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMoveScript : MonoBehaviour {

    public float speed = 1.2f;
    public float direction = -1f;
    Rigidbody2D Eagle;

    private void Awake()
    {
        Eagle = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        Eagle.velocity = new Vector2(speed * direction, Eagle.velocity.y);//Eagle movement

        transform.localScale = new Vector3(-direction, transform.localScale.y, transform.localScale.z);

        //Saving Eagle position
        if (Input.GetKeyDown(KeyCode.R))
        {
            SaveLoadScript.Save(this.gameObject, "Eagle");
        }

        //Loading Eagle position
        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveLoadScript.Load(this.gameObject, "Eagle");
        }
    }

    // Flip Eagle sprite when it collide with invisible wall
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "InvisibleEnemieWall")
        {
            direction *= -1;
        }
    }
}
