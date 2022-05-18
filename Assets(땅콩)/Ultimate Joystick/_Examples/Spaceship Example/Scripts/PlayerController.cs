/* PlayerController.cs */
/* Written by Kaz Crowe */
using UnityEngine;

namespace UltimateJoystickExample.Spaceship
{
	public class PlayerController : MonoBehaviour
	{
		
		[Header( "Speeds" )]
		public float rotationSpeed = 45.0f;
		public float accelerationSpeed = 2.0f;
		public float maxSpeed = 3.0f;
		public float shootingCooldown = 0.2f;

		
		[Header( "Assigned Variables" )]
		public GameObject bulletPrefab;

		
		Rigidbody myRigidbody;
		public Transform gunTrans;
		public Transform bulletSpawnPos;
		public GameObject playerVisuals;

		
		float shootingTimer = 0;

		
		bool canControl = true;

		
		Vector3 movePosition;
		Vector3 shootPosition;

		
		void Start ()
		{
			
			myRigidbody = GetComponent<Rigidbody>();
		}

		void Update ()
		{
			
			movePosition = new Vector3( UltimateJoystick.GetHorizontalAxis( "Movement" ), UltimateJoystick.GetVerticalAxis( "Movement" ), 0 );
			shootPosition = new Vector3( UltimateJoystick.GetHorizontalAxis( "Shooting" ), UltimateJoystick.GetVerticalAxis( "Shooting" ), 0 );

			
			if( canControl == false )
				return;

			
			if( UltimateJoystick.GetJoystickState( "Shooting" ) && shootingTimer <= 0 )
			{
				
				shootingTimer = shootingCooldown;
				CreateBullets();
			}

			
			if( shootingTimer > 0 )
				shootingTimer -= Time.deltaTime;
		}

		void FixedUpdate ()
		{
			
			if( canControl == false )
			{
				
				myRigidbody.rotation = Quaternion.identity;
				myRigidbody.position = Vector3.zero;
				myRigidbody.velocity = Vector3.zero;
				myRigidbody.angularVelocity = Vector3.zero;
			}
			else
			{
				
				Vector3 lookRot = new Vector3( movePosition.x, 0, movePosition.y );
				transform.LookAt( transform.position + lookRot );

				
				Vector3 gunRot = new Vector3( shootPosition.x, 0, shootPosition.y );
				gunTrans.LookAt( gunTrans.position + gunRot );

				
				myRigidbody.AddForce( transform.forward * UltimateJoystick.GetDistance( "Movement" ) * 1000.0f * accelerationSpeed * Time.deltaTime );

				
				if( myRigidbody.velocity.magnitude > maxSpeed )
					myRigidbody.velocity = myRigidbody.velocity.normalized * maxSpeed;

				
				CheckExitScreen();
			}
		}

		void CheckExitScreen ()
		{
			
			if( Camera.main == null )
				return;
			
			
			if( Mathf.Abs( myRigidbody.position.x ) > Camera.main.orthographicSize * Camera.main.aspect )
				myRigidbody.position = new Vector3( -Mathf.Sign( myRigidbody.position.x ) * Camera.main.orthographicSize * Camera.main.aspect, 0, myRigidbody.position.z );
			
			
			if( Mathf.Abs( myRigidbody.position.z ) > Camera.main.orthographicSize )
				myRigidbody.position = new Vector3( myRigidbody.position.x, myRigidbody.position.y, -Mathf.Sign( myRigidbody.position.z ) * Camera.main.orthographicSize );
		}

		void CreateBullets ()
		{
			
			GameObject bullet = Instantiate( bulletPrefab, bulletSpawnPos.position, bulletSpawnPos.rotation ) as GameObject;

			
			bullet.name = bulletPrefab.name;
			
			
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 200.0f;

			
			Destroy( bullet, 3.0f );
		}
	}
}