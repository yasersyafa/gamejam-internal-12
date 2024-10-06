using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
      // Prefab peluru
    public GameObject firePoint;      // Titik asal peluru (misalnya posisi player)
    public AudioSource bubbleAudioSource;

    // Method untuk menangani aksi menembak
    public void Shoot(Vector2 target)
    {
        // Buat peluru di posisi player
        // GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.transform.position; // Gunakan posisi firePoint
            bullet.SetActive(true);
        }
        if (bubbleAudioSource != null)
        {
            bubbleAudioSource.PlayOneShot(bubbleAudioSource.clip);
        }
        // Inisialisasi peluru dengan target posisi
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Initialize(target);
    }
}
