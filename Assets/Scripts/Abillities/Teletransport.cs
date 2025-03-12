using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Ability
{
    private Camera mainCamera;
    Rigidbody2D rb;
    [SerializeField] ParticleSystem teleportParticles;
    Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) { Trigger(); }
    }
    public override void Trigger()
    {
        if (!isInCooldown)
        {
            teleport();
            StartCooldown();
        }
    }

    void teleport()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        rb.position = mousePosition;
        Particles();
    }

    private void Particles()
    {

        ParticleSystem.MainModule mainParticle = teleportParticles.main;
        mainParticle.startColor = player.spriteRenderer.color;
        teleportParticles.Play();
    }
}
