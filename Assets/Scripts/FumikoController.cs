using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;

public class FumikoController : MonoBehaviour {
    [SerializeField]
    private float speed = 2.0f;

    private Rigidbody2D rigidbody;
    private Animator anim;

    private bool isCollision;
    private bool isMoving;
    private Vector2 lastMove;

    [SerializeField]
    private float timeBetweenMove;
    private float timeBetweenMoveCounter;
    [SerializeField]
    private float timeToMove;
    private float timeToMoveCounter;

    private Vector3 direction;

    [SerializeField]
    private float waitToReload;
    private bool reloading;
    private GameObject player;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
    }

    private void Update() {
        Move();

        if (reloading) {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                player.SetActive(true);
            }
        }
       
    }

    private void Move() {
        if (isMoving) {
            timeToMoveCounter -= Time.deltaTime;
            rigidbody.velocity = direction;

            if (timeToMoveCounter < 0.0f) {
                isMoving = false;

                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }

        }
        else {
            timeBetweenMoveCounter -= Time.deltaTime;
            rigidbody.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0) {
                isMoving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                int dir = Random.Range(-1, 2);
                switch (dir) {
                    case 0: direction = new Vector3(Random.Range(-1.0f, 1.0f) * speed + 0.5f, 0);
                        break;
                    case 1: direction = new Vector3(0, Random.Range(-1.0f, 1.0f) * speed + 0.5f);
                        break;
                }
            }
        }
        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        anim.SetFloat("LastMoveX", direction.x);
        anim.SetFloat("LastMoveY", direction.y);
        anim.SetBool("isMoving", isMoving);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        /*if (collision.gameObject.name == "Character") {
           collision.gameObject.SetActive(false);
           reloading = true;
           player = collision.gameObject;
       }*/
    }

}
