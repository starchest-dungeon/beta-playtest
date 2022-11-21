using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//referencing potato_1 code

public class ProtagonistBehaviour : MonoBehaviour {

    private Vector2 moveAmount;
    [SerializeField]
    private float speed;
    private Rigidbody2D m_Rb;

    public Animator sideAnim;
    public SpriteRenderer sideRender;
    public GameObject side;

    public Animator frontAnim;
    public GameObject front;

    public Animator backAnim;
    public GameObject back;
 
    void Start() {
        m_Rb = this.GetComponent<Rigidbody2D>();
        front.GetComponent<Renderer>().enabled= false;
        back.GetComponent<Renderer>().enabled= false;
        side.GetComponent<Renderer>().enabled= true;
    }
 
    void Update() {

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
            sideAnim.SetBool("isRunning", true);
            frontAnim.SetBool("isWalking", true);
            backAnim.SetBool("isWalking", true);
        } else {
            sideAnim.SetBool("isRunning", false);
            frontAnim.SetBool("isWalking", false);
            backAnim.SetBool("isWalking", false);
        }

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetAxisRaw("Horizontal") > 0) {
            side.GetComponent<Renderer>().enabled= true;
            front.GetComponent<Renderer>().enabled= false;
            back.GetComponent<Renderer>().enabled= false;
            sideRender.flipX = false;
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            sideRender.flipX = true;
            side.GetComponent<Renderer>().enabled= true;
            front.GetComponent<Renderer>().enabled= false;
            back.GetComponent<Renderer>().enabled= false;
        }

        if (Input.GetAxisRaw("Vertical") > 0) {
            back.GetComponent<Renderer>().enabled= true;
            front.GetComponent<Renderer>().enabled= false;
            side.GetComponent<Renderer>().enabled= false;
        } else if (Input.GetAxisRaw("Vertical") < 0) {
            front.GetComponent<Renderer>().enabled= true;
            side.GetComponent<Renderer>().enabled= false;
            back.GetComponent<Renderer>().enabled= false;
        }


        moveAmount = moveInput.normalized * speed;
    }
 
    private void FixedUpdate() {
        m_Rb.MovePosition(m_Rb.position + moveAmount * Time.fixedDeltaTime);
    }
}
