using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Kecepatan pergerakan karakter
    public float moveSpeed = 25f;

    // Variable untuk menampung input dari pengguna
    private Vector3 movement;

    // Reference ke Rigidbody 2D (bisa juga menggunakan Rigidbody3D tergantung proyek Anda)
    private Rigidbody2D rb;

    // health system reference
    private HealthManager healthManager;
    private Enemy enemy;
    private ShootingManager shootingManager;
    public bool canMove = true;
    private SpriteRenderer spriteRenderer;
    public AudioSource footstepAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Mengambil komponen Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        // initialize health player
        healthManager = GetComponent<HealthManager>();
        shootingManager = GetComponent<ShootingManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        FaceMouse();
        if (canMove && (movement.x != 0 || movement.y != 0))
        {
            PlayFootstepSound();
        }
    }
    void PlayFootstepSound()
    {
        if (!footstepAudioSource.isPlaying) // Periksa apakah audio sedang diputar
        {
            footstepAudioSource.PlayOneShot(footstepAudioSource.clip);
        }
    }
    void FaceMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Menyamakan posisi z

        // Menghitung arah dari player ke mouse 
        Vector3 direction = mousePosition - transform.position; // Define 'direction' here

        // Membalik sprite jika mouse di sebelah kiri player
        if (direction.x < 0)
        {
            
            transform.localScale = new Vector3(1f, 1f, 1f);  // Kembalikan ke arah semula
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Balik seluruh player ke kiri
        }
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
        if (canMove)
        {
        rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Death")) {
            healthManager.TakeDamage();
        }
    }
}
