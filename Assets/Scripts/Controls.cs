using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    [SerializeField]
    private float speed = 0;
    private Vector2 move = Vector2.zero;
    private Rigidbody rb;
    private NewControls controls;

    private void Awake()
    {
        controls = new NewControls();
        controls.Keyboard.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Keyboard.Move.canceled += ctx => move = Vector2.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(move.x, 0.0f, move.y);
        rb.AddForce(movement * speed);
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }
}
