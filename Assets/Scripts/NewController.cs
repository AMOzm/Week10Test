using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameManager gm;
    GameObject player;
    Transform playerTransform;
    Vector2 playerPos;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float leftBarrier;
    [SerializeField] private float rightBarrier;
    private string tag;
    public Vector2 originalPos;
    void Start()
    {
        tag = gameObject.tag;
        Debug.Log("I am:" + tag);
        playerPos = gameObject.transform.position;
        Debug.Log(playerPos);
        originalPos = new Vector2 (transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
            //GetKeyUp
            //GetKeyDown
            //GetKey is the only continuos
            gameObject.transform.position = playerPos;
        }

    void PlayerInput(){
        if (gm.gameState != GameManager.State.GamePlay) return;
        bool moveLeft = false;
        bool moveRight = false;
        switch (tag){
            case "PlayerOne":
            if (Input.GetKey(KeyCode.A)){
                moveLeft = true;
            }
            else {
                moveLeft = false;
            }
            break;
            case "PlayerTwo":
            if (Input.GetKey(KeyCode.LeftArrow)){
                moveLeft = true;
            }
            else {
                moveLeft = false;
            }
            break;
            default:
            break;
        }
        if (moveLeft){
            if (playerPos.x <= leftBarrier) return;
            playerPos.x -= moveSpeed * Time.deltaTime;
        }
        switch (tag){
            case "PlayerOne":
            if (Input.GetKey(KeyCode.D)){
                moveRight = true;
            }
            else {
                moveRight = false;
            }
            break;
            case "PlayerTwo":
            if (Input.GetKey(KeyCode.RightArrow)){
                moveRight = true;
            }
            else {
                moveRight = false;
            }
            break;
            default:
            break;
        }
        if (moveRight){
            if (playerPos.x >= rightBarrier) return;
            playerPos.x += moveSpeed * Time.deltaTime;
        }
        // if(Input.GetKey(KeyCode.A)){
        //     Debug.Log("you Pressed A");
        //     if (playerPos.x <= leftBarrier) return;
        //     playerPos.x -= moveSpeed * Time.deltaTime;
        // }
        // if(Input.GetKey(KeyCode.D)){
        //     playerPos.x += moveSpeed * Time.deltaTime;
        //     if (playerPos.x >= rightBarrier) return;
        // }
    }

    void Reset(){
        if (gm.gameState == GameManager.State.GameStart){
            gameObject.transform.position = originalPos;
        }
    }
}