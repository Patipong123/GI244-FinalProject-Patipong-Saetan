using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    
    [SerializeField] private PlayerController player;

    void Start()
    {
        
        InvokeRepeating(nameof(SpawnObstacle), 1, 2);
        
    }

    void SpawnObstacle()
    {
        if (!player.isGameOver)
        {
            ObjectPooling.GetInstance().AcquireObstacle(spawnPoint.position, Quaternion.identity);

            if (Random.value < 0.8f)
            {
                Vector3 coinPosition = spawnPoint.position + new Vector3(3f, 4f, 0f);

                
                Quaternion coinRotation = Quaternion.Euler(90f, 180f, 0f); 

                ObjectPooling.GetInstance().AcquireCoin(coinPosition, coinRotation);
            }

            if (Random.value < 0.5f)
            {
                Vector3 enegyPosition = spawnPoint.position + new Vector3(3f, 2f, 0f);
                Quaternion enegyRotation = Quaternion.Euler(0f, 0f, 0f);
                ObjectPooling.GetInstance().AcquireEnegy(enegyPosition, enegyRotation);

            }

            if (Random.value < 0.2f)
            {
                Vector3 immortalPosition = spawnPoint.position + new Vector3(-4f, 0f, 0f);
                Quaternion immortalRotation = Quaternion.Euler(0f, 0f, 0f);
                ObjectPooling.GetInstance().AcquireImmortal(immortalPosition, immortalRotation);

            }

            if (Random.value < 0.2f)
            {
                Vector3 platformPosition = spawnPoint.position + new Vector3(9f, 2.5f, 0f);
                Quaternion platformRotation = Quaternion.Euler(0f, 0f, 0f);
                ObjectPooling.GetInstance().AcquirePlatform(platformPosition, platformRotation);

            }
        }
    }




}
