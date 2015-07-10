#region File Description
//-----------------------------------------------------------------------------
// MonoGameTest1Game.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using MXNA;

#endregion

namespace MonoGameTest1
{
	public class Game1 : Game
	{

	#region Fields
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		FontRenderer Font;

		MK_Joystick Joy = new MK_Joystick ();
		MK_FpsCamera Camera = new MK_FpsCamera(1200f,800f,0.1f,1000f); 
		WatchdogClass WatchDog = new WatchdogClass();
		QuadDrawer Floor;
		MK_Skybox Sky = new MK_Skybox();
		MK_3dObject Flag = new MK_3dObject();
	#endregion

	#region Initialization

        public Game1()  
        {
			graphics = new GraphicsDeviceManager(this);

			Content.RootDirectory = "Content";
			graphics.IsFullScreen = false;
			graphics.PreferredBackBufferWidth = 1200;
			graphics.PreferredBackBufferHeight = 800;

			graphics.CreateDevice ();
			DepthStencilState d = new DepthStencilState();
			d.DepthBufferEnable = true;
			GraphicsDevice.DepthStencilState = d;

			Camera.Position.Z = 10;
			Camera.Position.Y = 1;
			Joy.InitJoystick (0, 12);
		}

		protected override void Initialize()
		{
			base.Initialize();

			Floor = new QuadDrawer(this, 100.0f, "Crackless",Vector3.Zero, Vector3.Up, Vector3.Forward);
			this.Components.Add(Floor);
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
			Font = new FontRenderer(Content,"spriteFont.fnt","spriteFont_0");
			WatchDog.Load(Content,"Watchdog/watchdog2");
			Sky.Load(Content, "Models/SkyBox1/skybox", "Models/SkyBox2/Bluesky");
			Sky.Scale = 30.0f;
			Flag.Load (Content,"Models/Bandera");
			//Flag.Scale = 0.5f;
			Flag.Rotation.X = 270;
			Flag.Position.Y = 6;
		}

	#endregion

	#region Update and Draw

		protected override void Update(GameTime gameTime)
		{
			WatchDog.Controls(Joy);
			Floor.Update(Camera);
			Joy.Update();
			MK_Keys.Update();
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(ClearOptions.DepthBuffer | ClearOptions.Target, Color.CornflowerBlue, 50.0f, 0);
			graphics.GraphicsDevice.DepthStencilState=DepthStencilState.Default;
			RasterizerState rs = new RasterizerState();
			rs.CullMode = CullMode.None;
			graphics.GraphicsDevice.RasterizerState = rs;

			Sky.Draw(graphics.GraphicsDevice, Camera);
			WatchDog.Render (Camera);
			Flag.DrawModel (Camera);

			spriteBatch.Begin();
			Font.DrawText (spriteBatch, 0, 0, "X: " + WatchDog.Position.X.ToString() + " Z: " + WatchDog.Position.Z.ToString() + " Angle: " + WatchDog.Angle.ToString());
			spriteBatch.End();

			base.Draw(gameTime);
		}

	#endregion
	}
}
