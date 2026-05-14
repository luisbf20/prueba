using System;
using System.Collections.Generic;
using System.Text;

namespace FlotaLuisBuenoFernandez
{
    using System.Collections.ObjectModel;
    class LogicaNegocio
    {
        public ObservableCollection<Jugada> Jugadas { get; set; }

        public LogicaNegocio()
        {
            Jugadas = new ObservableCollection<Jugada>();
        }

        public void añadirJugada(Jugada j)
        {
            Jugadas.Add(j);
        }

        public void Reset()
        {
            Jugadas.Clear(); 
        }
    }
}
