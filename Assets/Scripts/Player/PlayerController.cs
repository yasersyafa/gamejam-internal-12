using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1, 10)]
    // Kecepatan pergerakan karakter
    public float moveSpeed = 5f;

    // Variable untuk menampung input dari pengguna
    private Vector3 movement;

    // Reference ke Rigidbody 2D (bisa juga menggunakan Rigidbody3D tergantung proyek Anda)
    private Rigidbody2D rb;

    // health system reference
    private HealthManager healthManager;
    private Enemy enemy;
    private ShootingManager shootingManager;

    // Start is called before the first frame update
    void Start()
    {
        // Mengambil komponen Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        // initialize health player
        healthManager = GetComponent<HealthManager>();
        shootingManager = GetComponent<ShootingManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(healthManager.IsPlayerDead()) {
            Debug.Log("Lose");
        }
            // Mendapatkan input dari keyboard (WASD atau tombol panah)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Menyimpan nilai input dalam variabel movement
        movement = new Vector3(moveX, moveY, 0f).normalized;
        HandleShooting();
    }

    void HandleShooting() {
        if (Input.GetMouseButtonDown(0))
        {
            // Mendapatkan posisi kursor dalam koordinat dunia
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Menembak ke arah posisi mouse
            shootingManager.Shoot(mousePosition);
        }
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Menggerakkan karakter sesuai input
        rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Death")) {
            healthManager.TakeDamage();
        }
    }
}
