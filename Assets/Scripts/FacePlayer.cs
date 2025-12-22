using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    [Header("Configuración")]
    public float turnSpeed = 5f;
    public bool onlyWhenClose = false;
    public float range = 10f;

    private Transform playerTransform;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("No se encontró ningún objeto con el Tag 'Player'");
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (!onlyWhenClose || distance <= range)
        {
            RotateTowardsPlayer();
        }
    }

    void RotateTowardsPlayer()
    {
        Vector3 direction = playerTransform.position - transform.position;

        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }
}