using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Movement;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using SensorToolkit;

namespace BehaviorDesigner.Runtime.Tasks.DGD
{
	[TaskCategory("Sensor Tookit")]
	[TaskDescription("Check a targets visibility percent in a float from 0 to 1.")]
	public class SensorGetVisibility : Action
    {
	    
	    [Tooltip("Sensor Game Object.")]
	    public SharedGameObject m_SensorSource;
	    
	    [Tooltip("Target to check if detected.")]
	    public SharedGameObject m_target;
	    
	    [Tooltip("The visibility of the target in a float. 0 not seen, 1 completely seen.")]
	    public SharedFloat m_visbility;

	    private Sensor sensor;
	    private float _visibility;

	    public override void OnStart()
        {
	        sensor = m_SensorSource.Value.GetComponent<Sensor>();
        }
   
	    // Check nearest target using Sensor Toolkit.
	    public override TaskStatus OnUpdate()
        {
	        // no sensor found
	        if(sensor == null) 
	        {
		        Debug.Log("No sensor found");
		        return TaskStatus.Failure;
	        }
	        
	        // detected is null
	        _visibility = sensor.GetVisibility(m_target.Value);
	        m_visbility.Value = _visibility;
	        
	        if(_visibility == null)
	        {

		        return TaskStatus.Failure;
	        	
	        }

	        //  finally some success
	        if(_visibility != null)
	        {
	        	
	        	return TaskStatus.Success;
	        	
	        }

            return TaskStatus.Running;
        }
        
	    public override void OnReset()
	    {
		    m_SensorSource = null;
		    m_target = null;
		    m_visbility = null;
	    }
    }
}