// Dumb Game Dev 2018
// Eric Vander Wal

using UnityEngine;
using Opsive.ThirdPersonController;
using SensorToolkit;
using System.Linq;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Movement;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;


namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityBehaviour
{
	[TaskCategory("Sensor Tookit")]
	[TaskDescription("Get all the LOS targets on a specific game object.")]
    public class SensorGetAllLOSPoints : Action
    {
	    [Tooltip("The sensor game object.")]
	    public SharedGameObject m_selfObject;

	    [Tooltip("The target object whose raycast targets should be queried.")]
	    public SharedGameObject m_targetObject;

	    [Tooltip("Store the array of visible LOSTarget Transforms here.")]
	    public SharedGameObjectList m_storeTargetTransforms;

	    private TriggerSensor sensor;
	    
	    
	    public override void OnStart()
	    {	  
	    	
	    	sensor = m_selfObject.Value.GetComponent<TriggerSensor>();
	    	
	    }

        public override TaskStatus OnUpdate()
        {

	        if (sensor == null)
	        {
		        return TaskStatus.Failure;
	        }
	        
	        if (sensor != null)
	        {
	        	
		        if (m_storeTargetTransforms.Value != null)
		        {
			        var transforms = sensor.GetVisibleTransforms(m_targetObject.Value);
			        var gameObjects = new UnityEngine.GameObject[transforms.Count];
			        for (int i = 0; i < gameObjects.Length; i++)
			        {
				        gameObjects[i] = transforms[i].gameObject;
			        }
			        
			        var theList = gameObjects.ToList();
			        m_storeTargetTransforms.Value = theList;
		        }
		            	
	        }

	        if (m_storeTargetTransforms.Value.Count == 0)
	        {
		        return TaskStatus.Failure;
	        }
	        
	        if (m_storeTargetTransforms.Value.Count >= 1)
	        {
		        return TaskStatus.Success;
	        }
	       
	        return TaskStatus.Running;

        }


        public override void OnReset()
        {
	        m_selfObject = null;
	        m_storeTargetTransforms = null;
	        m_targetObject = null;

        }
    }
}