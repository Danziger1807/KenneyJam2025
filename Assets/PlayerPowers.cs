using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPowers : MonoBehaviour
{
    public InputActionReference fireElementAction;
    public InputActionReference waterElementAction;

    [SerializeField] private RuntimeAnimatorController normalController;
    [SerializeField] private AnimatorOverrideController fireOverrideController;
    [SerializeField] private AnimatorOverrideController waterOverrideController;

    public bool isFireActive = false;
    public bool isWaterActive = false;
    public bool canActivate = true;

    private Animator animator;
    private PlayerStats stats;

    private float manaDrainTimer = 0f;
    private float manaDrainInterval = 1f;


    private void Start()
    {
        animator = GetComponent<Animator>();
        stats = GetComponent<PlayerStats>();
        animator.runtimeAnimatorController = normalController;
    }

    private void OnEnable()
    {
            fireElementAction.action.performed += OnFireElementPressed;
            fireElementAction.action.Enable();

            waterElementAction.action.performed += OnWaterElementPressed;
            waterElementAction.action.Enable();
    }

    private void Update()
    {
        if (stats != null)
        {
            canActivate = stats.currentMana >= 5;

            if (stats.currentMana <= 0 && (isFireActive || isWaterActive))
            {
                isFireActive = false;
                isWaterActive = false;
                animator.runtimeAnimatorController = normalController;
                return;
            }

            manaDrainTimer += Time.deltaTime;

            if (manaDrainTimer >= manaDrainInterval)
            {
                if (isFireActive || isWaterActive)
                {
                    stats.UseMana(5);
                }
                else
                {
                    stats.RestoreMana(5);
                }

                manaDrainTimer = 0f;
            }
        }
    }




    private void OnWaterElementPressed(InputAction.CallbackContext context)
    {
        if (!canActivate) return;

        bool wasActive = isWaterActive;
        isWaterActive = !isWaterActive;
        isFireActive = false;

        if (isWaterActive && !wasActive)
        {
            stats.UseMana(5);
        }

        animator.runtimeAnimatorController = isWaterActive ? waterOverrideController : normalController;
    }


    private void OnFireElementPressed(InputAction.CallbackContext context)
    {
        if (!canActivate) return;

        bool wasActive = isFireActive;
        isFireActive = !isFireActive;
        isWaterActive = false;

        if (isFireActive && !wasActive)
        {
            stats.UseMana(5);
        }

        animator.runtimeAnimatorController = isFireActive ? fireOverrideController : normalController;
    }


    private void OnDisable()
    {
        fireElementAction.action.performed -= OnFireElementPressed;
        fireElementAction.action.Disable();

        waterElementAction.action.performed -= OnWaterElementPressed;
        waterElementAction.action.Disable();
    }

}
