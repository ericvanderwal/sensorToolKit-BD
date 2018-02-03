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
	[TaskDescription("Add together two vector 3.")]
	public class AddVector3 : Action
    {
	    
	    [Tooltip("First vector 3.")]
	    public SharedVector3 m_FirstVector3;
	    
	    [Tooltip("Second vector 3.")]
	    public SharedVector3 m_SecondVector3;
	    
	    [Tooltip("Result of two added vector 3.")]
	    public SharedVector3 m_Result;

	    public override TaskStatus OnUpdate()
        {

	        if(m_FirstVector3.Value == null || m_SecondVector3.Value == null) 
	        {
			return TaskStatus.Failure;
	        }
	        
	        else
	        {
	        	
	        	m_Result.Value = m_FirstVector3.Value + m_SecondVector3.Value;
	        	return TaskStatus.Success;
	        	
	        }

            return TaskStatus.Running;
        }
        
	    public override void OnReset()
	    {

		    m_FirstVector3 = null;
		    m_SecondVector3 = null;
		    m_Result = null;
	    }
    }
}