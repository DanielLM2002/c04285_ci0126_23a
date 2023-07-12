Para poder correr el proyecto solo se debe de compilar con visualStudio
Las pruebas unitarias se encuentran en el Archivo TestProject
Las pruebas funcionales se encuentrane en el archivo SeleniumCore
Por otro lado para poder hacer pruebas las unitarias funcionan con solo ir al test explorer y ejecutarlas mientras
que la automatizadas requieren que:
1. Se abran dos instancias de Visual Studio, una que estará ejecutando la aplicacion y otra que hará los test. Es importante mencionar que no pueden ser la misma instancia haciendo ambas. 
2. Cambiar el localHost que se encuentra al inicio de cada uno de los test por el local host de la maquina que ejecuta la aplicacion.
3. Tener los paquetes nuget de las dependencias descargados, estos ya vienen en la solucion por defecto.

