using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Data.Queries
{
    /// <summary>
    /// Класс для передачи дополнительных параметров при перезаписи комнаты
    /// </summary>
    public class UpdateRoomQuery
    {
        public string Name { get; }
        public int NewArea{ get; }
        public bool NewGasConnected { get; }
        public int NewVoltage { get; }

        public UpdateRoomQuery(bool newGasConnected, int newArea = 0, int newVoltage = 0)
        {     
            NewArea = newArea;
            NewGasConnected = newGasConnected;
            NewVoltage = newVoltage;
        }
    }
}
