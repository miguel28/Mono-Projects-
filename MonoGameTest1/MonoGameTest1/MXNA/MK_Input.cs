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
	public static class MK_Keys
	{
		private static KeyboardState OldState;
		private static KeyboardState CurrentState;

		public static bool Held(Keys key)
		{
			return CurrentState.IsKeyDown (key);
		}
		public static bool Newpress(Keys key)
		{
			return (!OldState.IsKeyDown(key) && CurrentState.IsKeyDown(key));
		}
		public static void Update()
		{
			OldState = CurrentState;
			CurrentState = Keyboard.GetState ();
		}
	}

	public class MK_Joystick
	{
	
		#region Native Metods
		[DllImport ("SDL.dll")]
		public extern static int SDL_Init (int Flags);

		[DllImport ("SDL.dll")]
		public extern static int SDL_NumJoysticks();

		[DllImport ("SDL.dll")]
		public extern static void SDL_JoystickEventState(int Enable);

		[DllImport ("SDL.dll")]
		public extern static IntPtr SDL_JoystickOpen(int numJoystick);

		[DllImport ("SDL.dll")]
		public extern static void SDL_JoystickUpdate();

		[DllImport ("SDL.dll")]
		public extern static byte SDL_JoystickGetButton (IntPtr joystick, int button);

		[DllImport ("SDL.dll")]
		public extern static short SDL_JoystickGetAxis(IntPtr joystick, int Axis);

		[DllImport("SDL.dll", CharSet = CharSet.Ansi)]
		public extern static string SDL_GetError();

		[DllImport ("SDL.dll")]
		public extern static int SDL_JoystickNumButtons (IntPtr joystick);

		[DllImport("SDL.dll", CharSet = CharSet.Ansi)]
		public extern static string  SDL_JoystickName (int joystick);

		#endregion

		protected bool Initialized; 
		protected int NumButtons;
		private IntPtr JoyHandle = IntPtr.Zero;
		private UInt16[] mButtonHeld;
		private UInt16[] mButtonNewpress;
		private UInt16[] bButtonNewpress;

		public MK_Joystick()
		{
			if (SDL_Init (0x00000200) < 0) {
				Console.WriteLine ("Couldn't initializa SDL: " + SDL_GetError ());
				Initialized = false;
			} 
			else 
			{
				Console.WriteLine (SDL_NumJoysticks ().ToString () + " joysticks were found.");
				/*int i;
				for( i=0; i < SDL_NumJoysticks(); i++ ) 
				{
					Console.WriteLine ( "  " + i.ToString() + ".-" +  SDL_JoystickName(i));
				}*/
				Initialized = true;
			}

		}

		public void InitJoystick(int numJoystick, int MaxButtons)
		{
			if (!Initialized)
				return;
			NumButtons = MaxButtons;
			mButtonHeld = new UInt16[NumButtons];
			mButtonNewpress = new UInt16[NumButtons];
			bButtonNewpress = new UInt16[NumButtons];

			SDL_JoystickEventState(1);
			JoyHandle = SDL_JoystickOpen(numJoystick);

			if (JoyHandle != IntPtr.Zero) 
			{
				Console.WriteLine("Joystick Opened");
				Console.WriteLine("Num of Buttons " + SDL_JoystickNumButtons(JoyHandle).ToString());
			}
			else Console.WriteLine("Joystick NOT Opened");
			Update ();
		}
		public void Update()
		{
			JoystickEvent();
			int i;
			for(i=0; i<NumButtons; i++)
			{
				//cout <<"Button" << i << ":: "<< mButtonHeld[i] <<endl;
				if(mButtonHeld[i]==1)
				{
					//cout<< "Held "  << i <<endl;
					if(bButtonNewpress[i]==1){
						mButtonNewpress[i] = 0;
						bButtonNewpress[i] = 1;
						//cout<< "NewpressReyected "  << i <<endl;
						//cout << "Button State : " <<  mButtonNewpress[i] << endl;
					}
					else 
					{
						mButtonNewpress[i] = 1;
						bButtonNewpress[i] = 1;
						//cout<< "NewpressDetected "  << i <<endl;
						//cout << "Button State : " <<  mButtonNewpress[i] << endl;
					}
				}
				else
				{
					bButtonNewpress[i] = 0;
					mButtonNewpress[i] = 0;
				}
			}
		}
		private void JoystickEvent()
		{
			SDL_JoystickUpdate();

			int i;
			for (i=0; i<NumButtons; i++) 
			{
				mButtonHeld[i]=SDL_JoystickGetButton(JoyHandle,i);
				//Console.WriteLine ("Button " + i.ToString () + "::" + mButtonHeld [i].ToString ());
				//cout <<"Button" << i << ":: "<< button[i] <<endl;
			}
			//if(SDL_JoystickGetButton(joystick[numJoystick],0)==1)cout <<"Button 1 Presssed"<< endl;
			//cout << "State: " << (int) SDL_JoystickGetHat(joystick[numJoystick], 0)<<endl;
		}
		public float GetAxis(short Axis)
		{
			float Value = (float)((float)SDL_JoystickGetAxis(JoyHandle, Axis)/32768.0f);

			try
			{
				if (Math.Abs (Value) > 0.1)
					return Value;
				else
					return 0.0f;
			}
			catch 
			{
				return 0.0f;
			}
		}

		public bool ButtonHeld(short button)
		{
			if(button > NumButtons || button == 0)return false;
			else 
			{
				if (mButtonHeld [button - 1] == 1)
					return true;
				else
					return false;
			}
		}
		public bool ButtonNewpress(short button)
		{
			if (button > NumButtons || button == 0)
				return false;
			else 
			{
				if (mButtonNewpress [button - 1] == 1)
					return true;
				else
					return false;
			}
		}

	}
}

