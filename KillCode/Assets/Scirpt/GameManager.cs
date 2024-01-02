using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public weapon Annie_W;
    public GameObject popup;
    public GameObject player;
    private void Start() 
    {
        popup.SetActive(false);
        Annie_W.Level = 0;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(popup.activeSelf == true)  
                popup.SetActive(false);
            else
                popup.SetActive(true);
        }    
    }

    public void onAnnie_W()
    {
        Annie_W.Level++;
        Annie_W.damage = Annie_W.Level*5;
        Annie_W.count = Annie_W.Level * 1;

        GameObject[] counts = new GameObject[Annie_W.count];

        for(int i = 0; i < Annie_W.count; i++)
        {
            if(counts[i] == null)
            {
                counts[i] =  Instantiate(Annie_W.Prefab, player.transform);
            }
            Debug.Log(counts[i]);
        }
        for(int i = 0 ; i < Annie_W.count; i++)
        {
            counts[i].transform.Translate(new Vector3(i + 0.1f, 2f, 0));
        }
        Debug.Log("화염방사 장착");
    }

    void onClickshuriken()
    {
        
    }

    void onClickDemon()
    {

    }

    void popupSystem()
    {
        if(popup.activeSelf == true)
        {
            popup.SetActive(false);
        }
    }
}
