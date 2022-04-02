using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);//set k hien thi deadmenu
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleEndMenu(string score){
        gameObject.SetActive(true);
    }

}
