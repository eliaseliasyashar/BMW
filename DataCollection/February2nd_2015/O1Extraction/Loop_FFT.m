%rawFileName needs extention .txt
%function[PowerSUM] = Loop_FFT(rawFileName)
function [O1]= Loop_FFT(rawFileTrial,rawFileName)
f1 = 8;
f3=12;
%call by doing attention(8,12,'14_att=63')
format long e
%{
% Open Raw data file for storage
 Raw Data file format: integer
%}

fileID = fopen(rawFileName,'r');
formatSpec = '%f';
RAW = fscanf(fileID,formatSpec);



%sampling frequency
Fs=128;

%checking how many sample in in the text file
N = length(RAW);

%{define how many sample is used- 
%keep 512*(n-1) samples, because we don't 
%have the next attention value to reference
%}
N1 = Fs*(floor(N/Fs)-1);


% run the loop base on number of trial
index_1= 1;
index_2= Fs;
%Row 1: Power
%Row 2: Attention
%PowerSUM= zeros(floor(N/Fs)-1,1);
for trial = 1:(floor(N/Fs)-1)
    
    %running FFT for every second 
    RAW_interval = RAW(index_1: index_2);
    
    
    N_sample= 128;
    RAW_FFT = fft(RAW_interval, N_sample);
    
    
    %Plot FFT result
    N_FFT = length(RAW_FFT);
    k= [0:1:N_sample/2];
    f= Fs*k/N_sample;
    plot(f,abs(RAW_FFT(1:N_FFT/2+1)));
    axis([0,30,0,1000])
    xlabel('f (positive frequency)')
    ylabel('Amplitude')
    title([rawFileTrial,num2str(trial+1)])
    
    %save picFileName.png to directory
    %picFileName= ['RawDataATT',num2str(trial+1)]
    picFileName= [rawFileTrial,num2str(trial+1)];
    print('-dpng',picFileName)

    %{ 
    %Compute magniude and Use for Power
    F1 = f1/512;
    F3= f3/512;
    b=fir1(511,[F1 F3]);
   
   
%try to compute the magnitude... 
    m=8;
    sum=0;

    while m<f3
    data=RAW_FFT(m);
    
    r=real(data);
    i=imag(data);
    
    magsquare=(r^2)+(i^2);
    sum=sum+magsquare;
    m=m+1;
    end 


   PowerSUM(trial)=sum/(f3-f1);
  %}  
    %increment index
    index_1 = index_1 + Fs;
    index_2 = index_2 + Fs;
    
   
end


t = linspace(0,N/Fs, N);
figure
plot(t,RAW) % graph time domain
xlabel('Time(s)');
ylabel('Amplitude');
title('Voltage-Time');
picFileName= [rawFileTrial,'Voltage-TIme'];
print('-dpng',picFileName)

%{
%output matlab sum result to file
powerDataName= ['PowerData','_',rawFileName];
save(powerDataName,'PowerSUM','-ascii');
type(powerDataName)


%output attention to file
powerDataName= ['AttentionData','_',rawFileName];
save(powerDataName,'Attention1','-ascii');
type(powerDataName)

%}
%{

%
num=1/512;
l=num

k=[l:num:1];

k










%plot(X)
%axis([512,1026,12.8,14.4])

Fs=512;
L=length(X);%length of total


plot(X);
num=L/512; %number of seconds
num

%X
%XA=X(1025:1536)%extract the first second eeg
%XA

%X1=DTFT(XA);

%plot(X);


LA=length(X)%lengthn

power=log(LA)/log(2);
%power
N=2.^ceil(power);

N
Xfft = fft(X,N);



%plot(Xfft);

k=[0:1:N/2];
f=Fs*k/N;



%hide for now
f1 = f1/512;
f3= f3/512;
%f1=8/512;
%f3=12/512;

b=fir1(511,[f1 f3]);

%freqz(b,1,512)
%plot(b);
%filtsig=b*Xfft;

%try to compute the magnitude... 
m=8;
sum=0;

while m<f3
    data=Xfft(m);
    r=real(data);
    r
    i=imag(data);
    i

    magsquare=(r^2)+(i^2);
    sum=sum+magsquare;
    m=m+1;
end 

sum1=sum/(f3-f1);
sum1




%partialIntergral = trapz(Xfft();
%Length = length(Xfft(8:12))

%Len = length(f(9:13))

%partialIntergral = trapz(f(8:12),Xfft(8:12));
%area (f,Xfft);
%hold on;
%area(f(8:12), abs(Xfft(8:12)),'Facecolor', 'red');


%plot(f,abs(Xfft(1:((N/2)+1))));

%p=integral(Xfft,9,12);

%axis([0,50,0,10000])
grid on;
grid minor;

%xaft=fft(XA);

%%%NFFT=2^nextpow2(LA);
%%%XFFT=fft(XA,NFFT)/L;
%%%f=Fs/2*linspace(0,1,NFFT/2+1);

%%%plot(f, 2*abs(XFFT(1:NFFT/2+1)))
%%%axis([0,10,0,0.1])


%xdft=fft(X(:,1));

%a=length(X(5,1));
%a

%freq=0:DF:Fs/2;
%xdft=xdft(1:round(length(x)/2));
%plot(freq, abs(xdft))
end
%}