% open file here 
fileID = fopen('Billy_13Hz-77-O1-Trial2.txt','r');
formatSpec = '%f';
A = fscanf(fileID,formatSpec);

Fs=128;
N = length(A);

N


num=1/Fs;
l=num

N_10s = 1280;
k_10s = [1:num:(1280-1)/Fs];
A_10s = A(129:1280);

figure
plot(k_10s,A_10s)
%k=[l:num:N/Fs];
%length(k)
xlabel('time')
ylabel('Voltage')
title('First 10s FFT- 13Hz')
print -dpng fig_10s-125 % saves plot as fig_1.png in Matlab work folder





%plot(k,A) % graph time domain
%
power=log(1152)/log(2);
power
%N1=2.^ceil(power)
N1= 2.^floor(power)
%N1=5000

X=fft(A_10s,N1);
[maxFreq_1s,indexMax2]=max(X);
freq = indexMax2*Fs/N1

k=[0:1:N1/2];

f=Fs*k/N1;

figure

plot(f,abs(X(1:((N1/2)+1))));

axis([0,25,0,5000])