using UnityEngine;

public class Regenerate : Ability
{
    [SerializeField] Player player; 

    [Header("Attributes")]
    public float healAmount;      
    public float regenInterval;   
    public float duration;
    public bool isRegenerating; 

    [Header("Particles")]
    [SerializeField] ParticleSystem regenerateParticles;

    private float regenTimer;     
    private float durationTimer;

    public override void Trigger()
    {
        if (!isInCooldown)
        {
            ActivateRegeneration();
            StartCooldown();
        }
    }

    private void ActivateRegeneration()
    {
        isRegenerating = true;
        regenTimer = 0f;
        durationTimer = duration;

        if (regenerateParticles != null && !regenerateParticles.isPlaying)
        {
            regenerateParticles.Play();
        }
    }

    private void Update()
    {
        if (isRegenerating)
        {
            regenTimer += Time.deltaTime;
            durationTimer -= Time.deltaTime;


            if (regenTimer >= regenInterval)
            {
                RegenerateHealth();
                regenTimer = 0f; 
            }

            if (durationTimer <= 0)
            {
                isRegenerating = false;
                Debug.Log("Regeneration ended");
            }

        }

        else
        {
            
            if (regenerateParticles.isPlaying)
            {
                regenerateParticles.Stop();
            }
        }
    }

    private void RegenerateHealth()
    {
        if (player != null)
        {
            player.currentHealth += healAmount; 
            Debug.Log("Regenerating " + healAmount + " HP");
        }
    }
}
