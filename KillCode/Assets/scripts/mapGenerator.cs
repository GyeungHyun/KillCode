using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 1. 동굴 생성 알고리즘으로 길 생성
 * 2. BSP를 통해 건물 생성
 * 3. 동굴 생성 알고리즘에서 생성된 길과 맞닿는 건물 삭제
 * */

public class mapGenerator : MonoBehaviour
{
    public GameObject Building;
    public Transform Ground;
    public int count = 20;                                                                         //생성할 건물의 갯수
    float weight;
    public float weightScale;


    void Start()
    {
        
        DividingZone(-Ground.transform.localScale.x/2,Ground.transform.localScale.x/2 ,-Ground.transform.localScale.y/2,Ground.transform.localScale.y/2 );
    }


    void DividingZone(float x_start,float x_end, float y_start, float y_end)                       //구역을 나누는 재귀함수
    {
                                                                                                 //x는 구역의 가로길이, y는 구역의 세로길이
        int decider;                                                                               //가로와 세로 중 어느방향으로 나눌지 정함
        decider = Random.Range(0, 1);                                                              //decider = 0 은 가로, decider = 1은 세로
        float center = 0;                                                                          //x,y좌표를 반으로 나눌 때, 나눈 위치를 기억
       


        if(count > 0)
        {
            if(decider == 0 )
            {
                Vector3 a = new Vector3(x_start,0f,x_end);
                Vector3 b = new Vector3(y_start,0f,y_end);
                Debug.DrawLine(a, b, Color.red, 100, true);
                count--;
                weight = (x_end-x_start)*weightScale;
                center = Random.Range(x_start + weight, x_end - weight);                           //x를 반으로 나눔
                DividingZone(x_start, center, y_start, y_end);
                DividingZone(center, x_end, y_start, y_end);
            }
            else if(decider == 1 )
            {
                Vector3 a = new Vector3(x_start,0f,x_end);
                Vector3 b = new Vector3(y_start,0f,y_end);
                Debug.DrawLine(a, b, Color.red, 10, true);
                count--;
                weight = (y_end-y_start)*weightScale;
                center = Random.Range(y_start + weight, y_end - weight);                           //y를 반으로 나눔
                DividingZone(x_start, x_end, y_start, center);
                DividingZone(x_start, x_end, center, y_end);
            }
        }
        else
        {
            if(decider == 0)                                                                        //마지막에 가로로 나눴는지, 세로로 나눴는지를 판별
            {
                generateBuilding(x_start,center,y_start,y_end);
                generateBuilding(center,x_end,y_start,y_end);  
            }
            else
            {
                generateBuilding(x_start,x_end,y_start,center);
                generateBuilding(x_start,x_end, center,y_end);
            }
        }
    }


    void generateBuilding(float x_start, float x_end, float y_start, float y_end)                    //건물 배치 함수
    {
        
        Vector3 spawnPos;
        spawnPos = new Vector3(
            Random.Range(x_start,x_end),
            0f,
            Random.Range(y_start,y_end)
        );

        Instantiate(Building,spawnPos,Quaternion.identity);
       
    }

}