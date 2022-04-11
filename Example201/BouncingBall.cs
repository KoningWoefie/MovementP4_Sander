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
	class BouncingBall : SpriteNode
	{
		// your private fields here (add Velocity, Acceleration, addForce method)
		private Vector2 Velocity;
		private Vector2 Acceleration;

		// constructor + call base constructor
		public BouncingBall() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 6, Settings.ScreenSize.Y / 4);
			Color = Color.BLUE;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Fall(deltaTime);
			BounceEdges();
		}

		// your own private methods
		private void Fall(float deltaTime)
		{
			Vector2 wind = new Vector2(3f, 0.0f);
			Vector2 gravity = new Vector2(0.0f, 100f);

			AddForce(wind);
			AddForce(gravity);

			Velocity += Acceleration * deltaTime;
			Acceleration *= 0.0f;
			Position += Velocity * deltaTime;
		}

		private void AddForce(Vector2 force)
		{
			Acceleration += force;
		}

		private void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;
			float half_width = spr_width / 2;
			float half_height = spr_heigth / 2;

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
