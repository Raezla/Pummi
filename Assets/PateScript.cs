﻿using UnityEngine;
using System.Collections;

public class PateScript : MonoBehaviour {
    SpriteRenderer renderer;
    Vector2 target_pos;
    Vector2 current_pos;
    GameObject target_object;
    GameObject game_controller;
    float angle;
    float speed = 5.0f;

	// Use this for initialization
	void Start () {
        renderer = GameObject.Find("Pate").GetComponent<SpriteRenderer>();
        game_controller = GameObject.Find("GameController");
        angle = 0.0f;

        target_pos = new Vector2(transform.position.x, transform.position.y);
        current_pos = new Vector2(transform.position.x, transform.position.y);
        target_object = null;
	}
	
	// Update is called once per frame
	void Update () {
        float angrad = angle * 180.0f / Mathf.PI;
        float x = Mathf.Cos(angrad);
        float y = Mathf.Sin(angrad);
        //transform.localPosition = new Vector2(x, y);
        //transform.localScale = new Vector3(0.1f + (Mathf.Abs(x) * 0.5f), 0.1f + (Mathf.Abs(x) * 0.5f), 1.0f);
        
        angle += 0.008f;

        float walk_offset = 0.0f;
        float walk_rot = 0.0f;

        Vector2 direction = target_pos - current_pos;
        if (direction.magnitude > speed)
        {
            direction.Normalize();
            direction *= speed;

            walk_offset = Mathf.Abs(Mathf.Sin(angrad)) * 15.0f;
            walk_rot = 0.0f - Mathf.Sin(angrad) * 20.0f;
        }
        else
        {
            // close enough to target, let's stop
            direction = new Vector2(0, 0);
        }

        current_pos += direction;
        transform.position = new Vector3(current_pos.x, current_pos.y + walk_offset, 0);

        transform.localRotation = Quaternion.Euler(0, 0, walk_rot);

        //renderer.color = new Color(x, 1.0f - x, Mathf.Abs(y));
        if (direction.x < 0.0f)
            renderer.flipX = false;
        else
            renderer.flipX = true;
    }

    void SetTarget(Vector2 pos)
    {
        Debug.Log("SET TARGET " + pos);
        target_pos = pos;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("TRIGGER WARNING");
    }

    /*
    void SetTargetObject(GameObject obj)
    {
        target_object = obj;
    }
    */
}
