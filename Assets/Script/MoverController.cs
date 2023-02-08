using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoverController : MonoBehaviour
{

    public List<GraphNode<LocationInfo>> visualPath { get; set; }
    public GraphNode<LocationInfo> destination { get; set; }
    public TextMeshProUGUI Des;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    int numberOfVisitedNodes = 0;
    void Update()
    {
        Des.text = destination.data.name;
        if (visualPath.Count > 0 && numberOfVisitedNodes < visualPath.Count)
        {
            GraphNode<LocationInfo> des = visualPath[numberOfVisitedNodes];

            float step = 1 * Time.deltaTime;
            // move sprite towards the target location
            Vector2 point = new Vector2(des.data.x, des.data.y);
            transform.position = Vector2.MoveTowards(transform.position, point, step);

            if (transform.position.x == des.data.x && transform.position.y == des.data.y)
            {
                numberOfVisitedNodes++;
            }
        }
        if(numberOfVisitedNodes == visualPath.Count) { 
            Destroy(gameObject); 
        }
    }
}
