using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public DeadMenu deadMenu;//khai bao Deadmenu trong score
    public Text score;
    private float s=0.0f;//diem ban dau
    private int difficultLevel=1;//do kho level luc khoi tao
    private int maxDifficultLevel=10;//cap do kho
    private int scoreToNextLevel=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead){
            return;
        }
        if(s>=scoreToNextLevel){
            TangLevel();//tang toc
        }
        s+=Time.deltaTime *difficultLevel;//diem
        score.text=((int)s).ToString();


    
    }

    //ham tang level
    void TangLevel(){
        if(difficultLevel==maxDifficultLevel){//neu het lecel thi k lam gi nua
            return;
        }
        scoreToNextLevel=scoreToNextLevel*2;//nhan doi diem
        difficultLevel++;
        GetComponent<PlayerController>().SetSpeed(difficultLevel);//goi ham set speed tu playerController

    }
    private bool isDead=false;//khong chet
    public void onDeath(){
        isDead=true;//khi nhan vat chet
        // GetComponent<DeadMenu>().ToggleEndMenu(((int)s).ToString());
        deadMenu.ToggleEndMenu(((int)s).ToString());
    }
}
