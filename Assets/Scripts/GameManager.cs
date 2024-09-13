using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int pOneScore = 0;
    public int pTwoScore = 0;
    [SerializeField] private TextMeshProUGUI pOneText;
    [SerializeField] private TextMeshProUGUI pTwoText;

    public State gameState;

    public enum State {
        GameStart,
        GamePlay,
        GameEnd
    }
    void Start()
    {
        pOneText.text = $"Player One: {pOneScore}";
        pTwoText.text = $"Player Two: {pTwoScore}";
    }

    // Update is called once per frame
    void Update()
    {
        pOneText.text = $"Player One: {pOneScore}";
        pTwoText.text = $"Player Two: {pTwoScore}";
        
        if(pOneScore == 3 ||pTwoScore == 3){
            TransitionState(State.GameEnd);
        }
    }

    public void TransitionState(State newState){
            gameState = newState;
            switch (newState){
                case State.GameStart:
                break;
                case State.GamePlay:
                break;
                case State.GameEnd:
                Debug.Log("Game over Now, ");
                if(pOneScore > pTwoScore){
                    Debug.Log("");
                }else if (pOneScore < pTwoScore){
                    Debug.Log("pTwo won");
                }
                break;
            }
        }

    public void UpdateOneScore(){
        pTwoScore =  pTwoScore + 1;
        //pTwoText.text = $"Player Two: {pTwoScore}";
        
    }
    public void UpdateTwoScore(){
        pOneScore =  pOneScore + 1;
        //pOneText.text = $"Player One: {pOneScore }";
        
    }
    
}
