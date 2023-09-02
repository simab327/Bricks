using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public int itemType;
    Vector2 velo;
    Rigidbody2D rbody;

    void Start()
    {
        Material mat = this.GetComponent<Renderer>().material;

        switch (itemType)
        {
            case 0:
                mat.color = Color.white;
                break;
            case 1:
                mat.color = Color.red;
                break;
            case 2:
                mat.color = Color.blue;
                break;
            case 3:
                mat.color = Color.yellow;
                break;
            case 4:
                mat.color = Color.cyan;
                break;
            case 5:
                mat.color = Color.magenta;
                break;
            case 6:
                mat.color = Color.green;
                break;
            default:
                break;
        }

        rbody = GetComponent<Rigidbody2D>();
        velo = new Vector2(0, -1);
        rbody.velocity = velo;
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("ItemData: OnTriggerEnter2D");

        if (collision.gameObject.tag == "Player")
        {
            int GameState = GameMgr.getGameState();
            if (GameState == Constants.s_playing)
            {
                switch (itemType)
                {
                    case 0:
                        break;
                    case 1:
                        GameMgr.add1Ball();
                        break;
                    case 2:
                        GameMgr.addBarSpeed();
                        break;
                    case 3:
                        GameMgr.delBallSpeed();
                        break;
                    case 4:
                        GameMgr.add10Ball();
                        break;
                    case 5:
                        GameMgr.addbarLength();
                        //Debug.Log("ItemData: addbarLength");
                        //Invoke("delBarLen", 3.0f);
                        //GameObject player = GameObject.FindGameObjectWithTag("Player");
                        //player.GetComponent<GameMgr>().addbarLength();
                        break;
                    default:
                        break;
                }

                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                Rigidbody2D itemBody = GetComponent<Rigidbody2D>();
                itemBody.gravityScale = 2.5f;
                itemBody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
                Destroy(gameObject, 0.5f);
            }
        }
    }

    //void delBarLen()
    //{
    //    Debug.Log("ItemData: delBarLen");
    //    GameMgr.delBarLength();
    //}

}

