using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#region Using Statements
using System.Runtime.InteropServices;

using SDL2;
#endregion
namespace usercontrol
{
    public partial class UserControl1: UserControl
    {
        #region Private SDL2 Window/Control Variables

        // These are the variables you care about.
        private Panel gamePanel;
        private IntPtr gameWindow; // For FNA, this is Game.Window.Handle

        #endregion
        #region Private Variables

        // IGNORE MEEEEE
        private Random random;
        private IntPtr renderer;

        #endregion
        #region WinAPI Entry Points

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowPos(
            IntPtr handle,
            IntPtr handleAfter,
            int x,
            int y,
            int cx,
            int cy,
            uint flags
        );
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr child, IntPtr newParent);
        [DllImport("user32.dll")]
        private static extern IntPtr ShowWindow(IntPtr handle, int command);

        #endregion

        public UserControl1()
        {
            //InitializeComponent();
            // This is what we're going to attach the SDL2 window to
            gamePanel = new Panel();
            gamePanel.Size = new Size(640, 480);
            gamePanel.Location = new Point(0, 0);
            gamePanel.BackColor = Color.Pink;
            gamePanel.Visible = true;
           
            // Make the WinForms window
            Size = new Size(800, 600);
            this.Controls.Add(gamePanel);
            //FormClosing += new FormClosingEventHandler(WindowClosing);
            Button button = new Button();
            button.Text = "Whatever";
            
            button.Location = new Point(0,0);
            button.Visible = true;
            button.Click += new EventHandler(ClickedButton);
            this.gamePanel.Controls.Add(button);
            this.ResumeLayout();

           
            //// IGNORE MEEEEE
            random = new Random();
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
            gameWindow=SDL.SDL_CreateWindowFrom(this.gamePanel.Handle);

            renderer = SDL.SDL_CreateRenderer(gameWindow, -1, 0);
            // Set renderer drawing color.
            SDL.SDL_SetRenderDrawColor(renderer, 255, 255, 255, 255);

            SDL.SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255);

            // Clear the screen.
            SDL.SDL_RenderClear(renderer);

            // Present the "Painting" (backbuffer) to the screen. Call this once per frame.
            SDL.SDL_RenderPresent(renderer);

        }
        #region Button Event Method

        private void ClickedButton(object sender, EventArgs e)
        {
            byte r =(byte) random.Next(0, 255);
            byte g = (byte)random.Next(0, 255);
            byte b = (byte)random.Next(0, 255);

            SDL.SDL_SetRenderDrawColor(renderer, r, g, b, 255);

            // Clear the screen.
            SDL.SDL_RenderClear(renderer);

            // Present the "Painting" (backbuffer) to the screen. Call this once per frame.
            SDL.SDL_RenderPresent(renderer);
        }

        #endregion

        #region Window Close Method

        public void WindowClosing(object sender, FormClosingEventArgs e)
        {
            SDL.SDL_DestroyWindow(gameWindow);
            gameWindow = IntPtr.Zero;
            SDL.SDL_Quit();
        }

        #endregion
    }
}
