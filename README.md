# GrpcDemo
you should change properties of proto file to be like this
![image](https://github.com/mostafakhalaf/GrpcDemo/assets/17978254/0854a89c-3246-4875-ad7e-2911b96ea248)<br>
to can test Server og grpc you can use postman or this link<br>
https://github.com/fullstorydev/grpcurl/releases
or if not work you shoud find another tool to can test it 
.
after download it you will extract it in folder and should open cmd frome same folder of this tool.
some comand you can use<br>
1-grpcurl -d "{\"deviceId\":1,\"speed\":80,\"location\":{\"lat\":6,\"long\":7}}" localhost:5001 TrackingService/SendMessage<br>
to send data to service and use it you send data as json and determine service and action in it<br>
2-grpcurl localhost:5001 describe .TrackingMessage<br>
to descripe model use descripe to show any thing<br>
3-grpcurl localhost:5001 describe TrackingService <br>
to descripe service and action on it<br>
4-grpcurl localhost:5001 list<br>
to show all service in app<br>
and there is another easy tool it is ui <br>
https://github.com/fullstorydev/grpcui/releases<br>
and as the curl open it in cmd in same folder of ui tool <br>
put this command and ui will open<br>
grpcui localhost:5001<br>
the commpress to files uploaded you can use thiem or download last of it <br>
![image](https://github.com/mostafakhalaf/GrpcDemo/assets/17978254/87ac265a-56eb-43e8-8417-6b567d3691b1)





