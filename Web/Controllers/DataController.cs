﻿// ---------------------------------------------------------------
//  Copyright (c) Microsoft Corporation. All rights reserved.
// ---------------------------------------------------------------

namespace Microsoft.Azure.Devices.Applications.PredictiveMaintenance.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Web.Mvc;
    using Contracts;
    using Newtonsoft.Json;

    public sealed class DataController : ApiController
    {
        [Route("api/devices")]
        public IEnumerable<Device> Devices()
        {
            var devices = new Collection<Device>();

            devices.Add(new Device
            {
                Id = "N1172FJ-1",
                Status = "Running",
                Manufacturer = "Microsoft",
                Firmware = "1.92",
                Memory = "10 MB",
                ModelNumber = "MD-868",
                Platform = "Plat-80",
                Processor = "i3-5197",
                SerialNumber = "SER2049",
                Hostname = "IotSuiteLocalcdd50.azure-devices.net",
                CreatedTime = DateTime.Now.ToString("d"),
                UpdatedTime = DateTime.Now.ToString("d"),
                State = "Normal",
                HubEnabledState = true
            });

            devices.Add(new Device
            {
                Id = "N1172FJ-2",
                Status = "Running",
                Manufacturer = "Contoso Inc.",
                Firmware = "1.91",
                Memory = "7 MB",
                ModelNumber = "MD-867",
                Platform = "Plat-79",
                Processor = "i3-5192",
                SerialNumber = "SER2048",
                Hostname = "IotSuiteLocalcdd50.azure-devices.net",
                CreatedTime = DateTime.Now.ToString("d"),
                UpdatedTime = DateTime.Now.ToString("d"),
                State = "Normal",
                HubEnabledState = true
            });

            return devices;
        }

        [Route("api/simulation/start")]
        public void StartSimulation()
        {
            //TODO:
        }

        [Route("api/simulation/stop")]
        public void StopSimulation()
        {
            //TODO:
        }

        [Route("api/telemetry")]
        public EnginesTelemetry GetEnginesTelemetry()
        {
            var source = JsonConvert.DeserializeObject<IEnumerable<Telemetry>>("[{\"deviceId\":\"1\",\"timestamp\":\"2015-11-12T17:34:28.3019877Z\",\"sensor1\":9048.495213,\"sensor2\":47.62901242,\"sensor3\":8127.910672,\"sensor4\":8.233265767},{\"deviceId\":\"2\",\"timestamp\":\"2015-11-12T18:34:28.3019877Z\",\"sensor1\":9048.495213,\"sensor2\":47.62901242,\"sensor3\":8127.910672,\"sensor4\":8.233265767},{\"deviceId\":\"1\",\"timestamp\":\"2015-11-12T19:34:28.3019877Z\",\"sensor1\":9048.495213,\"sensor2\":47.62901242,\"sensor3\":8127.910672,\"sensor4\":8.233265767},{\"deviceId\":\"2\",\"timestamp\":\"2015-11-12T20:34:28.3019877Z\",\"sensor1\":9048.495213,\"sensor2\":47.62901242,\"sensor3\":8127.910672,\"sensor4\":8.233265767},{\"deviceId\":\"1\",\"timestamp\":\"2015-11-12T21:34:28.3019877Z\",\"sensor1\":9048.495213,\"sensor2\":47.62901242,\"sensor3\":8127.910672,\"sensor4\":8.233265767},{\"deviceId\":\"2\",\"timestamp\":\"2015-11-12T22:34:28.3019877Z\",\"sensor1\":9048.495213,\"sensor2\":47.62901242,\"sensor3\":8127.910672,\"sensor4\":8.233265767}]");
            var engine1Telemetry = new Collection<Telemetry>();
            var engine2Telemetry = new Collection<Telemetry>();

            foreach (var telemetry in source)
            {
                if (telemetry.DeviceId == "1")
                {
                    engine1Telemetry.Add(telemetry);
                }
                else
                {
                    engine2Telemetry.Add(telemetry);
                }
            }

            var enginesTelemetry = new EnginesTelemetry { Engine1Telemetry = engine1Telemetry, Engine2Telemetry = engine2Telemetry };

            return enginesTelemetry;
        }

        [Route("api/prediction")]
        public EnginesPrediction GetEnginesPrediction()
        {
            var source = JsonConvert.DeserializeObject<IEnumerable<Prediction>>("[{\"deviceId\":\"1\",\"timestamp\":\"2015-11-12T17:34:28.3019877Z\",\"rul\":30,\"cycles\":10},{\"deviceId\":\"2\",\"timestamp\":\"2015-11-12T18:34:28.3019877Z\",\"rul\":35,\"cycles\":10},{\"deviceId\":\"1\",\"timestamp\":\"2015-11-12T19:34:28.3019877Z\",\"rul\":40,\"cycles\":10},{\"deviceId\":\"2\",\"timestamp\":\"2015-11-12T20:34:28.3019877Z\",\"rul\":40,\"cycles\":10},{\"deviceId\":\"1\",\"timestamp\":\"2015-11-12T21:34:28.3019877Z\",\"rul\":40,\"cycles\":10},{\"deviceId\":\"2\",\"timestamp\":\"2015-11-12T22:34:28.3019877Z\",\"rul\":25,\"cycles\":10}]");
            var engine1Prediction = new Collection<Prediction>();
            var engine2Prediction = new Collection<Prediction>();

            foreach (var prediction in source)
            {
                if (prediction.DeviceId == "1")
                {
                    engine1Prediction.Add(prediction);
                }
                else
                {
                    engine2Prediction.Add(prediction);
                }
            }

            var enginesPrediction = new EnginesPrediction { Engine1Prediction = engine1Prediction, Engine2Prediction = engine2Prediction };

            return enginesPrediction;
        }
    }
}