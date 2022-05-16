using System; // Console
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
	class Follower : SpriteNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		private Vector2 Velocity;
		private Vector2 Acceleration;
		private float MaxSpeed = 200f;

		// constructor + call base constructor
		public Follower() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 2);
			Color = Color.GREEN;
			//Velocity = new Vector2(200, 200);
			//Acceleration = new Vector2(50, 50);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Follow(deltaTime);
			BounceEdges();
			Velocity += Acceleration * deltaTime;
			Console.WriteLine(Velocity);
		}

		// your own private methods
		private void Follow(float deltaTime)
		{
			Vector2 mouse = Raylib.GetMousePosition();
			
			Vector2 direction = mouse - Position;

			float distance = Vector2.Distance(mouse, Position);

			if(Position != mouse)
			{
				Vector2.Normalize(direction);

				Acceleration = direction;
				
				if(Velocity.X > MaxSpeed || Velocity.X < MaxSpeed)
				{
					Velocity.X += Acceleration.X * deltaTime;
				}
				else if(Velocity.X > -MaxSpeed && Velocity.X < -MaxSpeed)
				{
					Velocity.X -= Acceleration.X * deltaTime;
				}
				if(Velocity.Y < MaxSpeed || Velocity.Y > MaxSpeed)
				{
					Velocity.Y += Acceleration.Y * deltaTime;
				}
				else if(Velocity.Y > -MaxSpeed && Velocity.Y < -MaxSpeed)
				{
					Velocity.Y -= Acceleration.Y * deltaTime;
				}
				Position += Velocity * deltaTime;
				Console.WriteLine(Position);
				Acceleration *= 0;
			}
		}

		private void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;
		}

	}
}
