using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : MonoBehaviour
{
    public string abilityName;
    public Sprite abilityIcon;
    public float cooldownDuration;
    public bool isInCooldown;
    public event Action<float> OnCooldownStart;

    public abstract void Trigger();

    protected void StartCooldown()
    {
        isInCooldown = true;
        Invoke(nameof(ResetCooldown), cooldownDuration);
        OnCooldownStart?.Invoke(cooldownDuration);

    }

    private void ResetCooldown()
    {
        isInCooldown = false;
    }
}
