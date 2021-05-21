using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private Vector2 rawInput;
    private Vector3 dir;
    [SerializeField] private bool isMoving;
    [SerializeField] public float speed;
    public Rigidbody rb;
    
    private void FixedUpdate()
    {
        if (isMoving)
            Move(rawInput);

    }

    private void OnPoisonThrow(InputValue value)
    {
        if (GameManager.Instance.player.playerAbilities.canPoison)
            GameManager.Instance.player.playerAbilities.ThrowPoison();

    }
    private void OnFreezeThrow(InputValue value)
    {
        if (GameManager.Instance.player.playerAbilities.canFreeze)
            GameManager.Instance.player.playerAbilities.ThrowFreeze();
    }
    private void OnFireThrow(InputValue value)
    {
        if (GameManager.Instance.player.playerAbilities.canFlame)
            GameManager.Instance.player.playerAbilities.ThrowBurn();
    }
    private void OnMovement(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        isMoving = rawInput == Vector2.zero ? false : true;
        dir = new Vector3(rawInput.x, 0, rawInput.y).normalized;
    }

    private void Move(Vector2 input)
    {
        transform.forward = rb.velocity;
        if (input.magnitude >= 0.2f)
        {
            rb.velocity = new Vector3(dir.x * speed, rb.velocity.y, dir.z * speed);
        }
    }


}
