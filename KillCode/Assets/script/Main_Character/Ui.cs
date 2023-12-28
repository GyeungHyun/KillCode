using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ui : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI bul_ui;
    public TextMeshProUGUI hp_ui;
    public TextMeshProUGUI time_ui;
    public int bul;
    public int hp;
    public float time;
    public GameObject player;

    private void Awake()
    {   
        player = GameObject.FindWithTag("Player");
        bul = player.GetComponent<Gun_Action>().bullet;
        hp = player.GetComponent<Main_hp>().hp;
        time = player.GetComponent<Main_Move>().time;
    }

    // Update is called once per frame
    void Update()
    {
        bul = player.GetComponent<Gun_Action>().bullet;
        hp = player.GetComponent<Main_hp>().hp;
        time = player.GetComponent<Main_Move>().time;
        bul_ui.text = bul.ToString();
        hp_ui.text = hp.ToString();
        time_ui.text = string.Format("{0:N2}", time);
    }
}
