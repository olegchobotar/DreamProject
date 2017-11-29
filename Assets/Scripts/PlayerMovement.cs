using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float speed = 0.1f;
    private float currentSpeed;
    public float diagonalMoveModifier;

    private Animator anim;
    private Rigidbody2D rigidbody = new Rigidbody2D();
    private PolygonCollider2D sword;

    private bool playerMoving;
    private Vector2 lastMove;

    private static bool playerExists;   //существует ли игрок на карте

    public bool isAttacking;
    [SerializeField]
    private float attackTime;
    private float attackTimeCounter;

    public string startPoint;
    private PlayerStartPoint spToLoad;


    private void Start() {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        sword = GetComponentInChildren<PolygonCollider2D>();

        if (!playerExists) {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else {
            Destroy(gameObject);
        }
        
    }

    private void Update () {
        Move();     
    }

    private void Move() {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        playerMoving = false;

        if (!isAttacking) {

            if (Mathf.Abs(horizontalAxis) > 0.1f && Mathf.Abs(verticalAxis) > 0.1f) {
                currentSpeed = speed * diagonalMoveModifier;
            }
            else {
                currentSpeed = speed;
            }

            if (horizontalAxis > 0.1f || horizontalAxis < -0.1f) {
                rigidbody.velocity = new Vector2(horizontalAxis * currentSpeed, rigidbody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(horizontalAxis, 0.0f);
            }

            if (verticalAxis > 0.1f || verticalAxis < -0.1f) {
                //transform.Translate(new Vector3(0.0f, verticalAxis * speed * Time.deltaTime, 0.0f));
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, verticalAxis * currentSpeed);
                playerMoving = true;
                lastMove = new Vector2(0.0f, verticalAxis);
            }

            if (horizontalAxis < 0.1f && horizontalAxis > -0.1f) {
                rigidbody.velocity = new Vector2(0.0f, rigidbody.velocity.y);
            }

            if (verticalAxis < 0.1f && verticalAxis > -0.1f) {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0.0f);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl)) {
                attackTimeCounter = attackTime;
                isAttacking = true;
                sword.enabled = true;
                rigidbody.velocity = Vector2.zero;
                anim.SetBool("Attacking", true);
            }
        }

        if (attackTimeCounter > 0) attackTimeCounter -= Time.deltaTime;


        if (attackTimeCounter < 0) {
            isAttacking = false;
            sword.enabled = false;
            anim.SetBool("Attacking", false);
        }

        anim.SetFloat("MoveX", horizontalAxis);
        anim.SetFloat("MoveY", verticalAxis);
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}