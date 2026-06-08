using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public float posisiY_DindingBawah = -4.5f; // Mengunci posisi spawner di area lantai/dinding bawah

    void Update()
    {
        // Spawner hanya aktif jika game sudah dimulai oleh tombol Play UI
        if (GameManager.instance == null || !GameManager.instance.isGameActive) return;

        // Membaca posisi horizontal (X) dari kursor mouse di area layar game
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Mengatur posisi objek Spawner agar ikut bergeser kiri-kanan sesuai mouse, 
        // tetapi tingginya tetap terkunci aman di lantai bawah (Y)
        transform.position = new Vector3(mousePosition.x, posisiY_DindingBawah, 0f);

        // Klik kiri mouse tanpa batas untuk menembakkan peluru secara instan ke atas
        if (Input.GetMouseButtonDown(0))
        {
            LepasPeluru();
        }
    }

    void LepasPeluru()
    {
        if (ObjectPool.Instance != null)
        {
            GameObject bullet = ObjectPool.Instance.GetPooledObject();
            if (bullet != null)
            {
                // Set posisi peluru tepat di koordinat spawner bawah saat ini
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.identity; // Rotasi tegak lurus menghadap ke atas
                bullet.SetActive(true);
            }
        }
    }
}