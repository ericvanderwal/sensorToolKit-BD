// Dumb Game Dev 2018
// Eric Vander Wal

using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Movement;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityBehaviour
{
	[TaskCategory("Random")]
	[TaskDescription("Get a random game object from a game object list.")]
    public class getRandomGameobjectList : Action
    {
	    [Tooltip("A list of game objects.")]
	    public SharedGameObjectList m_gameObjectList; 
	    
	    [Tooltip("Returned random game object.")]
	    public SharedGameObject m_ReturnedObject;

	    public override void OnStart()
	    {	  
	    		    	
	    }

        public override TaskStatus OnUpdate()
        {

	        int _listTotal = m_gameObjectList.Value.Count;
	        Debug.Log("Total Number is " + _listTotal);
	        int randomNum = Random.Range(0, _listTotal);
	        Debug.Log("Random Number is " + randomNum);
	        m_ReturnedObject.Value = m_gameObjectList.Value[randomNum];
	        
	        if(m_gameObjectList.Value != null)
	        {
	        	return TaskStatus.Success;
	        }
	        
	        if(m_gameObjectList.Value == null)
	        {
	        	return TaskStatus.Failure;
	        }
	        
	        return TaskStatus.Running;
	        
        }




        public override void OnReset()
        {
	        m_gameObjectList = null;
	        m_ReturnedObject = null;

        }
    }
}