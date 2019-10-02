using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDL2;
using System.Threading;

namespace HSUCLib
{
    
    public partial class HSUCAX: UserControl
    {

        Thread showImageThread = null;
        bool isRunningShowImageThread = false;

        private IntPtr renderer;
        private IntPtr gameWindow; //this is Game.Window.Handle
        private Random random;
        private static object _thisLock = new object();

        public HSUCAX()
        {
            InitializeComponent();
            try
            {
                initsdl();
            }
            catch (Exception ex)
            {
            }
        }
        //初始化SDL
        private void initsdl()
        {
            random = new Random();
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
            gameWindow = SDL.SDL_CreateWindowFrom(this.Handle);
            renderer = SDL.SDL_CreateRenderer(gameWindow, -1, 0);
            // Set renderer drawing color.
            SDL.SDL_SetRenderDrawColor(renderer, 255, 255, 255, 255);

            SDL.SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255);

            // Clear the screen.
            SDL.SDL_RenderClear(renderer);

            // Present the "Painting" (backbuffer) to the screen. Call this once per frame.
            SDL.SDL_RenderPresent(renderer);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (showImageThread == null)
            {
                SDL.SDL_RenderClear(renderer);
                //// Present the "Painting" (backbuffer) to the screen. Call this once per frame.
                SDL.SDL_RenderPresent(renderer);

                isRunningShowImageThread = true;
                showImageThread = new Thread(ShowImageTask);
                showImageThread.Priority = ThreadPriority.AboveNormal;
                showImageThread.IsBackground = true;
                showImageThread.Start();
            }
        }
        void ShowImageTask()
        {
            while (isRunningShowImageThread)
            {
                
                byte r = (byte)random.Next(0, 255);
                byte g = (byte)random.Next(0, 255);
                byte b = (byte)random.Next(0, 255);
                try
                {
                    lock (_thisLock)
                    {
                       
                        SDL.SDL_SetRenderDrawColor(renderer, r, g, b, 255);

                        //// Clear the screen.
                        SDL.SDL_RenderClear(renderer);
                        ////// Present the "Painting" (backbuffer) to the screen. Call this once per frame.
                        SDL.SDL_RenderPresent(renderer);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                finally
                {

                    Thread.Yield();
                }
                Thread.Sleep(30);
               
            }
            isRunningShowImageThread = true;
            if (showImageThread != null && showImageThread.IsAlive)
            {
                try
                {
                    showImageThread.Abort();
                }
                catch (System.Threading.ThreadAbortException)
                {
                    showImageThread = null;
                }
                showImageThread = null;
            }
        }

        #region Window Close Method

        public void WindowClosing(object sender, FormClosingEventArgs e)
        {
            if (showImageThread != null && showImageThread.IsAlive)
            {
                showImageThread.Abort();
                showImageThread.Join();
                showImageThread = null;
            }
            SDL.SDL_DestroyWindow(gameWindow);
            gameWindow = IntPtr.Zero;
            SDL.SDL_Quit();
        }

        #endregion


    }

}
