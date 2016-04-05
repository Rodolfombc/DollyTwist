# GyroTwist #

Application developed for the Smartphone Development course at UFRJ (Federal University of Rio de Janeiro), lectured by Professor Sérgio Barbosa Villas-Boas.
It is a game like "Temple Run", where the stage is procedurally generated. It is a 2D game in which the core mechanic is to rotate the mobile device to continue running. The score is based on how much you can keep running without falling outside the screen's borders.


### Technologies Used ###

* Unity 5.2.1f1 (64-bit)
* PHP 5

The game was all developed in Unity with C#.
The backend part of the project uses a PHP script that organizes and returns the 8 best obtained scores in the game by everybody that played the game.
UPDATE: The host of the backend part is no longer working. But creating a new host and putting the php script into it and updating the url inside internet_connection.cs script will make the web part work again!

### Exporting to Android ###

In order to export to Android, you only need to download this repo to a computer that has Unity 5.2.1f1 or greater.
Afterwards, open the unity project and do the following commands:

1) Go to "File" > "Build Settings...";

2) In "Platform" choose "Android";

3) Build your project by clicking "Build";

With this, a .apk will be generated. Put this .apk on your android device, install the .apk and then you are ready to go!
