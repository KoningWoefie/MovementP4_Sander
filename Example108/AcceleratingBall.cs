using System.Numerics; // Vector2
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
	class AcceleratingBall : SpriteNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		private Vector2 Velocity;
		private Vector2 Acceleration;
		private float MaxSpeed = 800f;

		// constructor + call base constructor
		public AcceleratingBall() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.RED;
			Acceleration = new Vector2(50, 45);
			Velocity = new Vector2(0, 0);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			BounceEdges();
		}

		// your own private methods
		private void Move(float deltaTime)
		{
			// TODO implement
			if(Velocity.X < MaxSpeed && Velocity.X > -MaxSpeed)
			{
				Velocity.X += Acceleration.X * deltaTime;
			}
			if(Velocity.Y < MaxSpeed && Velocity.Y > -MaxSpeed)
			{
				Velocity.Y += Acceleration.Y * deltaTime;
			}
			Position += Velocity * deltaTime;
		}

		private void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;
			float half_width = spr_width / 2;
			float half_height = spr_heigth / 2;

			// TODO implement...
			if (Position.X + half_width > scr_width)
			{
				Velocity.X = -Velocity.X;
				Acceleration.X = -Acceleration.X;
			}
			else if(Position.X - half_width < 0)
			{
				Velocity.X = -Velocity.X;
				Acceleration.X = -Acceleration.X;
			}
			if(Position.Y + half_height > scr_height)
			{
				Velocity.Y = -Velocity.Y;
				Acceleration.Y = -Acceleration.Y;
			}
			else if(Position.Y - half_height < 0)
			{
				Velocity.Y = -Velocity.Y;
				Acceleration.Y = -Acceleration.Y;
			}
		}

	}
}
