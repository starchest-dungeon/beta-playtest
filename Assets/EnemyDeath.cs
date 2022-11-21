using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour {

    int health = 4;
    public Animator anim;
    public Player player;
    public Text totalKills;

    void  OnTriggerEnter2D(Collider2D col) { 

        if (col.gameObject.tag.Equals("Bullet")) {

            if (health <= 0) {
                anim.SetTrigger("Dying");
                Debug.Log("dies");
                player.kills++;
                totalKills.text = "Kills: " + player.kills;
                Destroy(gameObject, 0.5f);
            } else {
                health--;
            }

        }

    }

    void Start() {
        totalKills.text = "Kills: " + player.kills;
    }
}
