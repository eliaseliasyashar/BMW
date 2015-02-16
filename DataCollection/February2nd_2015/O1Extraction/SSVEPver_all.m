% open file here 
%specific for this trial
fileID = fopen('Billy_13Hz-77-O1-Trial2.txt','r');
formatSpec = '%f';
A = fscanf(fileID,formatSpec);

Fs=128;
N = length(A);

N

num=1/Fs;
l=num

t = linspace(0,N/Fs, N);
length(t)

figure
plot(t,A) % graph time domain
xlabel('Time(s)');
ylabel('Amplitude');
%
power=log(N)/log(2);

power

N1=2.^floor(power);

N1=5000

X=fft(A,N1);

k=[0:1:N1/2];

f=Fs*k/N1;

figure
plot(f,abs(X(1:((N1/2)+1))));
axis([0,20,0,40000])