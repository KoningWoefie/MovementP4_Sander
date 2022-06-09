using System;
using System.Numerics;
using Raylib_cs;

namespace Movement
{
	class Example405 : SceneNode
	{
		// private fields
		private ParticleSystem particlesystem01;
		private ParticleSystem particlesystem02;

		private Vector2 mousePos;

		// constructor + call base constructor
		public Example405(String t) : base(t)
		{
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
			{
				mousePos = Raylib.GetMousePosition();
				Particles(deltaTime);
			}
		}

		private void Particles(float deltaTime)
		{
			particlesystem01 = new ParticleSystem(mousePos.X, mousePos.Y);
			AddChild(particlesystem01);
		}

	} // class

} // namespace
