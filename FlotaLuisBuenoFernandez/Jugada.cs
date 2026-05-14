using System;
using System.Collections.Generic;
using System.Text;

namespace FlotaLuisBuenoFernandez
{
    class Jugada
    {
        public int PosX {  get; set; }
        public int PosY { get; set; }

        public Jugada(int x, int y)
        {
            this.PosX = x;
            this.PosY = y;
        }
    }
}
