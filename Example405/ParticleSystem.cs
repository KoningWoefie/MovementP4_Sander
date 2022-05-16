using System; // Console
using System.Numerics; // Vector2
using System.Collections.Generic; // List
using Raylib_cs; // Color

namespace Movement
{
	class ParticleSystem : Node
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		List<Particle> particles;
		private List<Color> colors;
		private float PositionX;
		private float PositionY;
		public Vector2 ParticlePosition;
		public Particle p;

		// constructor + call base constructor
		public ParticleSystem(float x, float y) : base()
		{
			Position = new Vector2(x, y);
			PositionX = x;
			PositionY = y;
			ParticlePosition = new Vector2(PositionX, PositionY);

			colors = new List<Color>();
			colors.Add(Color.WHITE);
			colors.Add(Color.ORANGE);
			colors.Add(Color.RED);
			colors.Add(Color.BLUE);
			colors.Add(Color.GREEN);
			colors.Add(Color.BEIGE);
			colors.Add(Color.SKYBLUE);
			colors.Add(Color.YELLOW);

			particles = new List<Particle>();
			Random rand = new Random();
			while (particles.Count < 100)
			{
				float randX = (float)rand.Next(0, (int)Settings.ScreenSize.X);
				float randY = (float)rand.Next(0, (int)Settings.ScreenSize.Y);
				Vector2 pos = new Vector2(randX, randY);
				pos -= new Vector2(100, 100);
				p = new Particle(pos.X, pos.Y, colors[rand.Next()%colors.Count]);
				particles.Add(p);
				p.Rotation = (float)Math.Atan2(pos.Y, pos.X);
				AddChild(p);
			}
			
			if(!p.isDead)
			{
				Console.WriteLine("Particle is not dead");
			}
			if(p.isDead)
			{
				Console.WriteLine("Dead");
				p = null;
				particles.Remove(p);
				RemoveChild(p);
			}
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{

		}


	}
}
