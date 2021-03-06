﻿using HA4IoT.Contracts.Core;
using HA4IoT.Contracts.Hardware;
using HA4IoT.Contracts.Hardware.I2C;
using HA4IoT.Contracts.Logging;
using HA4IoT.Hardware.Drivers.I2CPortExpanderDrivers;

namespace HA4IoT.Hardware.Drivers.CCTools.Devices
{
    public class HSPE16OutputOnly : CCToolsDeviceBase
    {
        public HSPE16OutputOnly(string id, I2CSlaveAddress address, II2CBusService i2CBusService, ILogger log)
            : base(id, new MAX7311Driver(address, i2CBusService), log)
        {
            CommitChanges(true);
        }

        public IBinaryOutput GetOutput(int number)
        {
            return GetPort(number);
        }

        public IBinaryOutput this[HSPE16Pin pin] => GetOutput((int)pin);
    }
}
