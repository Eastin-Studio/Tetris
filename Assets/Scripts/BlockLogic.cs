using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLogic : MonoBehaviour
{
    GameLogic gameLogic;
    bool movable = true;
    float timer = 0f;
    public GameObject rig;

    // Start is called before the first frame update
    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
    }

    void RegisterBlock()
    {
        foreach (Transform subBlock in rig.transform)
        {
            gameLogic.grid[Mathf.FloorToInt(subBlock.position.x), Mathf.FloorToInt(subBlock.position.y)] = subBlock;
        }
    }

    bool CheckValid()
    {
        foreach (Transform subBlock in rig.transform)
        {
            if (subBlock.transform.position.x >= GameLogic.width ||
                subBlock.transform.position.x < 0 ||
                subBlock.transform.position.y < 0)
            {
                return false;
            }

            if (subBlock.position.y < GameLogic.height && gameLogic.grid[Mathf.FloorToInt(subBlock.position.x), Mathf.FloorToInt(subBlock.position.y)] != null)
            {
                return false;
            }
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (movable)
        {
            //Timer Update
            timer += 1 * Time.deltaTime;

            //Falling Logic
            if (Input.GetKey(KeyCode.DownArrow) && timer > GameLogic.quickdroptime)
            {
                gameObject.transform.position -= new Vector3(0, 1, 0);
                timer = 0;
                if (!CheckValid())
                {
                    movable = false;
                    gameObject.transform.position += new Vector3(0, 1, 0);
                    RegisterBlock();
                    gameLogic.SpawnBlock();
                }
            }

            else if (Input.GetKey(KeyCode.S) && timer > GameLogic.quickdroptime)
            {
                gameObject.transform.position -= new Vector3(0, 1, 0);
                timer = 0;
                if (!CheckValid())
                {
                    movable = false;
                    gameObject.transform.position += new Vector3(0, 1, 0);
                    RegisterBlock();
                    gameLogic.SpawnBlock();
                }
            }

            else if (timer > GameLogic.droptime)
            {
                gameObject.transform.position -= new Vector3(0, 1, 0);
                timer = 0;
                if (!CheckValid())
                {
                    movable = false;
                    gameObject.transform.position += new Vector3(0, 1, 0);
                    RegisterBlock();
                    gameLogic.SpawnBlock();
                }
            }

            //Sideways Movement
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gameObject.transform.position -= new Vector3(1, 0, 0);
                if (!CheckValid())
                {
                    gameObject.transform.position += new Vector3(1, 0, 0);
                }
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                gameObject.transform.position += new Vector3(1, 0, 0);
                if (!CheckValid())
                {
                    gameObject.transform.position -= new Vector3(1, 0, 0);
                }
            }

            else if (Input.GetKeyDown(KeyCode.A))
            {
                gameObject.transform.position -= new Vector3(1, 0, 0);
                if (!CheckValid())
                {
                    gameObject.transform.position += new Vector3(1, 0, 0);
                }
            }

            else if (Input.GetKeyDown(KeyCode.D))
            {
                gameObject.transform.position += new Vector3(1, 0, 0);
                if (!CheckValid())
                {
                    gameObject.transform.position -= new Vector3(1, 0, 0);
                }
            }

            //Rotation
            if (Input.GetKeyDown(KeyCode.W))
            {
                rig.transform.eulerAngles -= new Vector3(0, 0, 90);
                if (!CheckValid())
                {
                    gameObject.transform.eulerAngles += new Vector3(0, 0, 90);
                }
            }

            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rig.transform.eulerAngles -= new Vector3(0, 0, 90);
                if (!CheckValid())
                {
                    gameObject.transform.eulerAngles += new Vector3(0, 0, 90);
                }
            }

        }
    }
}
