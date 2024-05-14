using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class eMove : MonoBehaviour
{
    public Transform targetPlayer;
    private NavMeshAgent agent;

    public Transform observer;

    public float fieldOfViewAngle = 110f;
    public float viewDistance = 10f;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float shootInterval = 1f; // Interval in seconds

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(ShootAtIntervals());
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(targetPlayer.position);
    }

    bool IsTargetVisible()
    {
        Vector3 directionToTarget = targetPlayer.position - observer.position;
        float distanceToTarget = directionToTarget.magnitude;

        // Check if the target is within view distance
        if (distanceToTarget > viewDistance)
        {
            return false;
        }

        // Calculate the angle between the forward vector of the observer and the direction to the target
        float angleToTarget = Vector3.Angle(observer.forward, directionToTarget);

        // Check if the target is within the field of view angle
        if (angleToTarget > fieldOfViewAngle * 0.5f)
        {
            return false;
        }

        // Perform a raycast to check for obstacles
        RaycastHit hit;
        if (Physics.Raycast(observer.position, directionToTarget, out hit, viewDistance))
        {
            if (hit.transform == targetPlayer)
            {
                // No obstacles, target is visible
                return true;
            }
        }

        // Obstacle detected, target is not visible
        return false;
    }

    IEnumerator ShootAtIntervals()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);

            if (IsTargetVisible())
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        Debug.Log("Bullet fired at " + Time.time);
    }

    void OnDrawGizmos()
    {
        if (observer == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(observer.position, viewDistance);

        Vector3 forward = observer.forward * viewDistance;
        Vector3 leftBoundary = Quaternion.Euler(0, -fieldOfViewAngle * 0.5f, 0) * forward;
        Vector3 rightBoundary = Quaternion.Euler(0, fieldOfViewAngle * 0.5f, 0) * forward;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(observer.position, observer.position + leftBoundary);
        Gizmos.DrawLine(observer.position, observer.position + rightBoundary);

        if (targetPlayer != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(observer.position, targetPlayer.position);
        }
    }
}
