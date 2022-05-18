/* AsteroidController.cs */
/* Written by Kaz Crowe */
using UnityEngine;
using System.Collections;

namespace UltimateJoystickExample.Spaceship
{
	public class AsteroidController : MonoBehaviour
	{
		
		public GameManager asteroidManager;
		Rigidbody myRigidbody;

		
		bool canDestroy = false;
		bool isDestroyed = false;
		public bool isDebris = false;
	

		public void Setup ( Vector3 force, Vector3 torque )
		{
			
			myRigidbody = GetComponent<Rigidbody>();

			
			myRigidbody.AddForce( force );
			myRigidbody.AddTorque( torque );

			
			StartCoroutine( DelayInitialDestruction( isDebris == true  ? 0.25f : 1.0f ) );
		}

		IEnumerator DelayInitialDestruction ( float delayTime )
		{
			
			yield return new WaitForSeconds( delayTime );

			
			canDestroy = true;
		}
	
		void Update ()
		{
			
			if( Mathf.Abs( transform.position.x ) > Camera.main.orthographicSize * Camera.main.aspect * 1.3f || Mathf.Abs( transform.position.z ) > Camera.main.orthographicSize * 1.3f )
			{
				
				if( canDestroy == true )
					Destroy( gameObject );
			}
		}

		void OnCollisionEnter ( Collision theCollision )
		{
			
			if( theCollision.gameObject.name == "Bullet" )
			{
				
				Destroy( theCollision.gameObject );

				
				asteroidManager.ModifyScore( isDebris );

				
				if( isDebris == false )
					Explode();
				
				else
					Destroy( gameObject );
			}
			
			else if( theCollision.gameObject.name == "Player" )
			{
				
				asteroidManager.SpawnExplosion( theCollision.transform.position );

				
				Destroy( theCollision.gameObject );

				
				if( isDebris == false )
					Explode();
				
				else
					Destroy( gameObject );

				
				asteroidManager.ShowDeathScreen();
			}
			
			else
			{
				
				if( isDebris == false && canDestroy == true )
					Explode();
				
				else if( isDebris == true && canDestroy == true )
					Destroy( gameObject );
			}

			
			asteroidManager.SpawnExplosion( transform.position );
		}

		void Explode ()
		{
			
			if( isDestroyed == true )
				return;

			
			isDestroyed = true;

			
			asteroidManager.SpawnDebris( transform.position );

			
			Destroy( gameObject );
		}
	}
}