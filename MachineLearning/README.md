## MachineLearning

### KMeansClustering
Pattern recognition
```csharp
const int clusterCount = 3;
int[] clustering = new KMeansClustring(clusterCount).GetClusterIndeces(data);
```

Sample Data:

|Label|Value 1|Value 2|Value 3|
|-----|-------|-------|-------|
|portland|65.0|220.0|3| 
|dallas|73.0|160.0|6| 
|birmingham|59.0|110.0|5| 
|miami|61.0|120.0|8| 
|new york|75.0|150.0|5| 
|chicago|67.0|240.0|4| 
|detroit|68.0|230.0|7| 
|boston|70.0|220.0|3| 
|tucsan|62.0|130.0|7| 
|las vegas|66.0|210.0|9| 
|sacramento|77.0|190.0|4| 
|san diego|75.0|180.0|2| 
|seattle|74.0|170.0|4| 
|boise|70.0|210.0|1| 
|lincoln|61.0|110.0|0| 
|madison|58.0|100.0|5| 
|crown point|66.0|230.0|5| 
|dunbar|59.0|120.0|4| 
|lexington|68.0|210.0|2| 
|denver|61.0|130.0|2| 
|charlotte|59.0|80.0|5| 

Result:

|Label|Cluster Index|
|-----|-------------|
|portland|0| 
|dallas|1| 
|birmingham|2| 
|miami|2| 
|new york|1| 
|chicago|1| 
|detroit|2| 
|boston|0| 
|tucsan|2| 
|las vegas|2| 
|sacramento|1| 
|san diego|0| 
|seattle|1| 
|boise|0| 
|lincoln|0| 
|madison|2| 
|crown point|1| 
|dunbar|1| 
|lexington|0| 
|denver|0| 
|charlotte|2| 
