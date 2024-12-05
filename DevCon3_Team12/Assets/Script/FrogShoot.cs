using UnityEngine;

public class FrogShoot : MonoBehaviour
{
    float xRot, yRot = 0f;

    public float rotationSpeed = 5f;
    public Rigidbody frog;
    public float shootPower = 30f;
    public LineRenderer line;

    public LayerMask Ground;
    public float groundCheckDistance = 0.3f;

    private bool isGrounded = false;

    void Update()
    {
        transform.position = frog.position;

       
        isGrounded = CheckIfGrounded();

        Debug.Log($"Is Grounded: {isGrounded}");

        if (Input.GetMouseButton(0) && isGrounded)
        {
            xRot += Input.GetAxis("Mouse X") * rotationSpeed;
            yRot += Input.GetAxis("Mouse Y") * rotationSpeed;

            if (yRot < -35f)
            {
                yRot = -35f;
            }

            transform.rotation = Quaternion.Euler(yRot, xRot, 0f);
            line.gameObject.SetActive(true);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + transform.forward * 4f);
        }

        if (Input.GetMouseButtonUp(0) && isGrounded)
        {
            Debug.Log("Launching the frog!");
            frog.velocity = transform.forward * shootPower;
            line.gameObject.SetActive(false);
        }
    }

    private bool CheckIfGrounded()
    {
       
        RaycastHit hit;
        if (Physics.Raycast(frog.position, Vector3.down, out hit, groundCheckDistance, Ground))
        {
            Debug.Log($"Ground detected: {hit.collider.gameObject.name}");
            return true;
        }

        return false;
    }

    private void StopFrogRolling()
    {
        frog.velocity = Vector3.zero;
        frog.angularVelocity = Vector3.zero;
    }
}
