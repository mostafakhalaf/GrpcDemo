using Grpc.Core;
using Server.Protos;

namespace Server.Services
{
    public class TelemetryTrackingService : TrackingService.TrackingServiceBase
    {
        private readonly ILogger<TelemetryTrackingService> logger;

        public TelemetryTrackingService(ILogger<TelemetryTrackingService> _logger)
        {
            logger = _logger;
        }
        public override Task<TrackingResponse> SendMessage(TrackingMessage request, ServerCallContext context)
        {
            logger.LogInformation($"new message device id {request.DeviceId}" +
                $"  location {request.Location}  Sensors Count {request.Sensor.Count()}");
            return Task.FromResult(new TrackingResponse() { Success = true });
        }
    }
}
