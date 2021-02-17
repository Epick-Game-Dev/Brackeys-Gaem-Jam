using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    #region Enums
    public enum PlayerStatus
    {
        Free,
        Stuck
    }
    #endregion

    #region Variables
    [SerializeField, Range(5, 50)] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private SpriteRenderer happinessSprite;
    public PlayerStatus status = PlayerStatus.Free;
    private Vector2 move;
    #endregion

    #region MonoBehaviour Callbacks
    // Start is called before the first frame update
    void Start()
    {
        // Assigning the rigidbody
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();

        // Setting the movement vector to 0, 0
        move = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Call the GetInput function
        if (status == PlayerStatus.Free)
        {
            GetInput();
        }
    }

    private void FixedUpdate()
    {
        // Call the MovePlayer function
        // Were moving the player in FixedUpdate, since FixedUpdate should always be used for physics calculations
        if (status == PlayerStatus.Free)
        {
            MovePlayer();
        }
    }

    #endregion

    #region MovePlayer Function
    /// <summary>
    /// Move the player using Rigidbody.Velocity.
    /// </summary>
    void MovePlayer()
    {
        rb.velocity = new Vector2(move.x, move.y) * speed;
    }
    #endregion

    #region Input Function
    /// <summary>
    /// Getting horizontal and vertical input.
    /// </summary>
    void GetInput()
    {
        // Get Input
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        if (move.x < 0)
        {
            renderer.flipX = true;
            happinessSprite.flipX = true;
        }
        else if (move.x > 0)
        {
            renderer.flipX = false;
            happinessSprite.flipX = false;
        }

        // Update animation based on wether there's any input
        if (move.x != 0 || move.y != 0)
        {
            animator.SetBool("isMoving", true);
            return;
        }
        animator.SetBool("isMoving", false);
    }
    #endregion
}
