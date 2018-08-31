using UnityEngine;
using System.Collections;


namespace Wacki.IndentSurface
{
    /// <summary>
    /// Simple control script for our sphere that leaves a track in the snow.
    /// </summary>
    public class IndentActor : MonoBehaviour
    {
        [Range(0.0f, 0.2f)]
        public float drawDelta = 0.01f;
        private Vector3 _prevDrawPos;
        
        void Update()
        {
            
            if (Vector3.Distance(_prevDrawPos, transform.parent.position) < drawDelta)
                return;

            _prevDrawPos = transform.parent.position;

            //Debug.DrawLine(transform.parent.position, transform.parent.position + Vector3.down);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                var texDraw = hit.collider.gameObject.GetComponent<IndentDraw>();
                if (texDraw == null)
                    return;

                texDraw.IndentAt(hit);
            }
        }
    }

}