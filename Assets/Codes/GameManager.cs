using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public PoolManager poolManager;
    public Spawner spawner;

    public float playTime = 0;

    public float gameTime = 0;
    public float gameEndTime = 2 * 1f;
    public int level;

    void Awake()
    {
        instance = this;
    }


    private void Update() {
        playTime += Time.deltaTime;
        level = Mathf.FloorToInt(playTime / 10f);
    }


}
