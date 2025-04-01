Instalar todas las librerias de Debian
Pasos para Configurar Sudo en un Debian Nuevo

1. Actualizar Repositorios (como root)

"su -" # Convierte en root (contraseña: la que configuraste durante la instalación)
"apt update"
"apt upgrade -y"

2. Instalar Sudo (si no está)
"apt install sudo -y"

3. Añadir tu Usuario al Grupo Sudo
"usermod -aG sudo robert"  # Reemplaza "robert" con tu nombre de usuario

4. Verificar el Archivo /etc/sudoers
"visudo"---------->Asegúrate de que esta línea exista (descomentada, sin #):-->"%sudo   ALL=(ALL:ALL) ALL"

5. Reiniciar o Cerrar Sesión
"reboot"
O simplemente cierra todas las terminales y vuelve a iniciar sesión.

Verificación Final--->Después de reiniciar: --->"sudo whoami"-->Si devuelve root, ¡todo está listo!

 Nota para Sistemas Mínimos

En instalaciones mínimas de Debian, incluso sudo puede faltar. Siempre puedes:
1.-Usar su - para ser root.
2.-Instalar lo básico:
"apt install sudo curl wget git -y"

Si necesitas instalar algo (como Chrome), ahora puedes hacerlo con: "sudo apt install ./paquete.deb"

Instalar programas con sudo (ejemplo con Google Chrome):

"wget https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb"
"sudo apt install ./google-chrome-stable_current_amd64.deb"

Administrar tu sistema (si necesitas):
Actualizar todos los paquetes:

"sudo apt update && sudo apt upgrade -y"
"sudo apt install curl git vim -y"

Si aún ves errores
Si después de esto aparece robert--> is not in the sudoers file en algún contexto:
Cierra todas las terminales y reinicia sesión.
Verifica nuevamente:

"groups robert"  # Debe mostrar sudo
"sudo whoami"    # Debe responder root--------> ¡Listo!
Ahora tienes un sistema Debian completamente funcional con permisos de administrador.

¡Configurar SSH en Debian (2025) es muy sencillo! Sigue estos pasos para acceder a tu máquina de forma remota de manera segura:

1. Instalar el servidor SSH (si no está)

"sudo apt update"
"sudo apt install openssh-server -y"

2. Habilitar y verificar el servicio

"sudo systemctl enable --now ssh"  # Activa y inicia SSH
"sudo systemctl status ssh"        # Debe aparecer "active (running)"

3. Obtener la IP local de tu máquina

"ip a"--------->Busca la IP en la interfaz principal (ej: eth0 o wlan0). Se ve así:
inet 192.168.1.100/24 → Tu IP es 192.168.1.100.

4. Conectarse desde otro dispositivo
En Linux/macOS:-->"ssh robert@192.168.1.100"

En Windows:-->Usa PuTTY o la terminal integrada (PowerShell/CMD): --->"ssh robert@192.168.1.100"

---------------------CONFIGURACION DE SERVIDOR ZABBIX---------------------
1.-"ssh robert@192.168.1.100"  Conectarse desde
2.- "su -"------->contraceña
3.- "apt install sudo"
4.- root@debianbasica:-# "cd /etc/"
6.- root@debianbasica:/etc# "ls"
7.- root@debianbasica:/etc#  "nano sudoers"--------->ingresas al archivo:
# User privilege specification
root        ALL=(ALL:ALL) ALL
robert     ALL=(ALL:ALL) ALL(colocar esto en el archivo y guardar con ctrl+0 ENTER y ctr+x para salir)
8.-root@debianbasica:/etc#  "su  -  robert"
9.-Comando para instalar LAMP
"sudo apt install mariadb-server mariadb-client apache2 php libapache2-mod-php php-mysql php-curl php-json php-cgi php-pear php-gd php-apcu"--->de decimos -->S 


