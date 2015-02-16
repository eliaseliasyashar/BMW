#!/usr/bin/python
import csv
i=-1
with open('DataCollection/February8th_2015/SSVEP/SSVEP-15HZ_0621Feb082015.csv', 'rb') as csvfile:
	s = csv.reader(csvfile, delimiter=' ', quotechar='|')
	file = open("text.txt", "w")
	for row in s:
	    file.write( ','.join(row))
	    file.write("\n")
	file.close()
file = open("text.txt", "r")
file1 = open("O1.txt", "w")
file2 = open("O2.txt", "w")
file3 = open("P8.txt", "w")
file4 = open("T8.txt", "w")


for l in file:
	i=i+1
	line=l.split(',');
	if i!=0 :	
		file1.write(line[9]+"\n")
    	file2.write(line[10]+"\n")
	file3.write(line[11]+"\n")
	file4.write(line[12]+"\n")
	
        


file1.close()
file2.close()
file3.close()
file4.close()	
file.close()

	  
		

    
