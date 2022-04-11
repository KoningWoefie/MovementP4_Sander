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
	class SimpleBall : SpriteNode
	{
		// your private fields here
		private int speedX = 1000;
		private int speedY = 1000;


		// constructor + call base constructor
		public SimpleBall() : base("resources/bigball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.YELLOW;
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
			Position.X += speedX * deltaTime;
			Position.Y += speedY * deltaTime;
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
			if (Position.X + half_width >= scr_width)
			{
				speedX *= -1;
			}
			else if (Position.X - half_width <= 0)
			{
				speedX *= -1;
			}
			if(Position.Y + half_height >= scr_height)
			{
				speedY *= -1;
			}
			else if(Position.Y - half_height <= 0)
			{
				speedY *= -1;
			}
		}

	}
}
