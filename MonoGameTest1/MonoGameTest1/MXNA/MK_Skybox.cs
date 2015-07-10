using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace MXNA
{
	public class MK_Skybox
	{
		#region Private Fields
		//private static ;
		private Texture2D[] skyboxTextures = new Texture2D[6];
		private Model skyboxModel;
		#endregion

		#region Public Fields
		public float Scale = 1.0f;
		#endregion

		public MK_Skybox ()
		{

		}

		public void Load(ContentManager Content, string Asset, string Textures)
		{
			skyboxTextures[0] = Content.Load<Texture2D>(Textures + "_top");
			skyboxTextures[1] = Content.Load<Texture2D>(Textures + "_right");
			skyboxTextures[2] = Content.Load<Texture2D>(Textures + "_left");
			skyboxTextures[3] = Content.Load<Texture2D>(Textures + "_front");
			skyboxTextures[4] = Content.Load<Texture2D>(Textures + "_back");
			skyboxTextures[5] = Content.Load<Texture2D>(Textures + "_bottom");

			skyboxModel = Content.Load<Model> (Asset);            
			int i = 0;
			foreach (ModelMesh mesh in skyboxModel.Meshes)
				foreach (BasicEffect currentEffect in mesh.Effects)
					currentEffect.Texture = skyboxTextures[i++];

		}

		public void Draw(GraphicsDevice device, MK_3dCamera Camera)
		{
			SamplerState ss = new SamplerState();
			ss.AddressU = TextureAddressMode.Clamp;
			ss.AddressV = TextureAddressMode.Clamp;
			device.SamplerStates[0] = ss;

			DepthStencilState dss = new DepthStencilState();
			dss.DepthBufferEnable = false;
			device.DepthStencilState = dss;

			Matrix[] skyboxTransforms = new Matrix[skyboxModel.Bones.Count];
			skyboxModel.CopyAbsoluteBoneTransformsTo(skyboxTransforms);
			foreach (ModelMesh mesh in skyboxModel.Meshes)
			{
				foreach (BasicEffect effect in mesh.Effects)
				{
					effect.World = Matrix.Identity*Matrix.CreateScale(Scale)*Matrix.CreateTranslation(Camera.Position);
					effect.View = Camera.View;
					effect.Projection = Camera.Projection;
				}
				mesh.Draw();
			}

			dss = new DepthStencilState();
			dss.DepthBufferEnable = true;
			device.DepthStencilState = dss;
		}
	}
}

