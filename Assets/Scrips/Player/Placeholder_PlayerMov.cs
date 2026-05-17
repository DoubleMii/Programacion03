using UnityEngine;

public class Placeholder_PlayerMov : MonoBehaviour
{

    [Header("Suelo")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [SerializeField] AudioClip footstep;

    private CharacterController controller;

    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundDistance,
            groundMask
        );

        if (isGrounded)
        {
            AudioManager.instance.PlaySfx(footstep);
        }

    }
}