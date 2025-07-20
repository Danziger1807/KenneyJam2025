using System;
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
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = normalController;
    }

    private void OnEnable()
    {
        fireElementAction.action.performed += OnFireElementPressed;
        fireElementAction.action.Enable();

        waterElementAction.action.performed += OnWaterElementPressed;
        waterElementAction.action.Enable();


    }

    private void OnWaterElementPressed(InputAction.CallbackContext context)
    {
        isWaterActive = !isWaterActive;
        isFireActive = false;
        animator.runtimeAnimatorController = isWaterActive && !isFireActive ? waterOverrideController : normalController;
    }

    private void OnFireElementPressed(InputAction.CallbackContext context)
    {
        isFireActive = !isFireActive;
        isWaterActive = false;
        animator.runtimeAnimatorController = isFireActive && !isWaterActive ? fireOverrideController : normalController;
    }

    private void OnDisable()
    {
        fireElementAction.action.performed -= OnFireElementPressed;
        fireElementAction.action.Disable();

        waterElementAction.action.performed -= OnWaterElementPressed;
        waterElementAction.action.Disable();
    }

}
