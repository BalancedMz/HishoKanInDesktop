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
using System.Threading.Tasks;
using System.Windows.Media;
using System.IO;

namespace HishoKan_InDeskop
{
    class VoicePlayer : MediaPlayer
    {
        private readonly System.Threading.SynchronizationContext _syncContext = null;

        public VoicePlayer()
        {
            _syncContext = System.Threading.SynchronizationContext.Current;
        }

        public void Play(string path)
        {
            if (path == null)
                return;

            //http://www.dotblogs.com.tw/clark/archive/2013/05/04/102772.aspx
            System.Threading.SendOrPostCallback methodDelegate = delegate(object state)
            {
                Uri uri = new Uri(path);
                Open(uri);
                Play();
            };
            _syncContext.Post(methodDelegate, null);
        }
    }
}
