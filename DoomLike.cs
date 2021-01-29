using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniDoomLike
{
    public partial class DoomLike : Form
    {

        private Timer graphicsTimer;
        private GameLoop loop;
        public DoomLike()
        {
            InitializeComponent();
            // removes stutter and flickering during redraw
            DoubleBuffered = true;
            //load
            Load += DoomLike_Load;

            // Initialize Paint Event
            Paint += DoomLike_Paint;
        }

        private void GraphicsTimer_Tick(object sender, EventArgs e){
            Invalidate();
        }

        private void DoomLike_Load(object sender, EventArgs e)
        {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;

            // Initialize Game
            GameLogic myGame = new GameLogic();
            myGame.Load();
            myGame.Resolution = new Size(resolution.Width, resolution.Height);

            graphicsTimer = new Timer();
            graphicsTimer.Interval = 1000 / 60; // a regler pour les fps
            graphicsTimer.Tick += GraphicsTimer_Tick;

            // Initialize & Start GameLoop
            loop = new GameLoop();
            loop.Load(myGame);
            loop.Start();

            // Start Graphics Timer
            graphicsTimer.Start();
        }

        private void DoomLike_Paint(object sender, PaintEventArgs e)
        {
            // Draw game graphics on Form1
            loop.Draw(e.Graphics);
        }

    }
}
