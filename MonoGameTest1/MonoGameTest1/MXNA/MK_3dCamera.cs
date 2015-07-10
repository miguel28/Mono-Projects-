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
	public class MK_3dCamera
	{
		public Matrix View; 
		public Matrix Projection; 
		public Vector3 Position = new Vector3(0,0,1) ;
		public Vector3 Look = new Vector3(0,0,0);

		public MK_3dCamera (float Width, float Height, float NearClip, float FarClip )
		{
			Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Width / Height, NearClip, FarClip);
			Update ();
		}
		public void Update()
		{

			Matrix cameraRotation = Matrix.CreateRotationX(MathHelper.ToRadians(Look.Y)) * Matrix.CreateRotationY(MathHelper.ToRadians(Look.X));
			Vector3 cameraOriginalTarget = new Vector3(0, 0, -1);
			Vector3 cameraOriginalUpVector = new Vector3(0, 1, 0);
			Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
			Vector3 target = Position + cameraRotatedTarget;
			Vector3 up = Vector3.Transform(cameraOriginalUpVector, cameraRotation);
			View = Matrix.CreateLookAt(Position, target, up);


			//View = Matrix.CreateLookAt(Position, Look, Vector3.UnitY);
		}
		public void SetFixedCamera (Vector3 pos, Vector3 look)
		{
			Position = pos;
			Look = look;
		}
	}

	public class MK_FpsCamera : MK_3dCamera
	{
		public float Sensibility = 1.0f;

		public MK_FpsCamera(float Width, float Height, float NearClip, float FarClip ) : base (Width,Height,NearClip,FarClip)
		{

		}
		public void AddToCameraPosition(Vector3 vectorToAdd)
		{
			Matrix cameraRotation = /*Matrix.CreateRotationX(Look.Y) */ Matrix.CreateRotationY(Look.X);
			Vector3 rotatedVector = Vector3.Transform(vectorToAdd, cameraRotation);
			Position += Sensibility * rotatedVector;
			//Update ();
		}
		public void AddToCameraRotation(Vector2 vecRot)
		{
			Look.X += Sensibility * vecRot.X;
			Look.Y += Sensibility * vecRot.Y;
			//Update ();
		}
	}
}

