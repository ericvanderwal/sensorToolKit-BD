// Dumb Game Dev 2018
// Eric Vander Wal

using UnityEngine;
using Opsive.ThirdPersonController;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityBehaviour
{
	[TaskCategory("Custom")]
	[TaskDescription("Get own game object (self).")]
    public class getSelf : Action
    {

	   [Tooltip("Save self to this game object.")]
        public SharedGameObject targetGameObject;

        public override TaskStatus OnUpdate()
        {

            if (targetGameObject == null)
            {
                return TaskStatus.Failure;
            }

	        targetGameObject.Value = this.transform.gameObject;
	        
	        if(targetGameObject.Value == this.transform.gameObject)
	        {
		        targetGameObject.Value = this.transform.gameObject;
		        return TaskStatus.Success;

	        }
	        
	        return TaskStatus.Running;

        }


        public override void OnReset()
        {
            targetGameObject = null;

        }
    }
}