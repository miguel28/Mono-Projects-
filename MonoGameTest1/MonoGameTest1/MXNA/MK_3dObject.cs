using System;
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
	public class MK_3dObject
	{
		public Model mModel;
		public Vector3 Position = new Vector3(0,0,0);
		public Vector3 Rotation = new Vector3(0,0,0);
		public float Scale = 1.0f;
		public Matrix World = Matrix.CreateTranslation(new Vector3(0, 0, 0));

		private static Matrix[] sharedDrawBoneMatrices;

		public MK_3dObject ()
		{
		}

		public void Load(ContentManager Content,string Path)
		{
			mModel = Content.Load<Model>(Path);

		}

		public void DrawModel(Matrix view, Matrix projection)
		{
			Update ();
			foreach (ModelMesh mesh in mModel.Meshes)
			{
				foreach (BasicEffect effect in mesh.Effects)
				{
					effect.World = World;
					effect.View = view;
					effect.Projection = projection;
				}
			
				mesh.Draw();
			}
		}
		public void DrawModel(MK_3dCamera camera)
		{
			Update ();
			int boneCount = mModel.Bones.Count;
			if (sharedDrawBoneMatrices == null ||
				sharedDrawBoneMatrices.Length < boneCount)
			{
				sharedDrawBoneMatrices = new Matrix[boneCount];    
			}
			
			// Look up combined bone matrices for the entire model.            
			mModel.CopyAbsoluteBoneTransformsTo(sharedDrawBoneMatrices);

			/*foreach (ModelMesh mesh in mModel.Meshes)
            {
                foreach (Effect effect in mesh.Effects)
                {
					IEffectMatrices effectMatricies = effect as IEffectMatrices;
					if (effectMatricies == null) {
						throw new InvalidOperationException();
					}
					effectMatricies.World = sharedDrawBoneMatrices[mesh.ParentBone.Index]* World;
					effectMatricies.View = camera.View;
					effectMatricies.Projection = camera.Projection;
                }

                mesh.Draw();
            }*/

			foreach (ModelMesh mesh in mModel.Meshes)
			{
				foreach (BasicEffect effect in mesh.Effects)
				{
					effect.TextureEnabled = true;
					effect.EnableDefaultLighting();
					effect.World = sharedDrawBoneMatrices[mesh.ParentBone.Index]*World;
					effect.View = camera.View;
					effect.Projection = camera.Projection;
				}
				mesh.Draw();
			}
		}

		private void Update()
		{
			World = Matrix.CreateScale(Scale) * Matrix.CreateRotationY(MathHelper.ToRadians(Rotation.Y)) * Matrix.CreateRotationX(MathHelper.ToRadians(Rotation.X)) * Matrix.CreateRotationZ(MathHelper.ToRadians(Rotation.Z)) * Matrix.CreateTranslation(Position);
		}
	}
}

