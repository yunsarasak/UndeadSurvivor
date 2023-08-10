using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public SpawnData[] spawnDatas;
    public int maxEnemeyCount = 100;
    public int currEnemeyCount = 0;
    float timer;
    int level;
    public Transform[] spawnPoint;
    // Start is called before the first frame update
    void Update()
    {
        timer  += Time.deltaTime;
        level = Mathf.Min(GameManager.instance.level, spawnDatas.Length-1);

        if(timer > spawnDatas[level].spawnTime)
        {
            timer = 0;
            Spawn();
            Debug.Log("level:"+level);
        }
    }

    public void Spawn()
    {
        //int mobLevelMin = Mathf.Min(0, level);
        //int mobLevelMax = Mathf.Min(level, GameManager.instance.poolManager.prefabs.Length);
        GameObject enemey = GameManager.instance.poolManager.Get(0);
        enemey.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].transform.position;
        enemey.GetComponent<Enemey>().Init(spawnDatas[level]);
    }

    private void Awake() {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void OnMove(InputValue value)
    {
        //Debug.Log(value.ToString());
        //value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        Spawn();
    }
}

[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;
}