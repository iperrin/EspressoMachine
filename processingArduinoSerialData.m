clear all
close all
clc

file = 'dataSet1.csv';

serialData = importdata(file);

%%

rawTemp1 = nan(size(serialData));
rawTemp2 = nan(size(serialData));
rawWeight = nan(size(serialData));
rawPress = nan(size(serialData));
rawFreq = nan(size(serialData));
timeStep = nan(size(serialData));

for i = 1:size(serialData,1)
    if size(serialData{i},2) == 49
        data = serialData(i);
        data = data{1,1};
        
        if data(1) == 'S'
            rawPress(i) = (str2num(data(2:9))/100)-1000;
            rawTemp1(i) = (str2num(data(10:17))/100)-1000;
            rawTemp2(i) = (str2num(data(18:25))/100)-1000;
            rawWeight(i) = (str2num(data(26:33))/100)-1000;
            rawFreq(i) = (str2num(data(42:49))/100)-1000;
            timeStep(i) = 1/rawFreq(i);
        end
    end
end

rawTemp1 = rmmissing(rawTemp1);
rawTemp2 = rmmissing(rawTemp2);
rawWeight = rmmissing(rawWeight);
rawPress = rmmissing(rawPress);
rawFreq = rmmissing(rawFreq);
timeStep = rmmissing(timeStep);

time = cumsum(timeStep);


%%
figure

smoothPress = meanData(rawPress,20);
smoothTemp1 = meanData(rawTemp1,40);
smoothTemp2 = meanData(rawTemp2,40);
kalmanWeightData = kalmanFilter(rawWeight,0.05);
flowData = findFlowRate(time, kalmanWeightData, 20);
smoothflowData = kalmanFilter(flowData,0.04);

subplot(5,1,1)
hold on
plot(time, rawPress)
plot(time, smoothPress,'LineWidth',2)
ylabel("Pressure [bars]")

subplot(5,1,2)
hold on
plot(time, rawTemp1)
plot(time, smoothTemp1,'LineWidth',2)
ylabel("Water Temp [C]")

subplot(5,1,3)
hold on
plot(time, rawTemp2)
plot(time, smoothTemp2,'LineWidth',2)
ylabel("GH Temp [C]")

subplot(5,1,4)
hold on
plot(time, rawWeight)
plot(time, kalmanWeightData,'LineWidth',2);
ylabel("Weight [grams]")

subplot(5,1,5)
hold on
plot(time, smoothflowData,'LineWidth',2);
ylabel("Flow Rate [ml/s]")

%%

function flow = findFlowRate(time, weight, windowSize)
    flow = nan(size(time));
    for i = windowSize+1:size(time,1)
        P = polyfit(time(i-windowSize:i),weight(i-windowSize:i),1);
        flow(i) = P(1);
    end
end

function data = meanData(rawData, windowSize)   
    data = nan(size(rawData));
    for i = 1:size(rawData,1)
        data(i) = mean(rawData(max(1,i-windowSize):i));
    end
end

function output = kalmanFilter(rawData, kgain)
    
    output = nan(size(rawData));
    output(1) = rawData(1);
    
    for i = 2:size(rawData, 1)
        if(isnan(output(i-1)))
            output(i) = rawData(i);
        else
            output(i) = (1-kgain)*output(i-1)+kgain*rawData(i);
        end
    end

end
