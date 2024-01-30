using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Server.Protos;

namespace Device
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly int deviceId;
        private TrackingService.TrackingServiceClient _client;
        private TrackingService.TrackingServiceClient Client
        {
            get
            {
                if (_client == null)
                {
                    var channel = GrpcChannel.ForAddress("https://localhost:5001");

                    _client = new TrackingService.TrackingServiceClient(channel);
                }

                return _client;
            }
        }
        public Worker(ILogger<Worker> logger, int deviceId)
        {
            _logger = logger;
            this.deviceId = deviceId;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Random random = new Random();
                var request = new TrackingMessage
                {
                    DeviceId = deviceId,
                    Speed = random.Next(0, 220),
                    Location = new Location
                    {
                        Lat = random.Next(0, 100),
                        Long = random.Next(0, 100)
                    },
                    Stamp = Timestamp.FromDateTime(DateTime.UtcNow),
                };
                request.Sensor.Add(new Sensor()
                {
                    Key = "sensor 1",
                    Value = 2
                });
                var respons = await Client.SendMessageAsync(request);
                _logger.LogInformation($"Response {respons.Success}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
