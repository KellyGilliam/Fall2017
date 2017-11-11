﻿/*
 * 
 * Author: Spencer Wilson
 * Date Created: 11/3/2017 @ 11:17 pm
 * Date Modified: 11/5/2017 @ 10:26 pm
 * Project: CompSciClubFall2017
 * File: StingerSuperClass.cs
 * Description: This program houses all of the code for the Stinger AI.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingerSuperClass : MonoBehaviour
{

    private Rigidbody stingerRigidBody; // Creating a Rigidbody variable named stingerRigidbody that holds the Rigidbody component of the Stinger enemy.
    private Rigidbody playerRigidBody; // This variable holds the Player's RigidBody.
    private const int speed = 20; // This variable holds the speed for the Stinger enemy.
    private bool isAlive; // Boolean variable that represents if the Stinger enemy is alive.
    private int health; // Integer variable that holds the Stinger health.
    private Vector3 stingerPos;
    private Vector3 playerPos;
    private Vector3 newPos;
    // private Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        stingerRigidBody = GetComponent<Rigidbody>();
        //stingerPos = GameObject.Find("PlayerTester").transform;
    }

    public void Update()
    {
        checkStingerHealth();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        stingerMovement(); // Checks if there is any input from the player and adjusts the enemy Stinger's position according to the change.
        stingerWeapons(); // Fires the Stinger's weapons if the player enters the line of sight of the Stinger.
    }

    public void stingerMovement()
    {
        stingerPos = stingerRigidBody.position;
        playerPos = GameObject.Find("PlayerTester").GetComponent<Transform>().position;
        newPos = new Vector3(playerPos.x + 4f, playerPos.y, 0f);
        transform.position = Vector3.MoveTowards(stingerPos, newPos, Time.deltaTime * speed);
    }

    private void stingerWeapons()
    {
        Ray stingerRaycast = new Ray(stingerPos, - transform.right);
        if(Physics.Raycast(stingerRaycast))
        {
            StingerBullet clone  = Instantiate(stingerRigidBody.position, transform);
            Debug.Log("Pew! Pew!");
        }
    }

    public void takeDamage() // takeDamage is called when the bullet hits the enemy.
    {
        health -= 10;
    }

    private void checkStingerHealth() // Checks to see if the Stinger is alive or not.
    {
        if(health < 0)
        {
            Destroy(gameObject);
        }
    }
}