using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] tilePrefabs;//mang dia hinh
    private int lastPrefabIndex=0;//chi so cuoi
    private Transform player;//nhan vat
    private float spamZ=0.0f;
    private List<GameObject> activeTiles;//dia hinh dang active
    private float safeZone =15.0f;//khoang thi truong camera nhin thay
    private float tileLength=10.0f;//chieu dai 1 dia hinh
    private int tileOnScrenn =3;//so luong dia hinh cung xuat hien



    async void Start()
    {
        activeTiles =new List<GameObject>();
        player=GameObject.FindGameObjectWithTag("player").transform;
        for(int i=0;i<tileOnScrenn;i++){
            if(i<2){
                SinhDiaHinh(0);
            }else{
                SinhDiaHinh();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z - safeZone > (spamZ -tileOnScrenn*tileLength)){
            SinhDiaHinh();
            XoaDiaHinh();
        }
    }

    private void XoaDiaHinh()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private void SinhDiaHinh(int prefabIndex=-1){
        GameObject gameObject;
        if(prefabIndex==-1){
            gameObject=Instantiate(tilePrefabs[RandomPrefabIndex()])as GameObject;
        }else{
            gameObject = Instantiate(tilePrefabs[prefabIndex])as GameObject;
        }
        gameObject.transform.SetParent(transform);
        gameObject.transform.position=Vector3.forward * spamZ;
        spamZ+=tileLength;
        activeTiles.Add(gameObject);
        

    }

    private int RandomPrefabIndex()//lay 1 dia hinh ngau nhien
    {
        if(tilePrefabs.Length<=1){
            return 0;
        }
        int ramdomIndex =lastPrefabIndex;
        while(ramdomIndex==lastPrefabIndex){
            ramdomIndex = UnityEngine.Random.Range(0,tilePrefabs.Length);//ham random

        }
        lastPrefabIndex=ramdomIndex;
        return ramdomIndex;
    }
}
