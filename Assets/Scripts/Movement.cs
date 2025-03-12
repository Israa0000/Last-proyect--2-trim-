using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    [SerializeField] List<MovementStats> MovementStats = new List<MovementStats>();
    Rigidbody2D rb;
    private int currentPreset = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (MovementStats.Count > 0)
        {
            ChangePreset(currentPreset);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentPreset = (currentPreset + 1) % MovementStats.Count;
            ChangePreset(currentPreset);
        }
        Move();
    }

    //MOVEMENT
    private void Move()
    {
        Vector2 movedirection = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) { movedirection += Vector2.up; }
        if (Input.GetKey(KeyCode.S)) { movedirection += Vector2.down; }
        if (Input.GetKey(KeyCode.A)) { movedirection += Vector2.left; }
        if (Input.GetKey(KeyCode.D)) { movedirection += Vector2.right; }

        movedirection = movedirection.normalized;

        if (rb.velocity.magnitude > MovementStats[currentPreset].maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * MovementStats[currentPreset].maxSpeed;
        }

        rb.velocity += movedirection * MovementStats[currentPreset].acceleration * Time.deltaTime;
    }

    //PRESET CHANGER
    public void AddElement(MovementStats newStat)
    {
        MovementStats.Add(newStat);
    }

    public void ChangePreset(int index)
    {
        if (index >= 0 && index < MovementStats.Count)
        {
            MovementStats selectedPreset = MovementStats[index];
            SetMovementProfile(selectedPreset);
        }
    }
    public void SetMovementProfile(MovementStats newStats)
    {
        rb.drag = newStats.friction;
    }
}
