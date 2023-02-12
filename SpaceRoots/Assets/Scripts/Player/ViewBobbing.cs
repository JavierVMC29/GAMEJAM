using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PositionFollower))]
public class ViewBobbing : MonoBehaviour
{
    public float effectIntensity = 0.05f;
    public float effectIntensityX = 0.1f;
    public float effectSpeed = 4;

    private PositionFollower followerInstance;
    private Vector3 originalOffset;
    private float sinTime;

    [SerializeField]
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        followerInstance = GetComponent<PositionFollower>();
        originalOffset = followerInstance.offset;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVector = new(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));
        if(inputVector.magnitude > 0f)
        {
            sinTime += Time.deltaTime * effectSpeed;
        }
        else
        {
            sinTime = 0f;
        }

        float sinAmountY = -Mathf.Abs(effectIntensity * Mathf.Sin(sinTime));
        Vector3 sinAmountX = effectIntensity * effectIntensityX * Mathf.Cos(sinTime) * followerInstance.transform.right;

        followerInstance.offset = new Vector3
        {
            x = originalOffset.x,
            y = originalOffset.y + sinAmountY,
            z = originalOffset.z
        };

        followerInstance.offset += sinAmountX;
        Run();
    }

    private void Run()
    {
        if (playerMovement.isRunning)
        {
            effectSpeed = 6f;
        }
        else
        {
            effectSpeed = 4f;
        }
    }
}
