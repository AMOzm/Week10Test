using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ballbehavior : MonoBehaviour
{
    // Start is called before the first frame updat
    [SerializeField] private GameManager gm;
    
    public Vector2 initialForce;
    public Vector2 otherForce;
    public Vector2 originalPos;

    void Start()
    {
        initialForce = new Vector2(100f, 300f);
        otherForce = new Vector2 (-100f, -300f);
        originalPos = new Vector2 (transform.position.x, transform.position.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState == GameManager.State.GameStart){ 
        if(Input.GetKeyDown(KeyCode.Space)){
            GetComponent<Rigidbody2D>().AddForce(initialForce);
            gm.TransitionState(GameManager.State.GamePlay);
        }
        }
        reset();
        
        
    }
    private void reset()
    {
        if(gameObject.transform.position.y < -5.5){
            gm.TransitionState(GameManager.State.GameStart);
            // gm.pTwoText += 1;
            gm.UpdateTwoScore();
            gameObject.transform.position = originalPos;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        if(gameObject.transform.position.y > 5.5){
            gm.TransitionState(GameManager.State.GameStart);
            // gm.pOneText += 1;
            gm.UpdateOneScore();
            gameObject.transform.position = originalPos;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        // if(gameObject.transform.position.x > 8.5){
            
        //     GetComponent<Rigidbody2D>().AddForce(otherForce);
        // }
        // if(gameObject.transform.position.x < -8.5){
            
        //     GetComponent<Rigidbody2D>().AddForce(initialForce);
        // }
        
    }
}
