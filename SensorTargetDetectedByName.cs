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
	[TaskDescription("Returns a list of all Detected GameObjects ordered by distance filtered by name.")]
	public class SensorTargetDetectedByName : Action
    {
	    
	    [Tooltip("Sensor Game Object.")]
	    public SharedGameObject m_SensorSource;
	    
	    [Tooltip("Name to filter by.")]
	    public SharedString m_TargetFilter;
	    
	    [Tooltip("List of returned targets filtered by name.")]
	    public SharedGameObjectList m_targetsDetected;

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
	        
	        var _list = sensor.GetDetectedByName(m_TargetFilter.Value);
	        m_targetsDetected.Value = _list;
	        
	        // detected is null
	        if(_list == null)
	        {
	        	return TaskStatus.Failure;
	        	
	        }
	        
	        // detected is empty
	        if(_list.Count == 0)
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
		    m_targetsDetected = null;
	    }
    }
}