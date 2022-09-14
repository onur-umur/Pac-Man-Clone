using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    

    void Start()
    {
        dest = transform.position;
    }


    void FixedUpdate() {
    
    Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
    GetComponent<Rigidbody2D>().MovePosition(p);

    
    if ((Vector2)transform.position == dest) {
        if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up)){
            dest = (Vector2)transform.position + Vector2.up;
            Debug.Log("Yukarı");
        }
            
        if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right)){
            dest = (Vector2)transform.position + Vector2.right;
            Debug.Log("Sağ");
        }
            
        if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up)){
            dest = (Vector2)transform.position - Vector2.up;
            Debug.Log("Aşağı");
        }
            
        if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right)){
            dest = (Vector2)transform.position - Vector2.right;
            Debug.Log("sol");
        }
            
    }

    // Animation Parameters
    Vector2 dir = dest - (Vector2)transform.position;
    GetComponent<Animator>().SetFloat("DirX", dir.x);
    GetComponent<Animator>().SetFloat("DirY", dir.y);
}

    bool valid(Vector2 dir){
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos+dir,pos);
        return (hit.collider== GetComponent<Collider2D>());
    }
}
