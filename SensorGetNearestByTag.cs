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
	[TaskDescription("Get the nearest target by tag.")]
	public class SensorGetNearestByTag : Action
    {
	    
	    [Tooltip("Sensor Game Object.")]
	    public SharedGameObject m_SensorSource;
	    
	    [Tooltip("Tag to filter by.")]
	    public SharedString m_TargetFilter;
	    
	    [Tooltip("Nearest found object by tag.")]
	    public SharedGameObject m_targetDetected;

	    private GameObject sensorGO;
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
	        
	        var _nearestGO = sensor.GetNearestByTag(m_TargetFilter.Value);
	        m_targetDetected.Value = _nearestGO;
	        
	        // detected is null
	        if(_nearestGO == null)
	        {
	        	return TaskStatus.Failure;
	        	
	        }

	        //  finally some success
	        else
	        {
	        	
	        	return TaskStatus.Success;
	        	
	        }

            return TaskStatus.Running;
        }
        
	    public override void OnReset()
	    {

		    m_SensorSource = null;
		    m_TargetFilter = null;
		    m_targetDetected = null;
	    }
    }
}