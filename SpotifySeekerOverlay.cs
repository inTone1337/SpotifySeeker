using Gma.System.MouseKeyHook;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Timers;
using System.Windows.Forms;

namespace SpotifySeeker
{
    public partial class SpotifySeekerOverlay : Form
    {
        private SpotifyWebAPI spotifyWebAPI;
        private IKeyboardMouseEvents keyboardMouseEvents;
        private static System.Timers.Timer timer;
        private PlaybackContext playbackContext;
        private int seekBalance = 0;
        private const int SeekIncrement = 5000;

        public SpotifySeekerOverlay()
        {
            AuthenticateSpotify();
            InitializeComponent();

            // TODO: Lower the position of the overlay on load (need a more elegant way for this).
            this.Load += MoveSpotifySeekerOverlay;
        }

        private void AuthenticateSpotify()
        {
            ImplicitGrantAuth auth = new ImplicitGrantAuth(
              APIKeys.spotifyClientID,
              "http://localhost:4002",
              "http://localhost:4002",
              Scope.UserReadPlaybackState | Scope.UserModifyPlaybackState
            );
            auth.AuthReceived += async (sender, payload) =>
            {
                auth.Stop();
                spotifyWebAPI = new SpotifyWebAPI()
                {
                    TokenType = payload.TokenType,
                    AccessToken = payload.AccessToken
                };
            };
            auth.Start();
            auth.OpenBrowser();
            StartSpotifySeekerLogic();
        }

        private void StartSpotifySeekerLogic()
        {
            MonitorHorizontalScrolls();
            SeekWhenReady();
        }

        public void MonitorHorizontalScrolls()
        {
            keyboardMouseEvents = Hook.GlobalEvents();
            keyboardMouseEvents.MouseWheelExt += GlobalHookMouseWheelExt;
        }

        private void GlobalHookMouseWheelExt(object sender, MouseEventExtArgs e)
        {
            if (e.IsHorizontalScroll)
            {
                timer.Stop();
                SpotifySeekerOverlaySetOpacity(0.75D);
                if (playbackContext == null)
                {
                    playbackContext = spotifyWebAPI.GetPlayback();
                    String currentTrackArtists = null;
                    foreach (SimpleArtist simpleArtist in playbackContext.Item.Artists)
                    {
                        currentTrackArtists += simpleArtist.Name + ", ";
                    }
                    currentTrackArtists = currentTrackArtists.TrimEnd(", ".ToCharArray());
                    String currentTrackName = playbackContext.Item.Name;
                    CurrentTrackLabelSetText(currentTrackArtists + " - " + currentTrackName);
                    CurrentProgressLabelSetText(TimeSpan.FromMilliseconds(playbackContext.ProgressMs).ToString("mm\\:ss"));
                }
                if (e.Delta > 0)
                {
                    seekBalance++;
                }
                else if (e.Delta < 0)
                {
                    seekBalance--;
                }
                ProgressModifierLabelSetText(TimeSpan.FromMilliseconds((seekBalance * SeekIncrement)).ToString());
                FutureProgressLabelSetText(TimeSpan.FromMilliseconds(playbackContext.ProgressMs + (seekBalance * SeekIncrement)).ToString("mm\\:ss"));
                timer.Start();
            }
        }

        delegate void SetOpacityCallback(double opacity);

        private void SpotifySeekerOverlaySetOpacity(double opacity)
        {
            if (this.InvokeRequired)
            {
                SetOpacityCallback d = new SetOpacityCallback(SpotifySeekerOverlaySetOpacity);
                this.Invoke(d, new object[] { opacity });
            }
            else
            {
                this.Opacity = opacity;
            }
        }

        delegate void SetTextCallback(string text);

        private void CurrentTrackLabelSetText(string text)
        {
            if (this.CurrentTrackLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(CurrentTrackLabelSetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.CurrentTrackLabel.Text = text;
            }
        }

        private void CurrentProgressLabelSetText(string text)
        {
            if (this.CurrentProgressLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(CurrentProgressLabelSetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.CurrentProgressLabel.Text = text;
            }
        }

        private void ProgressModifierLabelSetText(string text)
        {
            if (this.ProgressModifierLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(ProgressModifierLabelSetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.ProgressModifierLabel.Text = text;
            }
        }

        private void FutureProgressLabelSetText(string text)
        {
            if (this.FutureProgressLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(FutureProgressLabelSetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.FutureProgressLabel.Text = text;
            }
        }

        private void SeekWhenReady()
        {
            timer = new System.Timers.Timer(500);
            timer.AutoReset = false;
            timer.Elapsed += SeekPlayback;
        }

        private void SeekPlayback(object sender, ElapsedEventArgs e)
        {
            if (seekBalance != 0)
            {
                spotifyWebAPI.SeekPlayback(playbackContext.ProgressMs + (seekBalance * SeekIncrement));
            }

            playbackContext = spotifyWebAPI.GetPlayback();
            CurrentProgressLabelSetText(TimeSpan.FromMilliseconds(playbackContext.ProgressMs).ToString("mm\\:ss"));
            playbackContext = null;
            seekBalance = 0;
            SpotifySeekerOverlaySetOpacity(0D);
        }

        private void MoveSpotifySeekerOverlay(object sender, EventArgs e)
        {
            this.Top = Convert.ToInt32(this.Top * 1.75);
        }
    }
}