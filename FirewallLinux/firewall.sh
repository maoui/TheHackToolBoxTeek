#!/bin/bash 
# Script qui démarre les règles de filtrage IPv4

#=======================================================================
#
#          FILE:  firewall.sh
#
#         USAGE:  
#
#   DESCRIPTION:  Rules IPTABLES for unix server 
# 	Copyright (C) 2016 Teeknofil
#       OPTIONS:  ---
#  REQUIREMENTS:  ---
#          BUGS:  ---
#         NOTES:  Contact teeknofil.dev@gmail.com for bug.
#        AUTHOR:  Teeknofil
#       COMPANY:  Anonymous freelance.
#       VERSION:  1.0
#       CREATED:  17/12/2016 12:42:31 CEST
#      REVISION:  ---
#=======================================================================


#set -x
#set -v


####### Global variable
#######

 BOLD="\033[01;01m" 	# Higligh
 GREEN='\e[0;32m'		# Success
 YELLOW='\e[01;33m'		# Warning/Information 
 RESET="\033[00m"		# Normal
 
 



ColorEcho()
{
	echo -e "${1}${2}$RESET"	
}

OK=$(ColorEcho $GREEN "[ OK ]")
TASK=$(ColorEcho $GREEN "[+]")

####### Vidage des tables et des règles personnelles
####### c'est-à-dire… le filtrage.

ClearIptables()
{

	

	echo; echo -e "$TASK Reset policy by default  \n"; 
	set -v
	iptables -X
	iptables -F
	iptables -t filter -F
	iptables -t filter -X
	iptables -t nat -F
	iptables -t nat -X
	iptables -t mangle -F
	iptables -t mangle -X

	iptables --policy INPUT   ACCEPT
	iptables --policy FORWARD ACCEPT
	iptables --policy OUTPUT  ACCEPT

	set +v

	echo -e "- Reset of firewall 				: $OK"
}

RulesIptables()
{
	#########################
	# Politiques par défaut #
	#########################


	######### Les instructions qui suivent concernent la table « filter »	
	######### Les politiques par défaut déterminent le devenir d'un paquet auquel
	######### aucune règle spécifique ne s'applique.
	#### On bloque tout les connexion entrantes et sortantes.
	#### Attention il faut autoriser les connexions à distance pour un
	#### serveur distant comme par exemple SSH
	#### Interdire toute connexion entrante

	echo -e "\n$TASK Policy rules 				: $YELLOW[ Start Initialization ]$RESET\n"

	## Interdire toute connexion sortante
	iptables  -t filter -P INPUT DROP	
	iptables  -t filter -P FORWARD DROP

	echo -e " - Block all connect input			: $OK"

	iptables -t filter -P OUTPUT DROP

	echo -e " - Block all connect OUTPUT			: $OK"
	echo -e "\n- Policy by defaut				: $OK"

##### Debut Regles ######
	echo -e "\n$TASK Filtering rules				: $YELLOW[ START ]$RESET\n"


###### Debut Initialisation ######

######################
# Règles de filtrage #
######################

######## Nous précisons ici des règles autoriser pour les paquets vérifiant
######## certaines conditions.

#### Accepter les packets entrants relatifs à des connexions déjà
#### établies : cela va plus vite que de devoir réexaminer toutes
#### les règles pour chaque paquet.

	iptables -A INPUT -m state --state RELATED,ESTABLISHED -j ACCEPT
	iptables -A OUTPUT -m state --state RELATED,ESTABLISHED -j ACCEPT

#### Autoriser loopback
	iptables -t filter -A INPUT -i lo -j ACCEPT
	iptables -t filter -A OUTPUT -o lo -j ACCEPT
	echo -e "- Allow loopback  				: $OK"

#### Décommentez la ligne suivante pour autoriser le NAT
#### Remplace eth0 par la carte réseau de votre choix
#### Si vous avez une politique par défaut DROP dans votre chaîne FORWARD, vous devez ajouter une règle 
#### autorisant la retransmission de requêtes HTTP entrantes afin que le routage NAT de destination soit 
#### possible. EXEMPLE : iptables -A FORWARD -i eth0 -p tcp --dport 80 -d 172.31.0.23 -j ACCEPT

 	iptables -A FORWARD -i eth0 -j ACCEPT
	echo -e "- Allow NAT	 				: $OK"

#### Décommentez les ligne suivante pour
#### Accepter le protocole ICMP (notamment le ping)

	iptables -t filter -A INPUT -p icmp -j ACCEPT
	iptables -t filter -A OUTPUT -p icmp -j ACCEP
#iptables -t filter -A INPUT -p icmp -s 0.0.0.0 -j ACCEPT

	echo -e "- Allow PING	  				: $OK"

#### Décommentez la ligne suivante pour
#### Accepter le protocole IGMP (pour le multicast)
	iptables -t filter -A INPUT -p igmp -j ACCEPT
	iptables -t filter -A OUTPUT -p igmp -j ACCEPT
	echo -e "- Allow IGMP	  				: $OK"

#### Décommentez la ligne suivante pour
#### Accetet le protocole ICMP (notament le ping) a partir d'une adresse autoriser
#### Régle ICMP précedante doit être  commentez

	# iptables -A FORWARD -s 0.0.0.0 -o eth0 -p icmp --icmp-type echo-request -j ACCEPT


#### Décommentez les lignes suivante pour autoriser le service FTP

	iptables -t filter -A INPUT   -p tcp --dport 20 -j ACCEPT
	iptables -t filter -A OUTPUT  -p tcp --dport 20 -j ACCEPT
	iptables -t filter -A INPUT   -p tcp --dport 21 -j ACCEPT
	iptables -t filter -A OUTPUT  -p tcp --dport 21 -j ACCEPT
 	echo -e "- Allow FTP					: $OK"


#### Décommentez la ligne suivante pour que le serveur SSH éventuel
#### soit disponible de l'extérieur

	iptables -t filter -A INPUT -p tcp --dport 22 -j ACCEPT
	iptables -A OUTPUT -p tcp --dport 22 -j ACCEPT
	echo -e "- Allow SSH 					: $OK"


##### Décommentez la lignes suivante pour autoriser le service TELNET 
#### soit disponible de l'extérieur


	iptables -t filter -A INPUT -p tcp --dport 23 -j ACCEPT
	echo -e "- Allow TELNET  				: $OK"


#### Décommentez la ligne suivante pour que le serveur de courrier éventuel soit
#### joignable de l'extérieur. Laissez bien smtps et submission si vous avez
#### activé les services SMTPS et soumission de messages… L'option --dports
#### permet de traiter plusieurs ports en une fois.


 	iptables -t filter -A INPUT  -p tcp  --dport 25   -j ACCEPT
 	iptables -t filter -A OUTPUT -p tcp  --dport 25   -j ACCEPT
 	echo -e "- Allow SMTP					: $OK"

 	iptables -t filter -A INPUT  -p tcp  --dport 110  -j ACCEPT
 	iptables -t filter -A OUTPUT -p tcp  --dport 110  -j ACCEPT
 	echo -e "- Allow POP3 					: $OK"

 	iptables -t filter -A INPUT   -p tcp  --dport 143  -j ACCEPT
 	iptables -t filter -A OUTPUT  -p tcp  --dport 143  -j ACCEPT 
 	echo -e "- Allow IMAP					: $OK"

 	iptables -t filter -A INPUT  -p tcp  --dport 465  -j ACCEPT
 	iptables -t filter -A OUTPUT -p tcp  --dport 465  -j ACCEPT
 	echo -e "- Allow of SMTP SLL				: $OK"
	

#### Décommentez les lignes suivantes pour que le  nom de domaine 
#### soit joignable de l'extérieur.

	 iptables -t filter -A OUTPUT -p tcp --dport 53 -j ACCEPT
	 iptables -t filter -A OUTPUT -p udp --dport 53 -j ACCEPT
	 iptables -t filter -A INPUT -p tcp --dport 53 -j ACCEPT
	 iptables -t filter -A INPUT -p udp --dport 53 -j ACCEPT

	 echo -e "- Allow DNS	 				: $OK"

##### Décommentez les lignes suivante pour autoriser le service DHCP Input

	 iptables -t filter -A INPUT -p tcp --dport 67 -j ACCEPT
	 echo -e "- Allow DHCP TCP  				: $OK"


	 iptables -t filter -A INPUT -p udp --dport 67 -j ACCEPT
	 echo -e "- Allow DHCP UDP  				: $OK"	 


#### Décommentez la ligne suivante pour que le serveur Web éventuel
#### soit joignable de l'extérieur.

	 iptables -t filter -A INPUT -p tcp --dport http -j ACCEPT
	 echo -e "- Allow Apache on http 				: $OK"
	 iptables -t filter -A OUTPUT -p tcp --dport http -j ACCEPT
	 echo -e "- Allow Navigator Web				: $OK"

	 iptables -t filter -A INPUT -p tcp --dport 8443 -j ACCEPT
	 echo -e "- Allow Apache server on the port 8443 		: $OK"

## HTTP-ALT-TCP Input
	 iptables -A INPUT -p tcp --dport 8080 -j ACCEPT
	echo -e "- Allow HTTP-ALT-TCP  				: $OK"

#### Si vous avez activé le HTTPS…

	iptables -t filter -A INPUT -p tcp --dport https -j ACCEPT
	echo -e "- Allow Apache server on https 			: $OK"

	iptables -t filter -A OUTPUT -p tcp --dport https -j ACCEPT
	echo -e "- Allow Navigator Web				: $OK"

	# iptables -t filter -A INPUT -p tcp --dport 8443 -j ACCEPT

	#### Décommentez les deux lignes suivantes pour que le serveur rpcbind
	#### éventuel soit joignable de l'extérieur.
	 iptables -t filter -A INPUT   -p tcp --dport 111 -j ACCEPT
	 iptables -t filter -A INPUT   -p udp --dport 111 -j ACCEPT
	 iptables -t filter -A OUTPUT  -p tcp --dport 111 -j ACCEPT
	 iptables -t filter -A OUTPUT  -p udp --dport 111 -j ACCEPT
	 echo -e "- Allow RPCBIND 				: $OK"

	 ##### Décommentez la ligne suivante pour autoriser le service NNTP Input

	iptables -t filter -A INPUT -p tcp --dport 119 -j ACCEPT 
	 echo -e "- Allow NNTP	  				: $OK"


	##### Décommentez la ligne suivante pour autoriser le service NTP Input

	 iptables -t filter -A INPUT -p tcp --dport 123 -j ACCEPT
	 iptables -t filter -A INPUT -p udp --dport 123 -j ACCEPT
	 echo -e "- Allow NTP	  				: $OK"

	#### Décommentez les deux lignes suivantes pour que le serveur Samba
	#### éventuel soit joignable de l'extérieur.

	 iptables -A INPUT  -p tcp --dport 139 -j ACCEPT
	 iptables -A INPUT  -p udp --dport 139 -j ACCEPT
	 echo -e "- Allow NETBIOS-SSN				: $OK"


	#### Décommentez les deux lignes suivantes pour que le serveur microsoft-ds
	#### éventuel soit joignable de l'extérieur.

	 iptables -A INPUT  -p tcp --dport 445 -j ACCEPT
	 iptables -A INPUT  -p udp --dport 445 -j ACCEPT
	 echo -e "- Allow MICROSOFT-DS				: $OK"


	#### Décommentez les deux lignes suivantes pour que le serveur d'impression
	#### éventuel soit joignable de l'extérieur.

	 iptables -A INPUT -p tcp --dport ipp -j ACCEPT
	 iptables -A INPUT -p udp --dport ipp -j ACCEPT
	 echo -e "- Allow IPP	 				: $OK"

		
	##### Décommentez la ligne suivante pour autoriser le service MYSQL Input
	 
	iptables -A INPUT  -p tcp --dport 3306 -j ACCEPT
	echo -e "- Allow MySQL		 			: $OK"


	#### Décommentez la ligne suivante pour que des clients puissent se connecter
	#### à l'ordinateur par XDMCP.

	iptables -A INPUT -p udp --dport xdmcp -j ACCEPT
	echo -e "- Allow XMCP	 				: $OK"


	#### Décommentez la ligne suivante pour que l'ordinateur puisse se connecter
	#### par XDMCP à une machine distante).

	 iptables -A INPUT -p tcp --dport x11-1 -j ACCEPT
	 echo -e "- Allow XDMCP	 				: $OK"


	#### Décommentez la ligne suivante pour pouvoir recevoir des flux VideoLAN.

	 iptables -A INPUT -p udp --dport 1234 -j ACCEPT
	 echo -e "- Allow VideoLAN	 			: $OK"
		

	##### Décommentez la ligne suivante pour pouvoir recevoir des annonces SAP
	##### (ce sont des annonces de session multicast).

	 iptables -A INPUT -p udp -d 0.0.0.0 --dport 9875 -j ACCEPT
	 echo -e "- Allow SAP	 				: $OK"
		

	##### Décommentez les 3 lignes suivantes pour pouvoir utiliser GnomeMeeting

	 iptables -A INPUT -p tcp --dport 30000:33000 -j ACCEPT
	 echo -e "- Allow GnomeMeeting				: $OK"


	#### Décommentez la ligne suivante pour pouvoir partager de la musique par
	#### DAAP.

	 iptables -A INPUT -p tcp --dport daap -j ACCEPT
	 echo -e "- Allow DAAP					: $OK"

	## serveur FTP VSFTPD  

	 iptables -t filter -A INPUT  -p tcp --dport 40000:40100 -j ACCEPT
	 iptables -t filter -A OUTPUT  -p tcp --sport 40000:40100 -j ACCEPT
	 echo -e "- Allow FTP VSFTPD 				: $OK"


	##### Décommentez la ligne suivante pour autoriser le service  FACEBOOK Input

	 iptables -t filter -A INPUT -p tcp --dport 5050 -j ACCEPT 
	 echo -e "- Allow FACEBOOK	  			: $OK"



	##### Décommentez la ligne suivante pour autoriser le service SKYPE Input
	 iptables -t filter -A INPUT -p tcp --dport 61578 -j ACCEPT
	 echo -e "- Allow SKYPE	  				: $OK"

	#### Décommentez la ligne suivante pour que votre ordinateur
	#### permet l'utisation de VNC
	iptables -A INPUT  -i eth0 -p tcp --sport 5900 -m state --state ESTABLISHED -j ACCEPT
	iptables -A OUTPUT -o eth0 -p tcp --dport 5900 -m state --state NEW,ESTABLISHED -j ACCEPT
	 echo -e "- Allow VNC	  				: $OK"

	##### Décommentez la ligne suivante pour autoriser le service IRC Input
	 
	 iptables -t filter -A INPUT -p tcp --dport 6667 -j ACCEPT
	 echo -e "- Allow IRC					: $OK"


	#### Décommentez la ligne suivante pour que votre ordinateur
	#### annonce son nom et ses services par mDNS sur le réseau local (cela
	#### permet de le contacter sous « son nom d'hôte ».local).

	 iptables -A INPUT -p udp -d 0.0.0.0 --dport mdns -j ACCEPT
	 echo -e "- Allow mDNS	  				: $OK"


	###### Fin Inialisation ######
	 echo -e "\n$TASK Filtering Rules 				: $YELLOW[ End Initialization ]$RESET";echo



	#### La règle par défaut pour la chaine INPUT devient REJECT (contrairement
	#### à DROP qui ignore les paquets, avec REJECT, l'expéditeur est averti
	#### du refus). Il n'est pas possible de mettre REJECT comme politique par
	#### défaut. Au passage, on note les paquets qui vont être jetés, ça peut
	#### toujours servir.

	iptables -A INPUT -j LOG --log-prefix "paquet IPv4 inattendu "
	iptables -A INPUT -j REJECT

}

NetworkTranslateAddress()
{

	########################
	# Share Network        #
	########################

	####### Les instructions qui suivent concernent la table « nat ».
	#### Décommentez la ligne suivante pour que le système fasse office de
	#### routeur NAT (simple passerelle) et remplacez « eth0 » par le nom de l'interface
	#### connectée à Internet.

	 sleep 1;echo -e  "$TASK $YELLOW Network Address Translating initialization $RESET\n"

	 iptables -t nat -A PREROUTING -p tcp -i eth0 -j DNAT --to-destination 0.0.0.0:443 
	 iptables -t nat -A POSTROUTING -p tcp -o eth0 -j MASQUERADE --to-ports 443


	 iptables -A POSTROUTING -o eth0 -j MASQUERADE
	 iptables -t nat -A POSTROUTING -o eth0 -j SNAT  -s 0.0.0.0  
	 iptables -t nat -A PREROUTING  -i eth0 -j DNAT --to-destination 0.0.0.0
	 
	 echo -e  "$TASK $YELLOW Network Address Translating FINISH $RESET\n";

}

Forwarding()
{

	########################
	# Redirections de port #
	########################

	#### Décommentez la ligne suivante pour que les requêtes TCP reçues sur
	#### le port XX de l'interface ethX soient redirigées à la machine dont
	#### l'adresse IPv4 est 192.168.X.X sur son port XX (la réponse à la
	#### requête sera transférée au client).

	echo -e  "$TASK $YELLOW Port Forwarding initialization $RESET\n"


	iptables -t nat -A PREROUTING  -i eth0 -p tcp -m tcp --dport 443 -j DNAT --to-destination 0.0.0.0:443
	iptables -t nat -A POSTROUTING -s 0.0.0.0/32 -o eth0 -j SNAT --to-source 0.0.0.0 

	echo -e "$TASK  $YELLOW Port Forwarding Finish $RESET\n";

}

FixMTU()
{
	####################
	# Problème de MTU… #
	####################

	####### Les instructions qui suivent concernent la table « mangle », c'est
	####### à dire l'altération des paquets

	###### mangle

	#### Si la connexion que vous partagez est une connexion ADSL directement gérée
	#### par votre ordinateur, vous serez probablement confronté au fameux problème du
	#### MTU. En résumé, le problème vient du fait que le MTU de la liaison entre
	#### votre fournisseur d'accès et le serveur NAT est un petit peu inférieur au MTU
	#### de la liaison Ethernet qui relie le serveur NAT aux machines qui sont
	#### derrière le NAT. Pour résoudre ce problème, décommentez la ligne suivante et
	#### remplacez « eth0 » par le nom de l'interface connectée à Internet.


 	iptables -A FORWARD -p tcp --tcp-flags SYN,RST SYN -j TCPMSS -o eth0 --clamp-mss-to-pmtu
  	iptables -A FORWARD -p tcp --tcp-flags SYN,RST SYN -j TCPMSS -o wlan0 --clamp-mss-to-pmtu
}

################################# 
#  								#
#			Main 				#
#								#	
#################################

for args in "$*"
do


	if  [ "$args" == "-c" ]; then
		ClearIptables
	elif [ "$args" == "-r" ]; then
		ClearIptables
		RulesIptables	
	elif [ "$args" == "--mtu" ]; then
		FixMTU 
	elif [ "$args" == "--nat" ]; then
		NetworkTranslateAddress
	elif [ "args" == "-f" ]; then
		Forwarding
	else
		echo -e "\n Usage   - ./firewall.sh <option> \n"
		echo -e " -r - Run iptables rules \n Example - ./firewall.sh -r"		
		echo -e " \n -c - Clear iptables rules \n Example - ./firewall.sh -c"
		echo -e " \n -f - Forwarding port (config port and IP in the script) \n Example - ./firewall.sh -f"
		echo -e " \n --mtu - Configure mtu (config interface in the script) \n Example - ./firewall.sh --mtu"
		echo -e " \n --nat - Configure Network Translate Address (Configure interface ant IP in the script) \n Example - ./firewall.sh --nat\n"			
fi
done

exit 0;	
