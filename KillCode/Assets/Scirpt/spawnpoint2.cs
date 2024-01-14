using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class spawnpoint2 : MonoBehaviour
{
    public GameObject[] mapList;
    Dictionary<GameObject,int> mapValue = new Dictionary<GameObject, int>();
    public Transform[] randomSpanwpoints;

    public Enemysss melee,range;
    int isMap;

    private void Start() 
    {
        mapList = GameObject.FindGameObjectsWithTag("map");     //maplist[0] = map3, maplist[1] = map2, maplist[2] = map1로 저장됨(why? 나중에 생성된것부터 인덱스 0으로 저장함)
        reverseArray(mapList, mapList.Length);  //역순으로 정렬
        mapValueSetting();
    }

    private void Update()
    {
        switch(Input.inputString)
        {
            case "1":
                mapChange("1");
                break;

            case "2":
                mapChange("2");
                break;

            case "3":
                mapChange("3");
                break;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            int rangeGacha = Random.Range(0,mapValue[mapList[isMap]]/2);
            for(int i = 0; i < rangeGacha; i++)
            {
                int ranspanw = Random.Range(0, randomSpanwpoints.GetLength(0));
                Instantiate(range.prefabs, randomSpanwpoints[ranspanw]);
            }
            Debug.Log("<b><color=red>원거리 "+ rangeGacha +"명</color></b> 소환");      //현재 문제점 : 같은 곳에 2번 소환하면 버그남
            for(int i = 0; i < (mapValue[mapList[isMap]] - rangeGacha*2); i++)
            {
                int ranspanw = Random.Range(0, randomSpanwpoints.GetLength(0));
                Instantiate(melee.prefabs, randomSpanwpoints[ranspanw]);
            }
            Debug.Log("<b><color=blue>근거리 " + (mapValue[mapList[isMap]] - rangeGacha*2) + "명</color></b> 소환");
        }
    }

    void mapChange(string s)
    {
        isMap = int.Parse(s) - 1;
        Debug.Log("map 1-"+ s +"로 바뀜");
        Debug.Log("현재 맵 밸류 : " + mapValue[mapList[isMap]]);

        randomSpanwpoints = new Transform[mapList[isMap].transform.Find("spawnpoints").GetComponentsInChildren<Transform>().Length - 1];    //배열 할당(?)
        for (int i = 0; i < randomSpanwpoints.GetLength(0); i++)
        {
            randomSpanwpoints[i] = mapList[isMap].transform.Find("spawnpoints").transform.GetChild(i);    //배열에 오브젝트 넣기
        }
    }

    void mapValueSetting()
    {
        mapValue.Add(mapList[0], 6);       //map1-1 = 6
        mapValue.Add(mapList[1], 9);        //map1-2 = 8
        mapValue.Add(mapList[2], 10);        //map1-1 = 10
    }

    void reverseArray(GameObject[] m, int size)
    {
        GameObject temp;
        for (int i = 0; i < (size-1) / 2; i++)
        {
            Debug.Log("실행중"+i);
            temp = m[i];
            m[i] = m[size - i - 1]; // 요소가 10개일때 마지막 요소는 9
            m[size - i - 1] = temp;
        }
    }
}
