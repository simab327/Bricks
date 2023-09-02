using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCnt : MonoBehaviour
{
    public GameObject doorPrefab;
    public GameObject itemPrefab;

    public int hasItemType;

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
    }

    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            //int px = (int)(transform.position.x + 10.5f);
            //int py = (int)((transform.position.y - 5.5f) * -1.0f);
            //ItemKeeper.delArrayBlock(px, py);
            Destroy(this.gameObject);
            //--GameMgr.hasBlocks;
            GameMgr.delBlock();


            if (hasItemType != 0)
            {
                Quaternion r = Quaternion.Euler(0, 0, 0);
                Vector3 pos = transform.position;
                //pos.x = -10.5f + 1.0f * px;
                //pos.y = 5.5f - 1.0f * py;

                //int val = ItemKeeper.getArray(px, py);
                //if (val >= Constants.cFirePower)
                //{
                GameObject itemObj = Instantiate(itemPrefab, pos, r);
                ItemData id = itemObj.GetComponent<ItemData>();
                id.itemType = hasItemType;
            }
            //
            //}
            //if (val == Constants.cDoor)
            //{
            //    GameObject doorObj = Instantiate(doorPrefab, pos, r);
            //}
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            //int px = (int)(transform.position.x + 10.5f);
            //int py = (int)((transform.position.y - 5.5f) * -1.0f);
            //ItemKeeper.delArrayBlock(px, py);
            Destroy(this.gameObject);
            //--GameMgr.hasBlocks;
            GameMgr.delBlock();

            if (hasItemType != 0)
            {
                Quaternion r = Quaternion.Euler(0, 0, 0);
                Vector3 pos = transform.position;
                //pos.x = -10.5f + 1.0f * px;
                //pos.y = 5.5f - 1.0f * py;

                //int val = ItemKeeper.getArray(px, py);
                //if (val >= Constants.cFirePower)
                //{
                GameObject itemObj = Instantiate(itemPrefab, pos, r);
                ItemData id = itemObj.GetComponent<ItemData>();
                id.itemType = hasItemType;
            }
            //
            //}
            //if (val == Constants.cDoor)
            //{
            //    GameObject doorObj = Instantiate(doorPrefab, pos, r);
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }
}
