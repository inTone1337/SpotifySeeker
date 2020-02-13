using Gma.System.MouseKeyHook;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System.Windows.Forms;

namespace SpotifySeeker
{
    public partial class Form1 : Form
    {
        private SpotifyWebAPI api;
        private IKeyboardMouseEvents m_GlobalHook;

        public Form1()
        {
            Subscribe();

            ImplicitGrantAuth auth = new ImplicitGrantAuth(
              "775e0a0f3be94bf5aa8c9a9578cfe5c8",
              "http://localhost:4002",
              "http://localhost:4002",
              Scope.UserReadPlaybackState | Scope.UserModifyPlaybackState
            );
            auth.AuthReceived += async (sender, payload) =>
            {
                auth.Stop(); // `sender` is also the auth instance
                api = new SpotifyWebAPI()
                {
                    TokenType = payload.TokenType,
                    AccessToken = payload.AccessToken
                };
            };
            auth.Start(); // Starts an internal HTTP Server
            auth.OpenBrowser();

            InitializeComponent();
        }

        public void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.MouseWheel += GlobalHookMouseWheel;
        }

        private void GlobalHookMouseWheel(object sender, MouseEventArgs e)
        {
            PlaybackContext playbackContext = api.GetPlayback();
            if (e.Delta > 0)
            {
                api.SeekPlayback(playbackContext.ProgressMs + 1000);
            }
            else if (e.Delta < 0)
            {
                api.SeekPlayback(playbackContext.ProgressMs - 1000);
            }
        }
    }
}