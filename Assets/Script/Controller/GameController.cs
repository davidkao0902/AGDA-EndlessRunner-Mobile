﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -------------------------
// Game Controller:
// - Controls the game
// - Initializes menu controller
// - Initializes sound manager
// -------------------------
public class GameController : MonobehaviorSingleton<GameController>
{
    private GameObject playerPrefab;
    private GameObject player;
    private GameObject backGroundPrefab;
    private GameObject blockPrefab;
    private GameObject groundBlock;

    // Start is called before the first frame update
    void Start()
    {
        blockPrefab = Resources.Load<GameObject>("Prefab/GroundBlock");
        playerPrefab = Resources.Load<GameObject>("Prefab/Player");
        backGroundPrefab = Resources.Load<GameObject>("Prefab/Background");

        SpawnBackGround();
        SpawnPlayer();
        SpawnGround();
        SpawnStack();

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -5)
        {
            Destroy(player);
            player = Instantiate(playerPrefab);
            player.transform.position = new Vector3(0, 5, 0);
        }
    }

    public void SpawnStack()
    {
        GameObject stacks = Instantiate(new GameObject());
        stacks.name = "Stack";
    }

    public void SpawnPlayer()
    {

        player = Instantiate(playerPrefab);
        player.transform.position = new Vector3(0, 5, 0);
    }

    public void SpawnBackGround()
    {

        Instantiate(backGroundPrefab);
    }

    //Testing purpose
    public void SpawnGround()
    {
        GameObject grounds = Instantiate(new GameObject());
        grounds.name = "Ground";
        for (int i = 0; i < 18; i++)
        {
            groundBlock = Instantiate(blockPrefab);
            groundBlock.transform.position = new Vector3(i, 0, 0);
            groundBlock.transform.parent = grounds.transform;
        }
    }
}
