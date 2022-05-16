using System; // Console
using System.Numerics; // Vector2
using System.Collections.Generic; // List
using Raylib_cs; // Color

/*
In this class, we have the properties:

- Vector2  Position
- float    Rotation
- Vector2  Scale

- Vector2 TextureSize
- Vector2 Pivot
- Color Color

Methods:

- AddChild(Node child)
- RemoveChild(Node child, bool keepAlive = false)
*/

namespace Movement
{
	class Particle : SpriteNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		Vector2 Velocity;
		Vector2 Acceleration;
		Random rand = new Random();
		public bool isDead = false;
		private int lifeSpan = 200;
		private int timeAlive = 0;

		// constructor + call base constructor
		public Particle(float x, float y, Color color) : base("resources/spaceship.png")
		{
			float randX = (float)rand.Next(-150, 150);
			float randY = (float)rand.Next(0, 100);
			Position = new Vector2(x, y);
			Velocity = new Vector2(randX, randY);
			Acceleration = new Vector2(20, 30);
			Scale = new Vector2(0.25f, 0.25f);
			Color = color;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
		}

		// your own private methods
		private void Move(float deltaTime)
		{
			// TODO implement
			Velocity += Acceleration * deltaTime;
			Position += Velocity * deltaTime;
		}
	}
}
