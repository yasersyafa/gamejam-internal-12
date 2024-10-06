using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 25f;
    private Vector2 targetPosition;
    private float maxDistance = 20f; // Jarak maksimum peluru

    

    private Vector2 startPosition;

    void Start()
    {
        
    }

    // Method untuk inisialisasi peluru
    public void Initialize(Vector2 target)
    {
        startPosition = transform.position;
        targetPosition = target;
    }

    void Update()
    {
        // Menggerakkan peluru menuju target
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Hitung jarak yang sudah ditempuh
        float distanceTravelled = Vector2.Distance(startPosition, transform.position);

        // Hapus peluru jika sudah mencapai jarak maksimum
        if (distanceTravelled >= maxDistance || (Vector2)transform.position == targetPosition)
        {
            gameObject.SetActive(false);
        }
    }

    


}
