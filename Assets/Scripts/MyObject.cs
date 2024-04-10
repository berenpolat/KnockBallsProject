using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace  Entities
{
	
public class 
	MyObject : MonoBehaviour
{
	public virtual int VariantId { get; private set; }

	public event Action Activated;
	public event Action DeActivated;
	public event Action Destroyed;

	protected virtual void Initialize()	{ }

	protected virtual void Awake()
	{
		Initialize();
		Registration();
	}
	protected virtual void OnDestroy()
	{
		Destroyed?.Invoke();
		UnRegistration();
				
	}

	protected virtual void OnEnable()
	{
		Activated?.Invoke();
		
	}
	protected virtual void OnDisable()
	{
		DeActivated?.Invoke();
	}
	protected virtual void UnRegistration()
	{
		Application.quitting -= UnRegistration;
	}
	protected virtual void Registration()
	{
		Application.quitting += UnRegistration;
	}
	public virtual void Activate()
	{
		gameObject.SetActive(true);
	}

	public virtual void Deactivate()
	{
		gameObject.SetActive(false);
	}


}

}