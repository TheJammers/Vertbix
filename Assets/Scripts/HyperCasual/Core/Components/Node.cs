using UnityEngine;

namespace HyperCasual.Components
{
    public class Node
        : MonoBehaviour
    {
        public void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position + Vector3.up*0.1f, 0.03f);
        }
    }
}
