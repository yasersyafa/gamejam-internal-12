using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float shakeDuration = 0.2f;          // Durasi shake
    public float shakeMagnitude = 0.1f;        // Kekuatan shake
    private Vector3 initialPosition;            // Posisi awal kamera

    void Start()
    {
        initialPosition = transform.position;  // Simpan posisi awal kamera
    }

    // Fungsi untuk memulai camera shake
    public void ShakeCamera() 
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // Hitung posisi shake secara acak
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            transform.position = initialPosition + new Vector3(x, y,   
 0f);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Kembalikan kamera ke posisi awal
        transform.position = initialPosition;
    }
}
