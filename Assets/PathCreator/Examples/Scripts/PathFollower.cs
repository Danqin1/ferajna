using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        public float distanceTravelled;

        private float moveMax = 10;
        private float moveMin = 0;

/*        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }*/

        void Update()
        {
            if (pathCreator != null)
            {
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }

            if (Input.mouseScrollDelta.y  != 0)
            {
                distanceTravelled += speed * Input.mouseScrollDelta.y;
                distanceTravelled = Mathf.Clamp(distanceTravelled, moveMin, moveMax);
            }
        }

        public void Setup(Vector2 constrains, float startDist)
        {
            moveMin = constrains.x;
            moveMax = constrains.y;
            distanceTravelled = startDist;
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}