% open file here 
fileID = fopen('billy-125-sessio1-O1.txt','r');
formatSpec = '%f';
A = fscanf(fileID,formatSpec);

Fs=128;
N = length(A);

N

num=1/Fs;
l=num


k=[l:num:N];



plot(k,A) % graph time domain
%
power=log(N)/log(2);

power

N1=2.^ceil(power)

%N1=5000

X=fft(A,N1)
[maxFreq_1s,indexMax2]=max(X(1:128))
freq = indexMax2*Fs/N1

k=[0:1:N1/2];

f=Fs*k/N1;


%plot(f,abs(X(1:((N1/2)+1))));
%axis([0,10,0,1000])