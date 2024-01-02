using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class spawnpoint2 : MonoBehaviour
{
    public GameObject[] mapList;
    Dictionary<GameObject,int> mapValue = new Dictionary<GameObject, int>();
    public Transform[] randomSpanwpoints;
    public Transform[] ConSpawnpoints;

    public Enemysss melee;
    public Enemysss range;
    int isMap = 2;

    private void Start() 
    {
        mapList = GameObject.FindGameObjectsWithTag("map");
        mapValueSetting();
    }

    private void Update() 
    {
        mapChange();
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            // ConSpawnpoints = new Transform[GameObject.FindWithTag("ConSpawnpoint").GetComponentsInChildren<Transform>().Length-1];  //배열 할당(?)
            // for(int i = 0; i < ConSpawnpoints.GetLength(0); i++)
            // {
            //     ConSpawnpoints[i] = GameObject.FindWithTag("ConSpawnpoint").transform.GetChild(i);  //배열에 오브젝트 넣기
            // }

            // randomSpanwpoints = new Transform[GameObject.FindWithTag("randomSpawnpoint").GetComponentsInChildren<Transform>().Length-1];    //배열 할당(?)
            // for(int i = 0; i < randomSpanwpoints.GetLength(0); i++)
            // {
            //     randomSpanwpoints[i] = GameObject.FindWithTag("randomSpawnpoint").transform.GetChild(i);    //배열에 오브젝트 넣기
            // }

            Instantiate(melee.prefabs, ConSpawnpoints[0]);
            Instantiate(range.prefabs, ConSpawnpoints[1]);
            Instantiate(melee.prefabs, ConSpawnpoints[2]);

            int rangeGacha = Random.Range(0,mapValue[mapList[isMap]]/2);
            for(int i = 0; i < rangeGacha; i++)
            {
                int ranspanw = Random.Range(0, randomSpanwpoints.GetLength(0));
                Instantiate(range.prefabs, randomSpanwpoints[ranspanw]);
            }
                Debug.Log("<b><color=red>원거리 "+ rangeGacha +"명</color></b> 소환");
            for(int i = 0; i < (mapValue[mapList[isMap]] - rangeGacha*2); i++)
            {
                int ranspanw = Random.Range(0, randomSpanwpoints.GetLength(0));
                Instantiate(melee.prefabs, randomSpanwpoints[ranspanw]);
            }
                Debug.Log("<b><color=blue>근거리 " + (mapValue[mapList[isMap]] - rangeGacha*2) + "명</color></b> 소환");
        }
    }

    void mapChange()
    {
        switch(Input.inputString)
        {
            case "1":
                isMap = 2;
                Debug.Log("map 1-1로 바뀜");
                Debug.Log("현재 맵 밸류 : " + mapValue[mapList[isMap]]);
                ConSpawnpoints = new Transform[mapList[isMap].transform.Find("ConSpawnpoint").GetComponentsInChildren<Transform>().Length - 1];  //배열 할당(?)
                for (int i = 0; i < ConSpawnpoints.GetLength(0); i++)
                {
                    ConSpawnpoints[i] = mapList[isMap].transform.Find("ConSpawnpoint").transform.GetChild(i);  //배열에 오브젝트 넣기
                }

                randomSpanwpoints = new Transform[mapList[isMap].transform.Find("spawnpoints").GetComponentsInChildren<Transform>().Length - 1];    //배열 할당(?)
                for (int i = 0; i < randomSpanwpoints.GetLength(0); i++)
                {
                    randomSpanwpoints[i] = mapList[isMap].transform.Find("spawnpoints").transform.GetChild(i);    //배열에 오브젝트 넣기
                }
                break;

            case "2":
                isMap = 1;
                Debug.Log("map 1-2로 바뀜");
                Debug.Log("현재 맵 밸류 : " + mapValue[mapList[isMap]]);

                ConSpawnpoints = new Transform[mapList[isMap].transform.Find("ConSpawnpoint").GetComponentsInChildren<Transform>().Length - 1];  //배열 할당(?)
                for (int i = 0; i < ConSpawnpoints.GetLength(0); i++)
                {
                    ConSpawnpoints[i] = mapList[isMap].transform.Find("ConSpawnpoint").transform.GetChild(i);  //배열에 오브젝트 넣기
                }

                randomSpanwpoints = new Transform[mapList[isMap].transform.Find("spawnpoints").GetComponentsInChildren<Transform>().Length - 1];    //배열 할당(?)
                for (int i = 0; i < randomSpanwpoints.GetLength(0); i++)
                {
                    randomSpanwpoints[i] = mapList[isMap].transform.Find("spawnpoints").transform.GetChild(i);    //배열에 오브젝트 넣기
                }

                break;

            case "3":
                isMap = 0;
                Debug.Log("map 1-3로 바뀜");
                Debug.Log("현재 맵 밸류 : " + mapValue[mapList[isMap]]);
                ConSpawnpoints = new Transform[mapList[isMap].transform.Find("ConSpawnpoint").GetComponentsInChildren<Transform>().Length - 1];  //배열 할당(?)
                for (int i = 0; i < ConSpawnpoints.GetLength(0); i++)
                {
                    ConSpawnpoints[i] = mapList[isMap].transform.Find("ConSpawnpoint").transform.GetChild(i);  //배열에 오브젝트 넣기
                }

                randomSpanwpoints = new Transform[mapList[isMap].transform.Find("spawnpoints").GetComponentsInChildren<Transform>().Length - 1];    //배열 할당(?)
                for (int i = 0; i < randomSpanwpoints.GetLength(0); i++)
                {
                    randomSpanwpoints[i] = mapList[isMap].transform.Find("spawnpoints").transform.GetChild(i);    //배열에 오브젝트 넣기
                }
                break;
        }
    }

    void mapValueSetting()
    {
        mapValue.Add(mapList[0], 10);       //map1-3 = 10
        mapValue.Add(mapList[1], 9);        //map1-2 = 8
        mapValue.Add(mapList[2], 6);        //map1-1 = 6
    }
}
