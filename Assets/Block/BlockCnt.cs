using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCnt : MonoBehaviour
{
    public GameObject   doorPrefab;
    public GameObject   itemPrefab;

    public int          hasItemType;
    GameObject          player;

    void Start()
    {
        Material mat = this.GetComponent<Renderer>().material;
        switch (hasItemType)
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
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            Destroy(this.gameObject);
            player.GetComponent<GameMgr>().delBlock();

            if (hasItemType != 0)
            {
                Quaternion r = Quaternion.Euler(0, 0, 0);
                Vector3 pos = transform.position;
                GameObject itemObj = Instantiate(itemPrefab, pos, r);
                ItemData id = itemObj.GetComponent<ItemData>();
                id.itemType = hasItemType;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            Destroy(this.gameObject);
            player.GetComponent<GameMgr>().delBlock();

            if (hasItemType != 0)
            {
                Quaternion r = Quaternion.Euler(0, 0, 0);
                Vector3 pos = transform.position;
                GameObject itemObj = Instantiate(itemPrefab, pos, r);
                ItemData id = itemObj.GetComponent<ItemData>();
                id.itemType = hasItemType;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }

}
