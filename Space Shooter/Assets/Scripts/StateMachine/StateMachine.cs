using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public class StateMachine : MonoBehaviour
{
    public BaseState currentState { get; private set; }
    public BaseState contineousState {  get; private set; }

    public event Action<BaseState> OnStateChanged;

    private Dictionary<Type, BaseState> availableState;
    private Type nextState;
    private Type previousState;

    // Start is called before the first frame update
    /// <summary>
    /// Set all the states for the perticular object
    /// </summary>
    /// <param name="states"></param>
    public void SetAvailableStates(Dictionary<Type, BaseState> states)
    {
        availableState = states;
    }

    /// <summary>
    /// Set the contineous state
    /// </summary>
    /// <param name="state">state type</param>
    public void SetContineousState(Type state)
    {
        contineousState = availableState[state];
        contineousState?.OnStateEnter();
    }

    // Update is called once per frame
    /// <summary>
    /// Process the current state and set the next state if required
    /// </summary>
    private void Update()
    {
        if (currentState != null)
        {
            nextState = currentState.OnStateUpdate();
        }
        if (nextState != null)
        {
            ChangeNextState(nextState);
        }
        if(contineousState != null)
        {
            contineousState.OnStateUpdate();
        }
    }

    /// <summary>
    /// Change current state to next state
    /// </summary>
    /// <param name="nxtState"></param>
    public void ChangeNextState(Type nxtState)
    {
        if (nxtState != null)
        {
            currentState?.OnStateExit();

            previousState = currentState?.GetType();
            currentState = availableState[nxtState];
            nextState = null;

            OnStateChanged?.Invoke(currentState);
            currentState?.OnStateEnter();
        }
    }

    /// <summary>
    /// On object destroy call the destroy method in all states
    /// </summary>
    public void OnDestroyState()
    {
        foreach (KeyValuePair<Type, BaseState> valuePair in availableState)
        {
            availableState[valuePair.Key]?.OnStateDestroy();
        }
    }
}
