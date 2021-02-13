using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject gameManager;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    public Dropdown colorPicker;
    public Material playerMaterialBlue;
    public Material playerMaterialYellow;
    public Material playerMaterialRed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        UnityEngine.Vector2 movementVector = movementValue.Get<UnityEngine.Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winTextObject.SetActive(true);
            MenuManager.NextScene();
        }
    }

    void FixedUpdate()
    {
        UnityEngine.Vector3 movement = new UnityEngine.Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }

    public void MaterialSelect()
    {
        if (colorPicker.value == 0)
        {
            GetComponent<Renderer>().material = playerMaterialBlue;
        }

        if (colorPicker.value == 1)
        {
            GetComponent<Renderer>().material = playerMaterialYellow;
        }

        if (colorPicker.value == 2)
        {
            GetComponent<Renderer>().material = playerMaterialRed;
        }
    }

    public void EnlargeBall()
    {
        UnityEngine.Vector3 newBallSize = new UnityEngine.Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z * 2);
        transform.localScale = newBallSize;
    }
}
