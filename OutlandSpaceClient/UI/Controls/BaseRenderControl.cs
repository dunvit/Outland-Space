﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutlandSpaceClient.Tools;
using Universe.Session;

namespace OutlandSpaceClient.UI.Controls
{
    public class BaseRenderControl : UserControl
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        [DllImport("user32.dll")]
        public static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);

        bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, (uint)0, (uint)0, (uint)0) == 0;
        }

        private void HandleApplicationIdle(object sender, EventArgs e)
        {
            while (IsApplicationIdle())
            {
                Update();
                //Render();
            }
        }

        public event Action OnRender;
        protected int currentFrameRate;
        protected int lastFrameRate;
        protected IGameSessionData _session;

        public BaseRenderControl()
        {
            log.Debug("Create base rendering control.");

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            UpdateStyles();

            if (Global.Game == null) return;

            Global.Game.OnEndTurn += Event_EndTurn;
            Global.Game.OnRefreshLocations += Event_RefreshLocations;

            Application.Idle += HandleApplicationIdle;
        }

        private void Event_RefreshLocations(IGameSessionData session)
        {
            lock (_syncLock)
            {
                _session = session;
            }                
        }

        private readonly object _syncLock = new object();

        private void Event_EndTurn(IGameSessionData session)
        {
            _session = session;

            lock (_syncLock)
            {
                if (session.IsPause) return;

                _lastFrame = HighResolutionDateTime.UtcNow;
                lastFrameRate = currentFrameRate;
                currentFrameRate = 0;
            }
        }

        private DateTime _lastFrame = HighResolutionDateTime.UtcNow;

        protected void Update()
        {
            if (_session is null) return;

            lock (_syncLock)
            {
                var diff = HighResolutionDateTime.UtcNow - _lastFrame;

                if (diff.TotalMilliseconds > 16.6)
                {
                    currentFrameRate++;
                    _lastFrame = HighResolutionDateTime.UtcNow;

                    Task.Run(Render);
                }
            }
        }

        protected virtual async Task Render()
        {
            
        }
    }
}
