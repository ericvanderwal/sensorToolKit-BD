// Dumb Game Dev 2018

using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Movement;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using SensorToolkit;

namespace BehaviorDesigner.Runtime.Tasks.DGD
{
	[TaskCategory("Sensor Tookit")]
	[TaskDescription("Finds the nearest valid target using sensor tookit. Returns success if object is found. Failure if no object found.")]
	public class SensorGetNearest : Action
    {
	    
	    [Tooltip("Sensor Game Object.")]
	    public SharedGameObject m_SensorSource;
	    
	    [Tooltip("The nearest game object target")]
	    public SharedGameObject m_NearestTarget;

	    private TriggerSensor sensor;
	    private GameObject sensorGO;

	    public override void OnStart()
        {	        
		
	        sensorGO = m_SensorSource.Value;
	        sensor = sensorGO.GetComponent<TriggerSensor>();
	        
	        if(sensor == null) 
	        {
		        Debug.Log ("Sensor not found");
		        return;
	        }
        }

        public override TaskStatus OnUpdate()
        {

	        var _nearest = sensor.GetNearest();
	        m_NearestTarget.Value = _nearest;
	        
	        // if nearest is null, failure
	        if(_nearest == null)
	        {
	        	return TaskStatus.Failure;
	        	
	        }
	        
	        //  nearest not null, success
	        if(_nearest != null)
	        {
	        	
	        	return TaskStatus.Success;
	        	
	        }

            return TaskStatus.Running;
        }
        
	    public override void OnReset()
	    {
		    m_NearestTarget = null;
		    m_SensorSource = null;
	    }
    }
}