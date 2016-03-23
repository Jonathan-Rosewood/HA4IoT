﻿using System;
using HA4IoT.Actuators.Triggers;
using HA4IoT.Contracts.Actuators;
using HA4IoT.Contracts.Configuration;
using HA4IoT.Contracts.Hardware;
using HA4IoT.Contracts.Triggers;

namespace HA4IoT.Actuators
{
    public static class TemperatureSensorExtensions
    {
        public static ITrigger GetTemperatureReachedTrigger(this ITemperatureSensor sensor, float target, float delta)
        {
            if (sensor == null) throw new ArgumentNullException(nameof(sensor));

            return new SensorValueReachedTrigger(sensor).WithTarget(target).WithDelta(delta);
        }

        public static ITrigger GetTemperatureUnderranTrigger(this ITemperatureSensor sensor, float target, float delta)
        {
            if (sensor == null) throw new ArgumentNullException(nameof(sensor));

            return new SensorValueUnderranTrigger(sensor).WithTarget(target).WithDelta(delta);
        }

        public static IArea WithTemperatureSensor(this IArea room, Enum id, ISingleValueSensor sensor)
        {
            if (room == null) throw new ArgumentNullException(nameof(room));
            if (sensor == null) throw new ArgumentNullException(nameof(sensor));

            room.AddActuator(new TemperatureSensor(ActuatorIdFactory.Create(room, id), sensor, room.Controller.ApiController));
            return room;
        }
        
        public static ITemperatureSensor GetTemperatureSensor(this IArea room, Enum id)
        {
            if (room == null) throw new ArgumentNullException(nameof(room));

            return room.GetActuator<ITemperatureSensor>(ActuatorIdFactory.Create(room, id));
        }
    }
}