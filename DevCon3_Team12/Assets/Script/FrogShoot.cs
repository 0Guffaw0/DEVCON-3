using UnityEngine;



public class FrogShoot : MonoBehaviour

{

    float xRot, yRot = 0f;

    public float roatationSpeed = 5f;



    public Rigidbody frog;

    public float shootPower = 30f;

    public LineRenderer line;



    // Update is called once per frame 

    void Update()

    {

        transform.position = frog.position;



        if (Input.GetMouseButton(0))

        {

            xRot += Input.GetAxis("Mouse X") * roatationSpeed;

            yRot += Input.GetAxis("Mouse Y") * roatationSpeed;



            if (yRot < -35f)

            {

                yRot = -35f;

            }



            transform.rotation = Quaternion.Euler(yRot, xRot, 0f);

            line.gameObject.SetActive(true);

            line.SetPosition(0, transform.position);

            line.SetPosition(1, transform.position + transform.forward * 4f);

        }



        if (Input.GetMouseButtonUp(0))

        {

            frog.velocity = transform.forward * shootPower;

            line.gameObject.SetActive(false);



        }



    }

}