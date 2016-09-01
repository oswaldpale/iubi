# iubi

# Como funciona el servicio?

El servicio registra y valida la huella dactilar del lector biometrico usando  el SDK digital persona.
La aplicación despliega un proceso en segundo plano que permite escuchar los eventos y acciones mediante javascript.

#Como se Instala
- Instalar el SDK digital persona.
- Ejecutar el archivo iubi.exe(instalara los componente necesario para inicializar la aplicación).

# Como conectar iubi.exe con javascript.

como el proceso que corre en segundo plano escucha las acciones que suceden en el dispositivo huellero, estas se transmiten directamente al navegador mediante socket.

 var iubi = new WebSocket('ws://127.0.0.1:2015')
 
 la ip siempre sera la ip local del equipo, y el puerto 2015
 
 si sucede alguna error al proceso de conectarse
 
 iubi.onerror = function (error) {
        Ext.Msg.info({ ui: 'warning', title: 'UI', html: 'El servicio del Lector U Are U 4500 Digital Persona esta inactivo', iconCls: '#Error' });
    };


Como cualquier SDK de huella dactilar, esta constituido por dos eventos: 
 - El registro de huella.
 - La verificación de la plantilla almacenada con la huella.
 - 
 

