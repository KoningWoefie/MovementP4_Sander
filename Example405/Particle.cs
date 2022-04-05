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
		Vector2 MaxSpeed = new Vector2(800, 800);
		Random rand = new Random();
		ParticleSystem system;

		// constructor + call base constructor
		public Particle(float x, float y, Color color) : base("resources/spaceship.png")
		{
			float randX = (float)rand.Next(-250, 250);
			float randY = (float)rand.Next(-250, 250);
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
			WrapEdges();
		}

		// your own private methods
		private void Move(float deltaTime)
		{
			// TODO implement
			if(Velocity != MaxSpeed)
			{
				Velocity += Acceleration * deltaTime;
			}
			Position += Velocity * deltaTime;
		}

		private void WrapEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			// TODO implement...
			if (Position.X > scr_width)
			{
				//Position.X = 0 but not lining up with leftside of screen
				Position.X = 0;
			}
			else if (Position.X < 0)
			{
				Position.X = scr_width;
			}
			if(Position.Y > scr_height)
			{
				//Position.Y = 0 but not lining up with top of screen
				Position.Y = 0;
			}
			else if(Position.Y < 0)
			{
				//Position.Y = scr_height but can't tell if it works
				Position.Y = scr_height;
			}
		}

	}
}
