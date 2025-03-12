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

    private float regenTime;     
    private float durationTime;

    public override void Trigger()
    {
        if (!isInCooldown)
        {
            ActivateRegeneration();
        }
    }

    private void ActivateRegeneration()
    {
        isRegenerating = true;
        regenTime = 0f;
        durationTime = duration;

        if (regenerateParticles != null && !regenerateParticles.isPlaying)
        {
            regenerateParticles.Play();
        }
    }

    private void Update()
    {
        if (isRegenerating)
        {
            regenTime += Time.deltaTime;
            durationTime -= Time.deltaTime;


            if (regenTime >= regenInterval)
            {
                RegenerateHealth();
                regenTime = 0f; 
            }

            if (durationTime <= 0)
            {
                isRegenerating = false;
                StartCooldown();
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
