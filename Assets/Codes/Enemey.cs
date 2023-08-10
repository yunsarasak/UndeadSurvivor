using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemey : MonoBehaviour
{
    public float speed;
    public int health;
    public int maxHealth;
    public RuntimeAnimatorController[] runtimeAnimatorControllers;
    public Animator animator;
    Rigidbody2D target;

    bool isLive = false;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    Vector2 nextVec = Vector2.zero;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate() {
        if(!isLive)
            return;

        Vector2 dirVec = target.position - rigid.position;
        nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate() {
        if( nextVec.x < 0 )
            spriter.flipX = true;
        else
            spriter.flipX = false;
    }

    private void OnEnable() {
        isLive = true;
        health = maxHealth;
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();

    }

    public void Init(SpawnData data)
    {
        animator.runtimeAnimatorController = runtimeAnimatorControllers[data.spriteType];
        Debug.Log("anim sprites:"+data.spriteType);
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }
}
