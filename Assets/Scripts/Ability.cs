using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public string abilityName;
    public Sprite abilityIcon;
    public float cooldownDuration;
    public bool isInCooldown;

    public abstract void Trigger();

    protected void StartCooldown()
    {
        isInCooldown = true;
        Invoke(nameof(ResetCooldown), cooldownDuration);
    }

    private void ResetCooldown()
    {
        isInCooldown = false;
    }
}
