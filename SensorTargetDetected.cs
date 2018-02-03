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
	[TaskDescription("Retuns true if a target is detected.")]
	public class SensorTargetDetected : Action
    {
	    
	    [Tooltip("Sensor Game Object.")]
	    public SharedGameObject m_SensorSource;
	    
	    [Tooltip("Target to check if detected.")]
	    public SharedGameObject m_target;
	    
	    [Tooltip("True if target is found.")]
	    public SharedBool m_targetDetected;

	    private Sensor sensor;
	    private bool _detected;

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
	        _detected = sensor.IsDetected(m_target.Value);
	        m_targetDetected.Value = _detected;
	        
	        if(_detected == null)
	        {
	        	return TaskStatus.Failure;
	        	
	        }
	        
	        // detected is false
	        if(!_detected)
	        {
	        	
	        	return TaskStatus.Failure;
	        	
	        }
	        
	        //  finally some success
	        if(_detected)
	        {
	        	
	        	return TaskStatus.Success;
	        	
	        }

            return TaskStatus.Running;
        }
        
	    public override void OnReset()
	    {

		    m_SensorSource = null;
		    m_target = null;
		    m_targetDetected = null;
	    }
    }
}