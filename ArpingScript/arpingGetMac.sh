#!/bin/bash
if [ "$#" -ne 1 ]; then
echo "Usage   - ./arpingMac.sh [broadcast]"
echo "Example - ./arpingGetMac.sh 192.168.1.255"
echo "Example - ./arpingGetMac.sh 192.168.1.0 > macList.txt"
echo "Example will perform an ARP scan of the local subnet to which broadcast is assigned"
exit
fi


ip=$1
prefix=$(echo $ip | cut -d '.' -f 1-3)

for i in {1..254}; do
	arping -c 1 $prefix.$i | grep "bytes from" | cut -d " " -f 4 &
done
sleep 2;
exit 0
