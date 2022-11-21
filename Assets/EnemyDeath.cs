using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour {

    int health = 4;
    public Animator anim;
    public Player player;

    void  OnTriggerEnter2D(Collider2D col) { 

        if (col.gameObject.tag.Equals("Bullet")) {

            if ( health <= 0) {
                anim.SetTrigger("Dying");
                Destroy(gameObject, 2);
                player.kills++;
            } else {
                health--;
            }

        }

    }

    void Update() {
        
    }
}
