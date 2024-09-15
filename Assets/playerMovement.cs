using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public Sprite idleSprite1, idleSprite2, idleSprite3, idleSprite4;
    public Sprite runSprite1, runSprite2, runSprite3, runSprite4, runSprite5, runSprite6;
    public Sprite airSprite;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private bool isGrounded = true;
    private float animationTimer = 0f;

    private float animationInterval = 0.1f;

    private int runSpriteNum = 1;
    private int idleSpriteNum = 1;

    public GameManager gameManager;
    public GameObject gameManagerObject;
    private bool isAlive = true;

    public AudioManager audioManager;
    
    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idleSprite4;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Animate();
    }

    private void Move(){
        float moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if(moveInput > 0){
            transform.localScale = new Vector3(4,4,1);
        }
        else if(moveInput < 0){
            transform.localScale = new Vector3(-4,4,1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Enemy")){
            isAlive = false;
            gameManager.EndGame();
        }
    }

    private void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;

            audioManager.PlaySFX(audioManager.jump);
        }
    }

    private void Animate(){
        float moveInput = Input.GetAxis("Horizontal");
        if(!isGrounded){
            spriteRenderer.sprite = airSprite;
        }
        else{
            if(Mathf.Approximately(moveInput, 0)){
                animationTimer += Time.deltaTime;
                if(animationTimer >= animationInterval){
                    animationTimer = 0f;
                    if(idleSpriteNum == 1){
                        spriteRenderer.sprite = idleSprite1;
                        idleSpriteNum++;
                    }
                    else if(idleSpriteNum == 2){
                        spriteRenderer.sprite = idleSprite2;
                        idleSpriteNum++;
                    }
                    else if(idleSpriteNum == 3){
                        spriteRenderer.sprite = idleSprite3;
                        idleSpriteNum++;
                    }
                    else if(idleSpriteNum == 4){
                        spriteRenderer.sprite = idleSprite4;
                        idleSpriteNum = 1;
                    }
                }
            }
            else{
                animationTimer += Time.deltaTime;
                if(animationTimer >= animationInterval){
                    animationTimer = 0f;
                    if(runSpriteNum == 1){
                        spriteRenderer.sprite = runSprite1;
                        runSpriteNum++;
                    }
                    else if(runSpriteNum == 2){
                        spriteRenderer.sprite = runSprite2;
                        runSpriteNum++;
                    }
                    else if(runSpriteNum == 3){
                        spriteRenderer.sprite = runSprite3;
                        runSpriteNum++;
                    }
                    else if(runSpriteNum == 4){
                        spriteRenderer.sprite = runSprite4;
                        runSpriteNum++;
                    }
                    else if(runSpriteNum == 5){
                        spriteRenderer.sprite = runSprite5;
                        runSpriteNum++;
                    }
                    else if(runSpriteNum == 6){
                        spriteRenderer.sprite = runSprite6;
                        runSpriteNum = 1;
                    }

                }
            }
        }
    }
}
