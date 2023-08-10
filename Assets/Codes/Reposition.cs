using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reposition : MonoBehaviour
{
    new Collider2D collider;
    const int TILE_MAP_SIZE = 20;
    private void Awake() {
        collider = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(!other.CompareTag("Area"))
        {
            //Debug.Log("not Area");
            return;
        }
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        //Debug.Log("diffx : " + diffX);
        //Debug.Log("diffy : " + diffY);

        Vector3 playerDir = GameManager.instance.player.inputVector;
        float dirX = playerDir.x < 0? -1 : 1;
        float dirY = playerDir.y < 0? -1 : 1;

        switch(transform.tag)
        {
            case "Ground":
            {
                if( diffX > diffY)
                {
                    if (playerPos.x > myPos.x)
                        transform.Translate(Vector3.right * 2 * TILE_MAP_SIZE);
                    else
                        transform.Translate(Vector3.left * 2 * TILE_MAP_SIZE);
                }
                else
                {
                    if (playerPos.y > myPos.y)
                        transform.Translate(Vector3.up * 2 * TILE_MAP_SIZE);
                    else
                        transform.Translate(Vector3.down * 2 * TILE_MAP_SIZE);
                }
            }
            break;

            case "Enemey":
            {
                Debug.Log("reposition enemey!");
                if(collider.enabled)
                {
                        //add 5 to make sure that enemey apears out of Area
                        transform.Translate(playerDir * (TILE_MAP_SIZE + 5)  + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0));

                        Debug.Log("player dir : " + playerDir);
                        Debug.Log("player pos : " + GameManager.instance.player.transform.position);
                        Debug.Log("enem pos : " + transform.position);
                }
            }
            break;
        }
    }
}
