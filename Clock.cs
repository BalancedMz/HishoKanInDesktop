/*  Copyright (C) 2015 BalancedMz

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.IO;

using System.Windows.Forms;

namespace HishoKan_InDeskop
{
    abstract class Clock
    {
        protected int millSecToWait;
        protected readonly VoicePlayer player;
        protected readonly FileOrganizer fo;
        protected Thread thread;

        public Clock(VoicePlayer player , FileOrganizer fo)
        {
            this.player = player;
            this.fo = fo;
        }

        public void Start()
        {
            if (thread == null || !thread.IsAlive)
            {
                ThreadStart runMethod = new ThreadStart(Run);
                this.thread = new Thread(runMethod);
                this.thread.IsBackground = true;                  //want the app to exit when the main thread has finished;
                this.thread.Start();
            }
        }

        public void Stop()
        {
            if (this.thread != null && this.thread.IsAlive)
                this.thread.Abort();

        }

        abstract protected void Run();

    }

    class HourClock : Clock
    {
        private int nextMp3Num;

        public HourClock(VoicePlayer player, FileOrganizer fo)
            : base(player, fo) { }

        protected override void Run()
        {
            while (true)
            {
                millSecToWait = findNextAwake();
                Thread.Sleep(millSecToWait);
                player.Play(fo.GetCharFolderPath() + @"clock\" + nextMp3Num + ".mp3");
            }
        }

        private int findNextAwake()
        {
            int currentHour = DateTime.Now.Hour;            // from 0 to 23

            TimeSpan now = DateTime.Now.TimeOfDay;
            TimeSpan nextHour = TimeSpan.FromHours(currentHour + 1);

            if (currentHour + 1 == 24)
                nextMp3Num = 30;                    // 30.mp3 = 0:00
            else
                nextMp3Num = currentHour + 31;      // so 31.mp3 = 1:00

            TimeSpan result = nextHour.Subtract(now);

            return (int)result.TotalMilliseconds;
        }
    }

    class IdleClock : Clock
    {
        private readonly Random rnd = new Random();

        public IdleClock(VoicePlayer player, FileOrganizer fo)
            : base(player, fo) {}

        public void SetIdleTime(int interval)
        {
            millSecToWait = interval;
            Stop();
            Start();
        }

        protected override void Run()
        {
            while (true)
            {
                Thread.Sleep(millSecToWait);
                player.Play(fo.GetRandomIdleFile());
            }
        }
    }
}