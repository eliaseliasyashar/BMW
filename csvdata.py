#!/usr/bin/python
import csv
i=-1
with open('DataCollection/February8th_2015/MentalTask/Relax_0616Feb082015.csv', 'rb') as csvfile:
	s = csv.reader(csvfile, delimiter=' ', quotechar='|')
	file = open("text.txt", "w")
	for row in s:
	    file.write( ','.join(row))
	    file.write("\n")
	file.close()
file = open("text.txt", "r")
file1 = open("AF3.txt", "w")
file2 = open("F7.txt", "w")
file3 = open("F3.txt", "w")
file4 = open("FC5.txt", "w")
file5 = open("FC6.txt", "w")
file6 = open("F4.txt", "w")
file7 = open("F8.txt", "w")
file8 = open("AF8.txt", "w")

for l in file:
	i=i+1
	line=l.split(',');
	if i!=0 :	
		file1.write(line[3]+"\n")
    	file2.write(line[4]+"\n")
	file3.write(line[5]+"\n")
	file4.write(line[6]+"\n")
	file5.write(line[13]+"\n")
	file6.write(line[14]+"\n")
	file7.write(line[15]+"\n")
	file8.write(line[16]+"\n")
        


file1.close()
file2.close()
file3.close()
file4.close()	
file5.close()
file6.close()
file7.close()
file8.close()
file.close()

	  
		

    
