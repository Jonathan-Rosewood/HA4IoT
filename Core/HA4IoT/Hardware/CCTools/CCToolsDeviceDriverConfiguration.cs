﻿namespace HA4IoT.Hardware.CCTools
{
    public class CCToolsDeviceDriverConfiguration
    {
        public int Address { get; set; }

        public string Interrupt { get; set; }

        public int PollDurationWarningThreshold { get; set; } = 25;
    }
}
