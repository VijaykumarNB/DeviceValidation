using System;
using Com.TMobile.Syncup.Device.Telemetry.Models.Models;
using DeviceV2.Validators.Sensor;
using FluentValidation;

namespace DeviceV2.Validators
{
    public class DeviceValidator : AbstractValidator<Device>
    {
        public DeviceValidator(string productID)
        {
            RuleFor(x => x.ActivityLog).SetValidator(new ActivityLogValidator());
            RuleFor(x => x.AlarmsDefinition).SetValidator(new AlarmsDefinitionValidation());
            RuleFor(x => x.Battery).SetValidator(new BatteryValidator());
            RuleFor(x => x.BatteryStatus).SetValidator(new BatteryStatusValidator());
            RuleFor(x => x.BootEvent).SetValidator(new BootEventValidator());
            RuleFor(x => x.CallLog).SetValidator(new CallLogValidator());
            RuleFor(x => x.CellReadings).SetValidator(new CellReadingsValidator());
            RuleFor(x => x.ContactDefinition).SetValidator(new ContactDefinitionValidator());
            RuleFor(x => x.DisplaySettings).SetValidator(new DisplaySettingsValidator());
            RuleFor(x => x.Emergency911).SetValidator(new Emergency911Validation());
            RuleFor(x => x.FirmwareInformation).SetValidator(new FirmwareInformationValidator());
            RuleFor(x => x.GeoFenceDefinition).SetValidator(new GeoFenceDefinitionValidator());
            RuleFor(x => x.GeoFenceEvent).SetValidator(new GeoFenceEventValidator());
            RuleFor(x => x.HardwareEnabled).SetValidator(new HardwareEnabledValidator());
            RuleFor(x => x.HardwareInformation).SetValidator(new HardwareInformationValidator()); // Validation some other props
            RuleFor(x => x.LightEvent).SetValidator(new LightEventValidator());
            RuleFor(x => x.Location).SetValidator(new LocationValidator(productID));
            RuleFor(x => x.LocationSettings).SetValidator(new LocationSettingsValidator());
            RuleFor(x => x.PresetMessages).SetValidator(new PresetMessagesValidator());
            RuleFor(x => x.ProximityEvent).SetValidator(new ProximityEventValidator());
            RuleFor(x => x.RewardDefinition).SetValidator(new RewardDefinitionValidator());
            RuleFor(x => x.SmsLog).SetValidator(new SmsLogValidator());
            RuleFor(x => x.SosEvent).SetValidator(new SosEventValidator());
            RuleFor(x => x.SoundSettings).SetValidator(new SoundSettingsValidator());
            RuleFor(x => x.TaskCompletionEvent).SetValidator(new TaskCompletionEventValidator());
            RuleFor(x => x.TasksDefinition).SetValidator(new TasksDefinitionValidator());
            RuleFor(x => x.Temperature).SetValidator(new TemperatureValidator());
            RuleFor(x => x.TemperatureSettings).SetValidator(new TemperatureSettingsValidator());
            RuleFor(x => x.WifiReadings).SetValidator(new WifiReadingsValidator());
            RuleFor(x => x.LocationOverrideByWifi).SetValidator(new LocationOverrideByWifiValidator(productID));
        }
    }
}
