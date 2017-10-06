using Impression;
using Impression.Graphics;
using Impression.Input;
using Impression.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Example05Song
{
    public class Example05SongGame : Impression.Game
    {
		GraphicsDeviceManager graphics;

		List<Song> songs;
		int currentSongIndex = 0;

		MouseState currentMouseState;
		MouseState lastMouseState;

        public Example05SongGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);

			switch (FrameworkContext.Platform)
			{
				case PlatformType.Windows:
				case PlatformType.Mac:
				case PlatformType.Linux:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						this.IsMouseVisible = true;
					}
					break;
                case PlatformType.WindowsStore:
                case PlatformType.WindowsMobile:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						graphics.IsFullScreen = true;

						// Frame rate is 30 fps by default for mobile device
						TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 30L);
					}
					break;
				case PlatformType.Android:
				case PlatformType.iOS:
					{
						graphics.PreferredBackBufferWidth = 1280;
						graphics.PreferredBackBufferHeight = 720;

						graphics.IsFullScreen = true;

						// Frame rate is 30 fps by default for mobile device
						TargetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 30L);
					}
					break;
			}

            this.View.Title = "Example05Song";
        }

        protected override void Initialize()
        { 
            base.Initialize();

            // do something
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            songs = new List<Song>();

			// Load all songs
			songs.Add(this.Content.Load<Song>("Audio/Srengenge"));
        }

        protected override void UnloadContent()
        {
            // do something

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
			switch (FrameworkContext.Platform)
			{
				case PlatformType.Windows:
				case PlatformType.Mac:
				case PlatformType.Linux:
					{
						if (Keyboard.GetState().IsKeyDown(Keys.Escape))
							this.Exit();
					}
					break;
				default:
					{
						// do nothings
					}
					break;
			}

			lastMouseState = currentMouseState;
			currentMouseState = Mouse.GetState();

			// Allows songs to sequenced when left button was just pressed
			if (lastMouseState.LeftButton == ButtonState.Released &&
				currentMouseState.LeftButton == ButtonState.Pressed)
			{
				if (Impression.Media.MediaPlayer.State == MediaState.Playing)
					Impression.Media.MediaPlayer.Stop();

				if (Impression.Media.MediaPlayer.State == MediaState.Stopped)
				{
					currentSongIndex++;

					// When current song index is out of range, reset index to zero
					if (!(currentSongIndex < songs.Count))
					{
						currentSongIndex = 0;
					}

					Impression.Media.MediaPlayer.Play(songs[currentSongIndex]);
				}
			}
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
			graphics.GraphicsDevice.Clear(Color.BurlyWood);

			// do something
            
            base.Draw(gameTime);
        }
    }
}