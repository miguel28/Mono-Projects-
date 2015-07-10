using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using MXNA;
using USBInterface;

namespace MonoGameTest1
{
	public enum RFEnconding
	{
		STOP,
		FORWARD,
		BACKWARD,
		LEFT,
		RIGHT,
		UP_GRIPPER,///////
		DOWN_GRIPPER,
		OPEN_GRIPPER,
		CLOSE_GRIPPER,
		CAM1_UP,     
		CAM1_DOWN,
		CAM1_LEFT,
		CAM1_RIGHT,
		CAM2_UP,
		CAM2_DOWN,
		CAM2_LEFT,
		CAM2_RIGHT,
		LASERS_OFF,
		LASERS_ON,
		SERVO_POS1,    
		SERVO_POS2,
		SERVO_POS3,
		SERVO_POS4,
		RESET_ENCODER1,
		RESET_ENCODER2,
		SET_SPEED1,
		SET_SPEED2,
		SET_SPEED3,
		SET_SPEED4,
		UPDATE,
		FORWARD_UP_GRIPPER,/////////
		FORWARD_DOWN_GRIPPER,
		FORWARD_OPEN_GRIPPER,    
		FORWARD_CLOSE_GRIPPER,
		FORWARD_CAM1_UP,
		FORWARD_CAM1_DOWN,
		FORWARD_CAM1_LEFT,    
		FORWARD_CAM1_RIGHT,
		FORWARD_CAM2_UP,
		FORWARD_CAM2_DOWN,
		FORWARD_CAM2_LEFT,
		FORWARD_CAM2_RIGHT,
		FORWARD_LASERS_OFF,
		FORWARD_LASERS_ON,
		FORWARD_SERVO_POS1,
		FORWARD_SERVO_POS2,
		FORWARD_SERVO_POS3, 
		FORWARD_SERVO_POS4,
		FORWARD_RESET_ENCODER1,
		FORWARD_RESET_ENCODER2,
		FORWARD_SET_SPEED1,
		FORWARD_SET_SPEED2,
		FORWARD_SET_SPEED3,
		FORWARD_SET_SPEED4,
		FORWARD_UPDATE,
		BACKWARD_UP_GRIPPER,/////////////
		BACKWARD_DOWN_GRIPPER,
		BACKWARD_OPEN_GRIPPER,
		BACKWARD_CLOSE_GRIPPER,
		BACKWARD_CAM1_UP,
		BACKWARD_CAM1_DOWN,
		BACKWARD_CAM1_LEFT,
		BACKWARD_CAM1_RIGHT,
		BACKWARD_CAM2_UP,    
		BACKWARD_CAM2_DOWN,
		BACKWARD_CAM2_LEFT,
		BACKWARD_CAM2_RIGHT,
		BACKWARD_LASERS_OFF,
		BACKWARD_LASERS_ON,
		BACKWARD_SERVO_POS1,
		BACKWARD_SERVO_POS2,
		BACKWARD_SERVO_POS3,
		BACKWARD_SERVO_POS4,
		BACKWARD_RESET_ENCODER1,
		BACKWARD_RESET_ENCODER2,
		BACKWARD_SET_SPEED1,
		BACKWARD_SET_SPEED2,
		BACKWARD_SET_SPEED3,
		BACKWARD_SET_SPEED4,
		BACKWARD_UPDATE,
		LEFT_UP_GRIPPER, /////////    
		LEFT_DOWN_GRIPPER,
		LEFT_OPEN_GRIPPER,
		LEFT_CLOSE_GRIPPER,
		LEFT_CAM1_UP,     
		LEFT_CAM1_DOWN,
		LEFT_CAM1_LEFT,
		LEFT_CAM1_RIGHT,
		LEFT_CAM2_UP,
		LEFT_CAM2_DOWN,
		LEFT_CAM2_LEFT,    
		LEFT_CAM2_RIGHT,
		LEFT_LASERS_OFF,
		LEFT_LASERS_ON,
		LEFT_SERVO_POS1,
		LEFT_SERVO_POS2,
		LEFT_SERVO_POS3,
		LEFT_SERVO_POS4,
		LEFT_RESET_ENCODER1,
		LEFT_RESET_ENCODER2,
		LEFT_SET_SPEED1,
		LEFT_SET_SPEED2,
		LEFT_SET_SPEED3,
		LEFT_SET_SPEED4,
		LEFT_UPDATE,
		RIGHT_UP_GRIPPER, ///////////
		RIGHT_DOWN_GRIPPER,
		RIGHT_OPEN_GRIPPER, 
		RIGHT_CLOSE_GRIPPER,
		RIGHT_CAM1_UP,    
		RIGHT_CAM1_DOWN,
		RIGHT_CAM1_LEFT,
		RIGHT_CAM1_RIGHT,
		RIGHT_CAM2_UP,
		RIGHT_CAM2_DOWN,
		RIGHT_CAM2_LEFT,
		RIGHT_CAM2_RIGHT,
		RIGHT_LASERS_OFF,    
		RIGHT_LASERS_ON,
		RIGHT_SERVO_POS1,
		RIGHT_SERVO_POS2,
		RIGHT_SERVO_POS3,
		RIGHT_SERVO_POS4,
		RIGHT_RESET_ENCODER1,
		RIGHT_RESET_ENCODER2,
		RIGHT_SET_SPEED1,
		RIGHT_SET_SPEED2,
		RIGHT_SET_SPEED3,
		RIGHT_SET_SPEED4,
		RIGHT_UPDATE      
	};

	public class WatchdogClass : MK_3dObject
	{

		public static string AssetPath = "Watchdog/watchdog2";
		public float Angle = 0.0f;

		private float Sensibility = 1.0f;
		private USBClass USB = new USBClass ();
		private float[] ControllerAxis = new float[8]; 

		#region Controls
		//short cViewX = 1;
		//short cViewY = 0;
		short cMove = 3;
		short cRotate = 2;
		#endregion


		public WatchdogClass ()
		{
			base.Scale = 0.5f;

			USB.HIDOpen (0x3995, 0x0001);
			USB.HIDDescription ();


		}

		private void OutputControl(RFEnconding Code)
		{
			USB.SendOutputPort ((byte)Code);
		}

		public void Controls(MK_Joystick Joy)
		{
			////Forward
			ControllerAxis [cMove] = Joy.GetAxis (cMove);
			 
			 

			if (ControllerAxis [cMove]<=-0.2f) 
			{
				if(ControllerAxis [cMove]<=-0.2f && ControllerAxis [cMove]>-0.4f)
					OutputControl(RFEnconding.FORWARD_SET_SPEED1);
				if(ControllerAxis [cMove]<=-0.4f && ControllerAxis [cMove]>-0.6f)
					OutputControl(RFEnconding.FORWARD_SET_SPEED2);
				if(ControllerAxis [cMove]<=-0.6f && ControllerAxis [cMove]>-0.8f)
					OutputControl(RFEnconding.FORWARD_SET_SPEED3);
				if(ControllerAxis [cMove]<=-0.8f && ControllerAxis [cMove]>-1.0f)
					OutputControl(RFEnconding.FORWARD_SET_SPEED4);

				AddToPosition(new Vector3(0,0,ControllerAxis [cMove]*0.1f));
			}

			else if (ControllerAxis [cMove]>=0.2f) 
			{
				if(ControllerAxis [cMove]>=0.2f && ControllerAxis [cMove]<0.4f)
					OutputControl(RFEnconding.BACKWARD_SET_SPEED1);
				if(ControllerAxis [cMove]>=0.4f && ControllerAxis [cMove]<0.6f)
					OutputControl(RFEnconding.BACKWARD_SET_SPEED2);
				if(ControllerAxis [cMove]>=0.6f && ControllerAxis [cMove]<0.8f)
					OutputControl(RFEnconding.BACKWARD_SET_SPEED3);
				if(ControllerAxis [cMove]>=0.8f && ControllerAxis [cMove]<1.0f)
					OutputControl(RFEnconding.BACKWARD_SET_SPEED4);

				AddToPosition(new Vector3(0,0,ControllerAxis [cMove]*0.1f));
			}
			else OutputControl(RFEnconding.STOP);

			if(Joy.ButtonHeld(1)) OutputControl(RFEnconding.SERVO_POS1);
			if(Joy.ButtonHeld(2)) OutputControl(RFEnconding.SERVO_POS2);
			if(Joy.ButtonHeld(3)) OutputControl(RFEnconding.SERVO_POS3);
			if(Joy.ButtonHeld(4)) OutputControl(RFEnconding.SERVO_POS4);
			/*if(Joy.ButtonHeld(1))Position.Y +=0.3f;
			if(Joy.ButtonHeld(3))Position.Y -=0.3f;
			try
			{
				if(Math.Abs(Joy.GetAxis(cMove))>0.4)
					AddToPosition(new Vector3(0,0,Joy.GetAxis(cMove)*0.1f));
				if(Math.Abs(Joy.GetAxis(cRotate))>0.4)
				{
					Angle -= Joy.GetAxis(cRotate);
					AddToPosition(Vector3.Zero);
				}
			}
			catch {
			}*/
		}
		public void Render(MK_FpsCamera Camera)
		{
			float Distance = 1.5f;
			Camera.Position.X = (float)(this.Position.X+(Distance*Math.Sin(MathHelper.ToRadians(Angle))));
			Camera.Position.Z = (float)(this.Position.Z+(Distance*Math.Cos(MathHelper.ToRadians(Angle))));
			Camera.Position.Y = this.Position.Y + 1f;
			//Camera.Position = this.Position;
			//Camera.Position.Z -= 3f;
			//Camera.Position.X -= 3f;
			//Camera.Position.Y = 1f;
			Camera.Look.X = Angle;
			Camera.Look.Y = -15.0f;
			Camera.Update ();
			DrawModel(Camera);
		}
		private void AddToPosition(Vector3 vectorToAdd)
		{
			this.Rotation.Y = Angle;
			Matrix cameraRotation = Matrix.CreateRotationY(MathHelper.ToRadians(Angle));
			Vector3 rotatedVector = Vector3.Transform(vectorToAdd, cameraRotation);
			Position += Sensibility * rotatedVector;
		}
	}
}

