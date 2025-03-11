using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class AbilityHolder : MonoBehaviour
{
    [SerializeField] private Ability[] abilities;
    [SerializeField] private Image[] icons;
    private int currentAbilityIndex;

    private void Start()
    {
        Icons();
    }
    void Update()
    {
        SubscribeToCooldowns();
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
    private void Icons()
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (i < abilities.Length && abilities[i] != null)
            {
                icons[i].sprite = abilities[i].abilityIcon;
                icons[i].color = (i == currentAbilityIndex) ? Color.white : new Color(1, 1, 1, 0.5f); 
                //resalta la habilidad seleccionada
            }
            else
            {
                icons[i].sprite = null;
                icons[i].color = new Color(1, 1, 1, 0); 
                //se oculta el ícono si no hay habilidad
            }
        }
    }
    private void SubscribeToCooldowns()
    {
        for (int i = 0; i < abilities.Length; i++)
        {
            int index = i;
            if (abilities[i] != null)
            {
                abilities[i].OnCooldownStart += (duration) => StartCoroutine(StartCooldownUI(index, duration));
            }
        }
    }

    private IEnumerator StartCooldownUI(int index, float duration)
    {
        float elapsed = 0;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float fillValue = 1 - (elapsed / duration);
            icons[index].fillAmount = fillValue;
            yield return null; // Ese espera un frame antes de continuar
        }

        icons[index].fillAmount = 1; // se reinicia el icono al final del cooldown
    }
}

