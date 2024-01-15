using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class AbilitySizeShift : MonoBehaviour
{
    public float abilityDuration = 10f;
    const float scaleFactor = 3f;

    public CinemachineVirtualCamera virtualCamera;
    StarterAssets.ThirdPersonController thirdPersonController;
    CharacterController characterController;
    GameObject skeleton;
    GameObject playerCameraRoot;

    float moveSpeed;
    float jumpHeight;
    float gravity;
    float sprintSpeed;

    Vector3 vCamShoulderOffset;

    bool sizeShifting = false;

    Vector3 startScale = new Vector3(1, 1, 1);
    Vector3 endScale = new Vector3(3, 3, 3);

    private void Start()
    {
        thirdPersonController = GetComponent<StarterAssets.ThirdPersonController>();
        skeleton = transform.GetChild(2).gameObject;
        playerCameraRoot = transform.GetChild(0).gameObject;
        characterController = GetComponent<CharacterController>();
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        moveSpeed = thirdPersonController.MoveSpeed;
        jumpHeight = thirdPersonController.JumpHeight;
        gravity = thirdPersonController.Gravity;
        sprintSpeed = thirdPersonController.SprintSpeed;

        vCamShoulderOffset = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().ShoulderOffset;
    }

    public void ActivateSizeShift()
    {
        if (!sizeShifting)
        {
            sizeShifting = true;
            StartCoroutine(SizeShift());
        }
    }

    IEnumerator SizeShift()
    {
        float elapsedTime = 0f;

        // Activate the size shift
        while (elapsedTime < abilityDuration)
        {
            // Calculate the percentage of completion
            float percentageComplete = elapsedTime / abilityDuration;

            // Interpolate the scale values
            skeleton.transform.localScale = Vector3.Lerp(startScale, endScale, percentageComplete);

            // Interpolate other properties as needed (characterController, thirdPersonController, etc.)

            yield return null;
            elapsedTime += Time.deltaTime;
        }

        // Deactivate the size shift
        sizeShifting = false;

        // Reset any changes made during the size shift
        // (you may need to revert other properties to their original values)

        // Notify that the ability is no longer active
        Inventory.AbilityIsActive = false;
    }
}
