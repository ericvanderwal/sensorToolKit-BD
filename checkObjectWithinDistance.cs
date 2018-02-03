// Dumb Game Dev 2018
// Eric Vander Wal

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Movement;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

namespace BehaviorDesigner.Runtime.Tasks.DGD
{
	[TaskCategory("Custom")]
	[TaskDescription("Use a ray cast to check if tagged object is within distance of agent's forward direction.")]
	public class checkObjectWithinDistance : Action
    {
	    
		[Tooltip("Distance to check")]
	    public SharedFloat m_CheckDistance;

	    [Tooltip("Ignore these layers when checking")]
	    public LayerMask m_layerMask = -1;
	    
	    [Tooltip("Tag to check. Ie Wall.")]
	    public SharedString m_Tag;
	    
	    [Tooltip("Offset for raycast.")]
	    public SharedVector3 m_offset;
	    
	    [Tooltip("Enable debug raycast line.")]
	    public SharedBool m_enableDebug;
	    
	    [Tooltip("Output: True if hit the tagged object within the specificed distance")]
	    public SharedBool m_Hit;
	    
	    private Vector3 origin;
	    private bool complete = false;
	    private RaycastHit hit;
	    private bool isHit;
	    private Vector3 direction;

	    public override void OnStart()
        {	        
		
        }
        
	    public override TaskStatus OnUpdate()
	    {
	    	
		    // get the orgin for the ray
		    origin = this.gameObject.transform.position + m_offset.Value;
		    direction = this.gameObject.transform.rotation * Vector3.forward;
		    
		    // check is hit and save hit out
		    isHit = Physics.Raycast(origin, direction, out hit, m_CheckDistance.Value, m_layerMask);   
		   
		    if(m_enableDebug.Value) 
		    {
			    Debug.DrawRay(origin, direction * m_CheckDistance.Value, Color.green, 3);
		    }
		    
		    // if hit do the following
		    if(isHit)
		    {
			    if(hit.transform.gameObject.tag == m_Tag.Value)
			    {
				    m_Hit.Value = true;
				    return TaskStatus.Success;
				    
			    }
		        
			    else
			    {
				    m_Hit.Value = false;
				    return TaskStatus.Failure;

			    }
		    }
		    
		    // not hit, return failure.
		    if(!isHit)
		    {
		    	
			    m_Hit.Value = false;
			    return TaskStatus.Failure;

		    }
	    	
		    return TaskStatus.Running;

	    }

        
	    public override void OnReset()
	    {
		    m_Tag = null;
		    m_layerMask = -1;
		    m_Hit = null;
		    m_CheckDistance = null;
		    m_enableDebug = false;
		    m_offset = null;
	    }
    }
}