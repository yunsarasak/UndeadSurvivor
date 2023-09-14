using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public float per;
    public int count;
    public float speed;

    void Start()
    {
        Init(id);
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count = count;

        if(id == 0)
        {
            SetPosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetButtonDown("Jump"))
        {
            LevelUp(damage + 4f, count + 1);
        }
        switch(id)
        {
            case 0:
            {
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
            }
            break;

            default:
            {

            }
            break;
        }
    }

    public void Init(int id)
    {
        switch(id)
        {
            case 0:
            {
                SetPosition();
                speed = 150;
            }
            break;

            default:
            {

            }
            break;
        }

    }

    public void SetPosition()
    {
        for ( int index= 0; index < count; index++)
        {
            Transform bullet;
            if(index < transform.childCount)
            {
                 bullet = transform.GetChild(index);
            }
            else
            {
                // get bullet prefab from pool manager
                bullet = GameManager.instance.poolManager.Get(prefabId).transform;
                // set prefab's parent to weapon's transform. which is same with player's
                bullet.parent = transform;
            }

            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);

            bullet.GetComponent<Bullet>().Init(damage, -1); // -1 is melee atack
        }
    }
}
