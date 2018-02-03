// Dumb Game Dev
// Eric Vander Wal

using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Movement;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

namespace BehaviorDesigner.Runtime.Tasks.DGD
{
	[TaskCategory("Custom")]
	[TaskDescription("Check which of the two game objects are closer to the agent.")]
	public class CloserToAgent : Action
    {
	    
	    [Tooltip("Set the agent here.")]
	    public SharedGameObject m_agent;
	    
	    [Tooltip("First game object.")]
	    public SharedGameObject m_FirstGameobject;
	    
	    [Tooltip("Second game object.")]
	    public SharedGameObject m_SecondGameobject;
	    
	    [Tooltip("Closer Game object.")]
	    public SharedGameObject m_CloserGameobject;
	    
	    [Tooltip("Distance to the closest game object from the agent.")]
	    public SharedFloat m_distance;
	    

	    public override TaskStatus OnUpdate()
	    {
        	
		    if(m_FirstGameobject.Value == null || m_SecondGameobject.Value == null || m_agent.Value == null) 
		    {
			    return TaskStatus.Failure;
		    }

	       
		    // get distances
		    float objectDistance1 = Vector3.Distance(m_FirstGameobject.Value.transform.position, m_agent.Value.transform.position);
		    float objectDistance2 = Vector3.Distance(m_SecondGameobject.Value.transform.position, m_agent.Value.transform.position);
	        
		   
		    // second object is closer
		    if(objectDistance1 >= objectDistance2)
		    {
		    	
		    	m_CloserGameobject.Value = m_SecondGameobject.Value;
		    	m_distance.Value = objectDistance2;
			    return TaskStatus.Success;
			    
		    }
		    
		   
		    // first object is closerz
		    if(objectDistance1 < objectDistance2)
		    {
		    	
		    	m_CloserGameobject.Value = m_FirstGameobject.Value;
			    m_distance.Value = objectDistance1;
			    return TaskStatus.Success;
		    	
		    }
	        

            return TaskStatus.Running;
        }
        
	    public override void OnReset()
	    {

		    m_CloserGameobject = null;
		    m_distance = null;
		    m_FirstGameobject = null;
		    m_SecondGameobject = null;
		    m_agent = null;
		    

	    }
    }
}