using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] private Ability[] abilities;
    private int currentAbilityIndex;

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { currentAbilityIndex = 0; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { currentAbilityIndex = 1; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { currentAbilityIndex = 2; }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { currentAbilityIndex = 3; }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { currentAbilityIndex = 4; }

        if (Input.GetMouseButtonDown(0))
        {
            if (currentAbilityIndex >= 0 && currentAbilityIndex < abilities.Length)
            {
                abilities[currentAbilityIndex].Trigger();
            }
        }
    }
}