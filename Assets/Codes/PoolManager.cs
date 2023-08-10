using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //프리팹을 보관할 리스트
    public GameObject[] prefabs;

    //풀 담당을 하는 리스트
    List<GameObject>[] pools;

    private void Awake() {
        pools = new List<GameObject>[prefabs.Length];

        for( int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }

        //Debug.Log("pools length : " + pools.Length);
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        //놀고 있는 게임 오브젝트에 접근.
        foreach(GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                // select에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }


        //못 찾았으면? 새로 할당해서 select에 할당
        if(!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        
       return select; 
    }

}
