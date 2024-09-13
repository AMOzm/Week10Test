using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject alienPrefab;
    private float timer = 1;
    private int gridXPos = 0;
    private int gridYPos = 0;
    void Start()
    {
        for (int x = -6; x <= 6; x++){
            for(int y = -1; y <= 2; y++){
                Instantiate(alienPrefab, new Vector2(x,y+5), Quaternion.identity, gameObject.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<= 0.0f){
            Debug.Log("Timer was Called");
            MoveGrid();
        }
    }
    private void MoveGrid(){
        switch (gameObject.transform.position.y){
            case 0:
            if(gridXPos == 3.5){
                gridYPos -= 1;
                gameObject.transform.position = new Vector2(gridXPos, gridYPos);
            }
            else{
                gridXPos += 1;
                gameObject.transform.position = new Vector2(gridXPos, gridYPos);
            }
                timer = 1.0f;
                break;
            case -1:
            if(gridXPos == -3.5){
                gridYPos -= 1;
                gameObject.transform.position = new Vector2(gridXPos, gridYPos);
            }
            else{
                gridXPos -= 1;
                gameObject.transform.position = new Vector2(gridXPos, gridYPos);
            }
                timer = 1.0f;
                break;
        }
    }
}
