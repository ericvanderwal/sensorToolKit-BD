// Dumb Game Dev
// Eric Vander Wal

using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Movement;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using SensorToolkit;

namespace BehaviorDesigner.Runtime.Tasks.DGD
{
	[TaskCategory("Sensor Tookit")]
	[TaskDescription("Get a list of all detected targets from nearest to farthest.")]
	public class SensorGetAllDetected : Action
    {
	    
	    [Tooltip("Sensor Game Object.")]
	    public SharedGameObject m_SensorSource;

	    [Tooltip("Game object list of targets that are detected.")]
	    public SharedGameObjectList m_targets;

	    private Sensor sensor;

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
	        var allDetected = sensor.GetDetected();
	        m_targets.Value = allDetected;
	        
	        if(allDetected == null)
	        {
	        	return TaskStatus.Failure;
	        	
	        }
	        
	        if(allDetected.Count == 0)
	        {
	        	return TaskStatus.Failure;
	        	
	        }

	        //  finally some success
	        if(allDetected.Count != 0)
	        {
	        	
	        	return TaskStatus.Success;
	        	
	        }

            return TaskStatus.Running;
        }
        
	    public override void OnReset()
	    {
		    m_SensorSource = null;
		    m_targets = null;
	    }
    }
}