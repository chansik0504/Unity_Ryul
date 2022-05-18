/* GameManager.cs */
/* Written by Kaz Crowe */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UltimateJoystickExample.Spaceship
{
	public class GameManager : MonoBehaviour
	{
		
		private static GameManager instance;
		public static GameManager Instance
		{
			get { return instance; }
		}

		
		[Header( "Prefabs" )]
		public GameObject astroidPrefab;
		public GameObject debrisPrefab;
		public GameObject explosionPrefab;
		public GameObject playerExplosionPrefab;

		
		bool spawning = true;
		[Header( "Spawning" )]
		public float spawnTimeMin = 5.0f;
		public float spawnTimeMax = 10.0f;
		public int startingAsteroids = 2;

		
		[Header( "Score" )]
		public Text scoreText;
		int score = 0;
		public int asteroidPoints = 50;
		public int debrisPoints = 10;

		
		[Header( "Game Over" )]
		public Image gameOverScreen;
		public Text gameOverText;

	
		void Awake ()
		{
			
			if( instance != null )
			{
				
				if( instance.gameObject.activeInHierarchy == true )
				{
					
					Debug.LogWarning( "There are multiple instances of the Game Manager script. Removing the old manager from the scene." );
					Destroy( instance.gameObject );
				}
				
				
				instance = null;
			}

			
			instance = GetComponent<GameManager>();
		}

		void Start ()
		{
			
			StartCoroutine( "SpawnTimer" );

			
			UpdateScoreText();
		}
	
		IEnumerator SpawnTimer ()
		{
			
			yield return new WaitForSeconds( 0.5f );

			
			for( int i = 0; i < startingAsteroids; i++ )
				SpawnAsteroid();

			
			while( spawning )
			{
				
				yield return new WaitForSeconds( Random.Range( spawnTimeMin, spawnTimeMax ) );

				
				SpawnAsteroid();
			}
		}

		void SpawnAsteroid ()
		{
			
			Vector2 dir = Random.insideUnitCircle;

			
			Vector3 pos = Vector3.zero;

			
			if( Mathf.Abs( dir.x ) > Mathf.Abs( dir.y ) )
				pos = new Vector3( Mathf.Sign( dir.x ) * Camera.main.orthographicSize * Camera.main.aspect * 1.3f, 0, dir.y * Camera.main.orthographicSize );
			
			else
				pos = new Vector3( dir.x * Camera.main.orthographicSize * Camera.main.aspect * 1.3f, 0, Mathf.Sign( dir.y ) * Camera.main.orthographicSize );

			
			GameObject ast = Instantiate( astroidPrefab, pos, Quaternion.Euler( Random.value * 360.0f, Random.value * 360.0f, Random.value * 360.0f ) ) as GameObject;

			
			ast.GetComponent<AsteroidController>().Setup( -pos.normalized * 1000.0f, Random.insideUnitSphere * Random.Range( 500.0f, 1500.0f ) );

			
			ast.GetComponent<AsteroidController>().asteroidManager = instance;
		}

		public void SpawnDebris( Vector3 pos )
		{
			
			int numberToSpawn = Random.Range( 3, 6 );

			
			for( int i = 0; i < numberToSpawn; i++ )
			{
				
				Vector3 force = Quaternion.Euler( 0, i * 360f / numberToSpawn, 0 ) * Vector3.forward * 5.0f * 300f;

				
				GameObject newGO = Instantiate( debrisPrefab, pos + force.normalized * Random.Range( 0.0f, 5.0f ), Quaternion.Euler( 0, Random.value * 180f, 0 ) ) as GameObject;

				
				newGO.transform.localScale = new Vector3( Random.Range( 0.25f, 0.5f ), Random.Range( 0.25f, 0.5f ), Random.Range( 0.25f, 0.5f ) );

				
				newGO.GetComponent<AsteroidController>().Setup( force / 2, Random.insideUnitSphere * Random.Range( 500f, 1500f ) );

				
				newGO.GetComponent<AsteroidController>().asteroidManager = instance;
			}
		}

		public void SpawnExplosion ( Vector3 pos )
		{
			
			GameObject newParticles = Instantiate( explosionPrefab, pos, Quaternion.identity ) as GameObject;

			
			Destroy( newParticles, 1 );
		}

		public void ShowDeathScreen ()
		{
			
			gameOverScreen.gameObject.SetActive( true );

			GameObject expl = ( GameObject )Instantiate( playerExplosionPrefab, FindObjectOfType<PlayerController>().transform.position, Quaternion.identity );

			Destroy( expl, 2 );

			
			StartCoroutine( "ShakeCamera" );

			
			StartCoroutine( "FadeDeathScreen" );

			
			spawning = false;

			UltimateJoystick.GetUltimateJoystick( "Movement" ).UpdatePositioning();
		}

		IEnumerator FadeDeathScreen ()
		{
			
			yield return new WaitForSeconds( 0.5f );

			
			scoreText.text = "Final Score\n" + score.ToString();

			
			Color imageColor = gameOverScreen.color;
			Color textColor = gameOverText.color;

			for( float t = 0.0f; t < 1.0f; t += Time.deltaTime * 3f )
			{
				
				imageColor.a = Mathf.Lerp( 0.0f, 0.75f, t );
				textColor.a = Mathf.Lerp( 0.0f, 1.0f, t );

				
				gameOverScreen.color = imageColor;
				gameOverText.color = textColor;

				
				scoreText.fontSize = ( int )Mathf.Lerp( 50, 100, t );

				
				yield return null;
			}

			
			imageColor.a = 0.75f;
			textColor.a = 1.0f;

			
			gameOverScreen.color = imageColor;
			gameOverText.color = textColor;
		}
		
		public void ModifyScore ( bool isDebris )
		{
			
			score += isDebris == true ? debrisPoints : asteroidPoints;

			
			UpdateScoreText();
		}

		void UpdateScoreText ()
		{
			
			scoreText.text = score.ToString();
		}

		IEnumerator ShakeCamera ()
		{
			
			Vector2 origPos = Camera.main.transform.position;
			for( float t = 0.0f; t < 1.0f; t += Time.deltaTime * 2.0f )
			{
				
				Vector2 tempVec = origPos + Random.insideUnitCircle;

				
				Camera.main.transform.position = tempVec;

				
				yield return null;
			}

			
			Camera.main.transform.position = origPos;
		}
	}
}