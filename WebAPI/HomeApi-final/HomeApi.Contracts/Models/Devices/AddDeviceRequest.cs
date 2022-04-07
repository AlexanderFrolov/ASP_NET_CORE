﻿namespace HomeApi.Contracts.Models.Devices
{
    /// <summary>
    /// Добавляет поддержку нового устройства.
    /// </summary>
    public class AddDeviceRequest
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public int CurrentVolts { get; set; }
        public bool GasUsage { get; set; }
        public string RoomLocation { get; set; }
    }
}