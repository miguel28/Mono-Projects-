using System;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace MXNA
{
	public class QuadDrawer : DrawableGameComponent
	{
		private string _textureName;
		private Texture2D _texture;
		private BasicEffect _effect;

		public Vector3 Origin;
		public Vector3 UpperLeft;
		public Vector3 LowerLeft;
		public Vector3 UpperRight;
		public Vector3 LowerRight;
		public Vector3 Normal;
		public Vector3 Up;
		public Vector3 Left;

		private float _size = 100;

		private VertexPositionNormalTexture[] _vertices;
		private int[] _indices;

		public QuadDrawer(Game game, float size, string textureName, Vector3 origin, Vector3 normal, Vector3 up)
			: base(game)
		{
			Origin = origin;
			Normal = normal;
			Up = up;

			// Calculate the quad corners
			Left = Vector3.Cross( -normal, Up );
			Vector3 uppercenter = (Up * 1 / 2) + origin;
			UpperLeft = uppercenter + (Left * 1 / 2);
			UpperRight = uppercenter - (Left * 1 / 2);
			LowerLeft = UpperLeft - (Up * 1);
			LowerRight = UpperRight - (Up * 1);
			this._size = size;
			this._textureName = textureName;
		}

		public override void Initialize()
		{
			BuildVertices();
			base.Initialize();
		}

		private void BuildVertices()
		{
			_vertices = new VertexPositionNormalTexture[4];
			_indices = new int[6];

			_vertices[0].Position = UpperLeft;
			_vertices[0].TextureCoordinate = new Vector2(0.0f, 1.0f);
			_vertices[1].Position = UpperRight;
			_vertices[1].TextureCoordinate = new Vector2(0.0f, 0.0f);
			_vertices[2].Position = LowerLeft;
			_vertices[2].TextureCoordinate = new Vector2(1.0f, 1.0f);
			_vertices[3].Position = LowerRight;
			_vertices[3].TextureCoordinate = new Vector2(1.0f, 0.0f);

			for (int i = 0; i < _vertices.Length; i++)
			{
				_vertices[i].Normal = Normal;
				_vertices[i].Position *= _size;
				_vertices[i].TextureCoordinate *= _size;
			}

			_indices[5] = 0; _indices[4] = 1; _indices[3] = 2;
			_indices[2] = 2; _indices[1] = 1; _indices[0] = 3;
		}

		protected override void LoadContent()
		{
			_texture = this.Game.Content.Load<Texture2D>(_textureName);
			_effect = new BasicEffect(this.GraphicsDevice);
			_effect.EnableDefaultLighting();
			_effect.PreferPerPixelLighting = true;
			_effect.SpecularColor = new Vector3(0.1f, 0.1f, 0.1f);

			_effect.World = Matrix.Identity;
			_effect.TextureEnabled = true;
			_effect.Texture = _texture;

			base.LoadContent();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		public void Update(MK_3dCamera camera)
		{
			_effect.View = camera.View;
			_effect.Projection = camera.Projection;
		}

		public override void Draw(GameTime gameTime)
		{
			GraphicsDevice.SamplerStates[0] = SamplerState.AnisotropicWrap;
			GraphicsDevice.DepthStencilState = DepthStencilState.Default;
			foreach (EffectPass pass in _effect.CurrentTechnique.Passes)
			{
				pass.Apply();
				GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionNormalTexture>(PrimitiveType.TriangleList, _vertices, 0, 4, _indices, 0, 2);
			}
			base.Draw(gameTime);
		}
		/*public override void Draw(GameTime gameTime)
		{
			SamplerState ss = GraphicsDevice.SamplerStates[0];
			TextureFilter filter = new TextureFilter ();
			ss.AddressU = TextureAddressMode.Wrap;
			ss.AddressV = TextureAddressMode.Wrap;
			ss.
			GraphicsDevice.SamplerStates[0] = ss;

			GraphicsDevice.DepthStencilState = DepthStencilState.Default;

			foreach (EffectPass pass in _effect.CurrentTechnique.Passes)
			{
				pass.Apply();
				GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionNormalTexture>(PrimitiveType.TriangleList, _vertices, 0, 4, _indices, 0, 2);
			}
			base.Draw(gameTime);
		}*/
	}
}

