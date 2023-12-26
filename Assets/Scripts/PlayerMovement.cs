using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    public Collider2D[] colliders = new Collider2D[3];

    Vector2 movement;

    void Update()
    {
        ///Update player input

        InputUpdate();

        if (Timer.instance.CurrentTime() == 0)
        {
            DeathDueToTime();
        }
    }

    void FixedUpdate()
    {
        /// Movement
        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void InputUpdate()
    {
        ///Player input
        ///Animation

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    public void DeathDueToTime()
    {

        moveSpeed = 0;
        for (int i = 0; i < 3; i++)
        {
         colliders[i].enabled = false;
        }
        Destroy(this.gameObject);
        FindObjectOfType<GameMenu>().canvas.enabled = true;

    }







}
