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

    private bool isFireActive = false;
    private bool isWaterActive = false;
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
        animator.runtimeAnimatorController = isWaterActive ? waterOverrideController : normalController;
    }

    private void OnFireElementPressed(InputAction.CallbackContext context)
    {
        isFireActive = !isFireActive;
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
