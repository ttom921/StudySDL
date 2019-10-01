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
        #region Private GL Variables
        //The surface contained by the window
        IntPtr screenSurface;

        // IGNORE MEEEEE
        private Random random;
        private IntPtr renderer;
        private delegate void Viewport(int x, int y, int width, int height);
        private delegate void ClearColor(float r, float g, float b, float a);
        private delegate void Clear(uint flags);
        private Viewport glViewport;
        private ClearColor glClearColor;
        private Clear glClear;

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
            gamePanel.Location = new Point(80, 10);
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
            //gameWindow = SDL.SDL_CreateWindow(
            //    String.Empty,
            //    0,
            //    0,
            //    gamePanel.Size.Width,
            //    gamePanel.Size.Height,
            //    SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS | SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL
            //);
            //Get window surface
            //screenSurface = SDL.SDL_GetWindowSurface(gameWindow);
            renderer = SDL.SDL_CreateRenderer(gameWindow, -1, 0);
            // Set renderer drawing color.
            SDL.SDL_SetRenderDrawColor(renderer, 255, 255, 255, 255);

            SDL.SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255);

            // Clear the screen.
            SDL.SDL_RenderClear(renderer);

            // Present the "Painting" (backbuffer) to the screen. Call this once per frame.
            SDL.SDL_RenderPresent(renderer);

            //glContext = SDL.SDL_GL_CreateContext(gameWindow);
            //glViewport = (Viewport)Marshal.GetDelegateForFunctionPointer(
            //    SDL.SDL_GL_GetProcAddress("glViewport"),
            //    typeof(Viewport)
            //);
            //glClearColor = (ClearColor)Marshal.GetDelegateForFunctionPointer(
            //    SDL.SDL_GL_GetProcAddress("glClearColor"),
            //    typeof(ClearColor)
            //);
            //glClear = (Clear)Marshal.GetDelegateForFunctionPointer(
            //    SDL.SDL_GL_GetProcAddress("glClear"),
            //    typeof(Clear)
            //);
            //glViewport(0, 0, gamePanel.Size.Width, gamePanel.Size.Height);
            //glClearColor(1.0f, 0.0f, 0.0f, 1.0f);
            //glClear(0x4000);
            //SDL.SDL_GL_SwapWindow(gameWindow);

            //// Get the Win32 HWND from the SDL2 window
            //SDL.SDL_SysWMinfo info = new SDL.SDL_SysWMinfo();
            //SDL.SDL_GetWindowWMInfo(gameWindow, ref info);
            //IntPtr winHandle = info.info.win.window;

            //// Move the SDL2 window to 0, 0
            //SetWindowPos(
            //    winHandle,
            //    Handle,
            //    0,
            //    0,
            //    0,
            //    0,
            //    0x0401 // NOSIZE | SHOWWINDOW
            //);

            //// Attach the SDL2 window to the panel
            //SetParent(winHandle, gamePanel.Handle);
            //ShowWindow(winHandle, 1); // SHOWNORMAL

        }
        #region Button Event Method

        private void ClickedButton(object sender, EventArgs e)
        {
            //glClearColor(
            //    (float)random.NextDouble(),
            //    (float)random.NextDouble(),
            //    (float)random.NextDouble(),
            //    1.0f
            //);
            //glClear(0x4000); // GL_COLOR_BUFFER_BIT
            //SDL.SDL_GL_SwapWindow(gameWindow);
            SDL.SDL_SetRenderDrawColor(renderer, 255, 0, 0, 128);

            // Clear the screen.
            SDL.SDL_RenderClear(renderer);

            // Present the "Painting" (backbuffer) to the screen. Call this once per frame.
            SDL.SDL_RenderPresent(renderer);
        }

        #endregion

        #region Window Close Method

        private void WindowClosing(object sender, FormClosingEventArgs e)
        {
            glClear = null;
            glClearColor = null;
            glViewport = null;
            //SDL.SDL_GL_DeleteContext(glContext);
            //glContext = IntPtr.Zero;
            SDL.SDL_DestroyWindow(gameWindow);
            gameWindow = IntPtr.Zero;
            SDL.SDL_Quit();
        }

        #endregion
    }
}
