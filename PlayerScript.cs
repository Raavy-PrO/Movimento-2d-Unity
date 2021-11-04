using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float Velocidade;
    public string estado;
    private string AR = "ar";
    private string CHAO = "chao";
    private float jumpTimeCounter;
    public float jumpTime;
    public float jumpForce;
    private bool isJumping;
    public float moveSpeed;
    private float moveInput;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        moveInput =  Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
    void Update()
    {
        KeyInputs();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground"){
            estado = CHAO;
        }
    }
     private void OnCollisionExit2D(Collision2D collision) {
       if(estado == CHAO){
           if(collision.gameObject.tag == "Ground"){
               estado = AR;
           }
       }
    }

    private void KeyInputs(){
        if(Input.GetKeyDown (KeyCode.Space) && estado == CHAO){
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
        }
        if(Input.GetKey(KeyCode.Space) && isJumping==true){
            if(jumpTimeCounter>0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else{isJumping = false;}
        }
        if(Input.GetKeyUp(KeyCode.Space)){isJumping = false;}
    }
}
