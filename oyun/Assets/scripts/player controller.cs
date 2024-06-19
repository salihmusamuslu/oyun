using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float hiz=25.0f;
    public Rigidbody rb;
    private Animator playerAnim;
    private float turnSpeed = 45.0f;
    private float yatayGiris;
    private float dikeyGiris;
    public float jumpForce = 10f; // Z�plama kuvveti
    private bool isGrounded = true; // Karakterin yerde olup olmad���n� kontrol eder
   





    // Start is called before the first frame update
    void Start()
    {
         playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        yatayGiris = Input.GetAxis("Horizontal");
        dikeyGiris = Input.GetAxis("Vertical");
        if (dikeyGiris != 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * dikeyGiris);
            playerAnim.SetTrigger("walking");
        }
        transform.Translate(Vector3.right * Time.deltaTime * yatayGiris);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Karakter art�k yerde de�il
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        // Karakter yere �arpt���nda isGrounded'� true yap
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
