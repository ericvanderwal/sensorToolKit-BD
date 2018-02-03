using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Movement;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

namespace BehaviorDesigner.Runtime.Tasks.DGD
{
	[TaskCategory("Custom")]
	[TaskDescription("Get the distance between two game objects.")]
	public class DistanceBetweenObjects : Action
    {
	    
	    [Tooltip("First game object.")]
	    public SharedGameObject m_FirstGameobject;
	    
	    [Tooltip("Second game object.")]
	    public SharedGameObject m_SecondGameobject;
	    
	    [Tooltip("Distance between the two objects as a float.")]
	    public SharedFloat m_distance;

	    public override TaskStatus OnUpdate()
        {

	        if(m_FirstGameobject.Value == null || m_SecondGameobject.Value == null) 
	        {
			return TaskStatus.Failure;
	        }
	        
	        else
	        {
	        	
	        	m_distance.Value = Vector3.Distance(m_FirstGameobject.Value.transform.position, m_SecondGameobject.Value.transform.position);
	        	return TaskStatus.Success;
	        	
	        }

            return TaskStatus.Running;
        }
        
	    public override void OnReset()
	    {

		    m_SecondGameobject = null;
		    m_FirstGameobject = null;
		    m_distance = null;
	    }
    }
}