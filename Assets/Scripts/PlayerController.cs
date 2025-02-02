﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;
    public Text winText2;
	void Start(){
		rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        winText2.text = "";
    }
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
		rb.AddForce(movement*speed);
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 9)
        {
            winText.text = "You Win!";
            winText2.text = "You Win!";
        }
    }
}
