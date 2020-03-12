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
        private IKeyboardMouseEvents keyboardMouseEvents;
        private SpotifyWebAPI spotifyWebAPI;
        private PlaybackContext playbackContext;
        private int seekBalance = 0;
        private static System.Timers.Timer timer;
        private const int SeekIncrement = 5000;

        public SpotifySeekerOverlay()
        {
            AuthenticateSpotify();
            InitializeComponent();

            //TODO: Lower the position of the overlay on load (need a more elegant way for this).
            this.Load += MoveSpotifySeekerOverlay;
        }

        private void AuthenticateSpotify()
        {
            TokenSwapWebAPIFactory tokenSwapWebAPIFactory;

            tokenSwapWebAPIFactory = new TokenSwapWebAPIFactory("")
            {
                Scope = Scope.UserReadPlaybackState | Scope.UserModifyPlaybackState,
                AutoRefresh = true
            };
            tokenSwapWebAPIFactory.OnAuthSuccess += (sender, e) => StartSpotifySeekerLogic();
            // webApiFactory.OnAccessTokenExpired += (sender, e) => authorized = false;

            try
            {
                spotifyWebAPI = tokenSwapWebAPIFactory.GetWebApiAsync().Result;
            }
            catch (Exception ex)
            {
            }
        }

        private void StartSpotifySeekerLogic()
        {
            MonitorHorizontalScrolls();
            SeekWhenReady();
        }

        private void MoveSpotifySeekerOverlay(object sender, EventArgs e)
        {
            this.Top = Convert.ToInt32(this.Top * 1.75);
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
                SpotifySeekerOverlaySetOpacity(0.5D);
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

        delegate void SetTextCallback(string text);
        delegate void SetOpacityCallback(double opacity);

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

        private void SeekWhenReady()
        {
            timer = new System.Timers.Timer(500);
            timer.AutoReset = false;
            timer.Elapsed += SeekPlayback;
        }
    }
}