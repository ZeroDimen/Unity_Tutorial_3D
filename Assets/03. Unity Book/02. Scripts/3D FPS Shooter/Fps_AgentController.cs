using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class FPS_AgentController : MonoBehaviour
{
    public Camera camera;
    // public Transform player;
    private NavMeshAgent agent;
    public NavMeshSurface surface;

    // public Transform[] points;
    // public int index;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        surface.transform.position = agent.transform.position;
        surface.BuildNavMesh();
    }

    void Update()
    {
        // agent.SetDestination(points[index].position);
        //
        // if (agent.remainingDistance <= 1.5f) // 목적지와의 거리가 1.5 이하일 경우
        // {
        //     Debug.Log("목적지 변경");
        //     
        //     // index++;
        //     //
        //     // if (index >= points.Length)
        //     //     index = 0;
        //     
        //     int temp = index;
        //     {
        //         index = Random.Range(0, points.Length);
        //     }
        //     
        //     if (temp == index)
        //     {
        //         index = Random.Range(0, points.Length);
        //     }
        //         
        // }
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (Vector3.Distance(transform.position, surface.transform.position) > 4f)
        {
            surface.transform.position = agent.transform.position;
            surface.BuildNavMesh();
        }
    }
}